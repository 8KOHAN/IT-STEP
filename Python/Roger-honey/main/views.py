from django.shortcuts import render
from django.views.generic import TemplateView

from .content import FeatureCard, Milestone, NewsCard, TeamMember


class HomeView(TemplateView):
    template_name = "home.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        news_items = [
            NewsCard(
                "01",
                "СЕЗОННІСТЬ",
                "ВЕСНА",
                "Перші теплі дні на пасіці",
                "Після зимового спокою бджоли поступово повертаються до активного життя.",
                "first-warm-days",
            ),
            NewsCard(
                "02",
                "СПОСТЕРЕЖЕННЯ",
                "БДЖОЛИ",
                "Життя всередині вулика",
                "Знайомство з організацією бджолиної сім'ї та щоденною роботою її мешканців.",
                "life-inside-the-hive",
            ),
            NewsCard(
                "03",
                "ПРОДУКТИ ПАСІКИ",
                "МЕД",
                "Від квітки до меду",
                "Нектар, стільники та уважна праця — шлях до знайомого золотого смаку.",
                "from-flower-to-honey",
            ),
        ]
        statistics = [
            FeatureCard("01", "Турбота", "Уважне ставлення до бджіл на кожному етапі сезону."),
            FeatureCard("02", "Сезонність", "Робота відповідно до природних циклів та умов місцевості."),
            FeatureCard("03", "Відкритість", "Розповідаємо про пасіку чесно та без перебільшень."),
        ]
        context.update(
            {
                "active_page": "home",
                "news_items": news_items,
                "company_data": {
                    "hero": {
                        "eyebrow": "SMALL APIARY / ODESA REGION / UKRAINE",
                        "description": "Світ бджіл, аромат квітів, тепло сонця і щоденна праця, яка перетворюється на щось по-справжньому особливе.",
                    },
                    "statistics": statistics,
                    "journal": {"items": news_items, "total": len(news_items)},
                },
            }
        )
        return context


class AboutView(TemplateView):
    template_name = "about.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        milestones = [
            Milestone("01", "Перші знайомства з бджолами", "Інтерес до бджільництва перетворюється на практику, спостереження та перший досвід."),
            Milestone("02", "Розвиток пасіки", "Нові бджолині сім'ї, більше роботи та глибше розуміння пасічництва."),
            Milestone("03", "ROGER HONEY", "Створення власного бренду та бажання ділитися світом пасіки з іншими."),
        ]
        context.update(
            {
                "active_page": "about",
                "milestones": milestones,
                "about_data": {
                    "milestones": milestones,
                    "subsections": [
                        FeatureCard("01", "Історія компанії", "Як формується досвід і розвивається пасіка.", "about-history"),
                        FeatureCard("02", "Наша команда", "Люди, які щодня дбають про пасіку.", "about-team"),
                    ],
                },
            }
        )
        return context


class HistoryView(TemplateView):
    template_name = "about_history.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context.update(
            {
                "active_page": "about",
                "milestones": [
                    Milestone("01", "Зацікавлення", "Перші спостереження за бджолами стали початком системного навчання."),
                    Milestone("02", "Практика", "Досвід накопичувався завдяки сезонній роботі та турботі про сім'ї."),
                    Milestone("03", "Власна справа", "ROGER HONEY об'єднує пасіку, продукти та історії бджолиного світу."),
                ],
            }
        )
        return context


class TeamView(TemplateView):
    template_name = "about_team.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        managers = [
            TeamMember("RH", "Команда ROGER HONEY", "ПАСІКА", "Невелика команда, у якій важливі уважність, відповідальність і постійне навчання."),
            TeamMember("01", "Пасічник", "ДОГЛЯД ЗА БДЖОЛАМИ", "Спостерігає за станом сімей, планує сезонні роботи та дбає про умови утримання."),
        ]
        context.update({"active_page": "about", "managers": managers, "team_data": {"members": managers, "count": len(managers)}})
        return context


class ManagementView(TemplateView):
    template_name = "management.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        managers = [
            TeamMember("RH", "Команда ROGER HONEY", "ПАСІКА", "Невелика команда, яка поєднує практику, спостереження та постійне навчання."),
            TeamMember("01", "Пасічник", "ДОГЛЯД ЗА СІМ'ЯМИ", "Стежить за розвитком бджолиних сімей і планує роботи відповідно до сезону."),
        ]
        context.update({"active_page": "management", "managers": managers, "team_data": {"members": managers, "count": len(managers)}})
        return context


class ContactsView(TemplateView):
    template_name = "contacts.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context.update(
            {
                "active_page": "contacts",
                "contact_email": "",
                "phone_number": "",
                "instagram_url": "",
                "contact_data": {
                    "location": "Одеська область, Україна",
                    "message": "Будемо раді відповісти на запитання про продукцію та пасіку.",
                },
            }
        )
        return context


class EducationView(TemplateView):
    template_name = "news_education.html"

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        topics = [
            FeatureCard("01", "Біологія бджіл", "Ролі робочих бджіл, матки та трутнів у житті сім'ї."),
            FeatureCard("02", "Медоносні рослини", "Чому періоди цвітіння впливають на роботу пасіки."),
            FeatureCard("03", "Продукти бджільництва", "Мед, віск, пилок та інші продукти пасіки."),
        ]
        context.update({"active_page": "news", "topics": topics, "education_data": {"topics": topics, "count": len(topics)}})
        return context


def page_not_found(request, unknown_path=""):
    """Render a branded 404 page for unknown URL paths."""
    return render(request, "404.html", {"active_page": "", "unknown_path": unknown_path}, status=404)


def custom_404(request, exception):
    return render(request, "404.html", status=404)
