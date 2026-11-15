from django.shortcuts import render


def home(request):
    return render(request, "home.html", {"active_page": "home"})


def news(request):
    return render(request, "news.html", {"active_page": "news"})


def management(request):
    return render(request, "management.html", {"active_page": "management"})


def about(request):
    return render(request, "about.html", {"active_page": "about"})


def contacts(request):
    context = {
        "active_page": "contacts",
        # Add real contact data here when it is ready:
        # "contact_email": "your-email@example.com",
        # "phone_number": "+380...",
        # "instagram_url": "https://www.instagram.com/your-account/",
    }
    return render(request, "contacts.html", context)
