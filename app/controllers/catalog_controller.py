from flask import flash, jsonify, redirect, render_template, request, session, url_for

from app.models.shoe import ShoeModel


class CatalogController:
    def __init__(self) -> None:
        self.model = ShoeModel()

    def index(self):
        shoes = self.model.get_all_shoes()
        hero_shoe = self.model.get_shoe_by_id(2)
        return render_template(
            "shoes/index.html",
            shoes=shoes,
            hero_shoe=hero_shoe,
            categories=self.model.get_categories(),
            favorites=self._get_favorites(),
            total_count=len(shoes),
            active_category=request.args.get("category", "Усе"),
            active_sort=request.args.get("sort", "featured"),
            active_query=request.args.get("q", ""),
            active_surface=request.args.get("surface", ""),
        )

    def details(self, shoe_id: int):
        shoe = self.model.get_shoe_by_id(shoe_id)
        if shoe is None:
            return self.not_found()
        return render_template(
            "shoes/details.html",
            shoe=shoe,
            favorites=self._get_favorites(),
            related_shoes=[item for item in self.model.get_all_shoes() if item.id != shoe.id][:3],
        )

    def add_to_bag(self, shoe_id: int):
        shoe = self.model.get_shoe_by_id(shoe_id)
        if shoe is None:
            return self._error("Цю пару не знайдено в архіві.", 404)

        payload = request.get_json(silent=True) or {}
        raw_size = payload.get("size") or request.form.get("size") or shoe.sizes[0]
        try:
            selected_size = int(raw_size)
        except (TypeError, ValueError):
            selected_size = shoe.sizes[0]
        if selected_size not in shoe.sizes:
            return self._error("Цей розмір недоступний для обраної моделі.", 400)

        bag = self._get_bag()
        key = f"{shoe_id}:{selected_size}"
        bag[key] = bag.get(key, 0) + 1
        session["bag"] = bag
        session.modified = True
        summary = self._bag_summary(bag)
        message = f"{shoe.name} · розмір {selected_size} додано до твого маршруту."

        if self._wants_json():
            return jsonify(ok=True, message=message, **summary)
        flash(message, "success")
        return redirect(request.referrer or url_for("index"))

    def bag(self):
        bag = self._get_bag()
        items = self._build_bag_items(bag)
        return render_template("shoes/bag.html", items=items, total=sum(item["line_total"] for item in items))

    def remove_from_bag(self, shoe_id: int, size: int):
        bag = self._get_bag()
        bag.pop(f"{shoe_id}:{size}", None)
        session["bag"] = bag
        session.modified = True
        summary = self._bag_summary(bag)
        message = "Позицію прибрано з маршруту."

        if self._wants_json():
            return jsonify(ok=True, message=message, **summary)
        flash(message, "success")
        return redirect(url_for("bag"))

    def toggle_favorite(self, shoe_id: int):
        shoe = self.model.get_shoe_by_id(shoe_id)
        if shoe is None:
            return self._error("Цю пару не знайдено в архіві.", 404)

        favorites = self._get_favorites()
        if shoe_id in favorites:
            favorites.remove(shoe_id)
            is_favorite = False
            message = "Пару прибрано зі збережених."
        else:
            favorites.append(shoe_id)
            is_favorite = True
            message = "Пару додано до збережених."

        session["favorites"] = favorites
        session.modified = True
        if self._wants_json():
            return jsonify(ok=True, message=message, is_favorite=is_favorite)
        flash(message, "success")
        return redirect(request.referrer or url_for("index"))

    def not_found(self):
        return render_template("404.html"), 404

    def _error(self, message: str, status: int):
        if self._wants_json():
            return jsonify(ok=False, message=message), status
        flash(message, "error")
        return redirect(url_for("index")), status

    def _build_bag_items(self, bag: dict[str, int]) -> list[dict]:
        items = []
        for item_key, quantity in bag.items():
            try:
                shoe_id_text, size_text = item_key.split(":", maxsplit=1)
                shoe_id = int(shoe_id_text)
                selected_size = int(size_text)
            except (ValueError, TypeError):
                continue

            shoe = self.model.get_shoe_by_id(shoe_id)
            if shoe is None or quantity <= 0 or selected_size not in shoe.sizes:
                continue
            items.append({
                "shoe": shoe,
                "quantity": quantity,
                "selected_size": selected_size,
                "line_total": shoe.price * quantity,
            })
        return items

    def _bag_summary(self, bag: dict[str, int]) -> dict[str, int]:
        items = self._build_bag_items(bag)
        return {
            "bag_count": sum(item["quantity"] for item in items),
            "items_count": len(items),
            "total": sum(item["line_total"] for item in items),
        }

    @staticmethod
    def _get_bag() -> dict[str, int]:
        raw_bag = session.get("bag", {})
        if not isinstance(raw_bag, dict):
            return {}
        clean_bag: dict[str, int] = {}
        for key, value in raw_bag.items():
            try:
                quantity = int(value)
            except (TypeError, ValueError):
                continue
            if quantity > 0:
                clean_bag[str(key)] = min(quantity, 99)
        return clean_bag

    @staticmethod
    def _get_favorites() -> list[int]:
        raw_favorites = session.get("favorites", [])
        if not isinstance(raw_favorites, list):
            return []
        favorites = []
        for value in raw_favorites:
            try:
                favorites.append(int(value))
            except (TypeError, ValueError):
                continue
        return list(dict.fromkeys(favorites))

    @staticmethod
    def _wants_json() -> bool:
        return (
            request.is_json
            or request.accept_mimetypes.best == "application/json"
            or request.headers.get("X-Requested-With") == "XMLHttpRequest"
        )
