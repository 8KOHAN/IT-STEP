import os
from typing import Any

from flask import Flask, session

from app.controllers.catalog_controller import CatalogController


def create_app() -> Flask:
    app = Flask(__name__, template_folder="views/templates", static_folder="static")
    app.config.update(
        SECRET_KEY=os.environ.get("FLASK_SECRET_KEY", "krok-local-development-key-change-before-deploy"),
        SESSION_COOKIE_HTTPONLY=True,
        SESSION_COOKIE_SAMESITE="Lax",
        SESSION_COOKIE_SECURE=os.environ.get("FLASK_ENV") == "production",
        MAX_CONTENT_LENGTH=1 * 1024 * 1024,
        TEMPLATES_AUTO_RELOAD=True,
    )

    controller = CatalogController()

    @app.context_processor
    def inject_layout_data() -> dict[str, Any]:
        bag = session.get("bag", {})
        count = 0
        if isinstance(bag, dict):
            for quantity in bag.values():
                try:
                    count += max(0, int(quantity))
                except (TypeError, ValueError):
                    continue
        return {"bag_count": count}

    @app.get("/")
    def index():
        return controller.index()

    @app.get("/shoes/<int:shoe_id>")
    def shoe_details(shoe_id: int):
        return controller.details(shoe_id)

    @app.post("/shoes/<int:shoe_id>/bag")
    def add_to_bag(shoe_id: int):
        return controller.add_to_bag(shoe_id)

    @app.get("/bag")
    def bag():
        return controller.bag()

    @app.post("/bag/<int:shoe_id>/<int:size>/remove")
    def remove_from_bag(shoe_id: int, size: int):
        return controller.remove_from_bag(shoe_id, size)

    @app.post("/shoes/<int:shoe_id>/favorite")
    def toggle_favorite(shoe_id: int):
        return controller.toggle_favorite(shoe_id)

    @app.errorhandler(404)
    def page_not_found(_error):
        return controller.not_found()

    return app
