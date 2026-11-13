from dataclasses import dataclass
from typing import ClassVar


@dataclass(frozen=True, slots=True)
class Shoe:
    id: int
    name: str
    category: str
    price: int
    old_price: int | None
    color: str
    sizes: tuple[int, ...]
    image: str
    label: str
    description: str
    surfaces: tuple[str, ...]
    pace: str
    material: str
    code: str
    accent: str
    is_new: bool = False


class ShoeModel:
    """Small in-memory sneaker archive for the KROK Flask prototype."""

    _SHOES: ClassVar[tuple[Shoe, ...]] = (
        Shoe(
            id=1,
            name="Ритм 01 / Asphalt",
            category="Кеди",
            price=3290,
            old_price=3890,
            color="Графіт / холодний білий",
            sizes=(39, 40, 41, 42, 43, 44),
            image="https://images.unsplash.com/photo-1535595278992-7d1e59b30194?auto=format&fit=crop&w=1500&q=88",
            label="АРХІВНИЙ ВИБІР",
            description="Міська база з чітким силуетом. Для довгих переходів, коротких дедлайнів і власного темпу.",
            surfaces=("бетон", "асфальт", "універсальне"),
            pace="міський ритм",
            material="текстиль / замша",
            code="K-001 / 24",
            accent="#3159f5",
        ),
        Shoe(
            id=2,
            name="Воля 02 / Electric",
            category="Кросівки",
            price=4190,
            old_price=None,
            color="Кобальт / білий",
            sizes=(40, 41, 42, 43, 44, 45),
            image="https://images.unsplash.com/photo-1676041669566-fead69bd7007?auto=format&fit=crop&w=1500&q=88",
            label="НОВИЙ ОБ'ЄКТ",
            description="Зібрані для швидких рішень і різких поворотів. Контрастна форма, м'яка посадка та енергія міста.",
            surfaces=("асфальт", "ніч", "універсальне"),
            pace="швидкий темп",
            material="сітка / синтетика",
            code="K-002 / 26",
            accent="#ef5939",
            is_new=True,
        ),
        Shoe(
            id=3,
            name="Тиша 03 / Bone",
            category="Кеди",
            price=2790,
            old_price=None,
            color="Кістяний / пісочний",
            sizes=(36, 37, 38, 39, 40, 41, 42),
            image="https://images.unsplash.com/photo-1728724794795-681832a6afd0?auto=format&fit=crop&w=1200&q=88",
            label="ТИХА ФОРМА",
            description="Лаконічний силует і спокійна палітра. Менше деталей, більше простору для твого стилю.",
            surfaces=("бетон", "універсальне"),
            pace="повсякденний",
            material="шкіра / текстиль",
            code="K-003 / 25",
            accent="#d7c9ae",
            is_new=True,
        ),
        Shoe(
            id=4,
            name="Шлях 04 / Night Run",
            category="Бігові",
            price=3690,
            old_price=4290,
            color="Чорний / графіт",
            sizes=(39, 40, 41, 42, 43, 44, 45),
            image="https://images.unsplash.com/photo-1738958668282-4c7446241e9e?auto=format&fit=crop&w=1400&q=88",
            label="НІЧНИЙ МАРШРУТ",
            description="Легка конструкція для ранкових пробіжок і вечірніх кіл містом. Коли асфальт ще пам'ятає денне тепло.",
            surfaces=("асфальт", "ніч"),
            pace="високий темп",
            material="інженерна сітка",
            code="K-004 / 25",
            accent="#8d9b9a",
        ),
        Shoe(
            id=5,
            name="Дике поле 05 / Clay",
            category="Високі",
            price=3890,
            old_price=None,
            color="Теракота / чорний",
            sizes=(39, 40, 41, 42, 43, 44),
            image="https://images.unsplash.com/photo-1695459590088-d6fd3cc97cfa?auto=format&fit=crop&w=1400&q=88",
            label="ОБМЕЖЕНИЙ ТИРАЖ",
            description="Високий силует, щільний верх і відтінок випаленої землі. Для маршрутів, які не закінчуються на тротуарі.",
            surfaces=("ґрунт", "бетон"),
            pace="довга дистанція",
            material="щільний текстиль",
            code="K-005 / 26",
            accent="#d45b3f",
            is_new=True,
        ),
        Shoe(
            id=6,
            name="Берег 06 / Cobalt",
            category="Бігові",
            price=3490,
            old_price=None,
            color="Синій / холодний білий",
            sizes=(40, 41, 42, 43, 44, 45),
            image="https://images.unsplash.com/photo-1770430725086-8b677d6f25a8?auto=format&fit=crop&w=1400&q=88",
            label="МІСТО × РУХ",
            description="Пружна посадка та виразна геометрія. Створені для тих, кому звичайного кроку вже недостатньо.",
            surfaces=("асфальт", "ніч", "універсальне"),
            pace="високий темп",
            material="сітка / піна",
            code="K-006 / 26",
            accent="#3159f5",
        ),
        Shoe(
            id=7,
            name="Пульс 07 / Signal",
            category="Кросівки",
            price=4490,
            old_price=None,
            color="Сигнальний червоний / білий",
            sizes=(40, 41, 42, 43, 44),
            image="https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=1400&q=88",
            label="СИГНАЛ / 007",
            description="Колір, який неможливо не помітити. Графічна геометрія та характер, що не потребує пояснень.",
            surfaces=("бетон", "асфальт"),
            pace="міський ритм",
            material="шкіра / гума",
            code="K-007 / 26",
            accent="#ef5939",
            is_new=True,
        ),
        Shoe(
            id=8,
            name="Основа 08 / Mono",
            category="Кеди",
            price=2590,
            old_price=2990,
            color="Чорний / молочний",
            sizes=(38, 39, 40, 41, 42, 43, 44),
            image="https://images.unsplash.com/photo-1786379582231-f4a593cacf2d?auto=format&fit=crop&w=1400&q=88",
            label="БАЗА / 008",
            description="Надійна пара на щодень. Стриманий монохром, фактурні матеріали та силует без зайвого шуму.",
            surfaces=("універсальне", "бетон"),
            pace="повсякденний",
            material="сітка / синтетика",
            code="K-008 / 24",
            accent="#c9c5bb",
        ),
    )

    def get_all_shoes(self) -> list[Shoe]:
        return list(self._SHOES)

    def get_shoe_by_id(self, shoe_id: int) -> Shoe | None:
        return next((shoe for shoe in self._SHOES if shoe.id == shoe_id), None)

    def get_categories(self) -> list[str]:
        return list(dict.fromkeys(shoe.category for shoe in self._SHOES))
