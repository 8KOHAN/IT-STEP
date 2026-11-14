import random

from django.shortcuts import render
from django.utils import timezone


WEEKDAYS = [
    "Понеділок",
    "Вівторок",
    "Середа",
    "Четвер",
    "П'ятниця",
    "Субота",
    "Неділя",
]

QUOTES = [
    "Великі справи починаються з маленьких кроків.",
    "Навчання — це скарб, який супроводжує свого власника всюди.",
    "Успіх — це сума маленьких зусиль, що повторюються щодня.",
    "Не бійся помилятися, бійся не вчитися на помилках.",
    "Єдиний спосіб робити велику роботу — любити те, що робиш.",
]


def home(request):
    current_day = WEEKDAYS[timezone.localdate().weekday()]
    random_quote = random.choice(QUOTES)

    context = {
        "current_day": current_day,
        "random_quote": random_quote,
    }

    return render(request, "greetings/index.html", context)