from .content import NavigationItem


def base_data(request):
    """Provide shared navigation and footer data to every inherited template."""
    navigation = [
        NavigationItem("Головна", "home", "home"),
        NavigationItem("Про компанію", "about", "about"),
        NavigationItem("Продукція", "product-list", "products"),
        NavigationItem("Пасіки", "apiary-list", "apiaries"),
        NavigationItem("Щоденник", "news", "news"),
        NavigationItem("Контакти", "contacts", "contacts"),
    ]
    footer_links = navigation + [
        NavigationItem("Пасічник", "management", "management"),
        NavigationItem("Історія компанії", "about-history", "about"),
        NavigationItem("Наша команда", "about-team", "about"),
    ]
    return {
        "base_data": {
            "brand_name": "ROGER HONEY",
            "tagline": "Маленька пасіка. Велика любов до своєї справи.",
            "location": "Одеська область, Україна",
            "navigation": navigation,
            "footer_links": footer_links,
            "footer_note": "Зроблено з повагою до природи",
        }
    }
