from django.contrib import admin
from django.urls import path

from . import views

urlpatterns = [
    path("admin/", admin.site.urls),
    path("", views.home, name="home"),
    path("news/", views.news, name="news"),
    path("management/", views.management, name="management"),
    path("about/", views.about, name="about"),
    path("contacts/", views.contacts, name="contacts"),
    path("contact/", views.contacts, name="contact-alt"),

    # Catch-all routes must stay after the exact section routes.
    # The path converter also captures additional slash-separated segments.
    path("news/<path:extra>", views.news, name="news-catchall"),
    path("management/<path:extra>", views.management, name="management-catchall"),
    path("about/<path:extra>", views.about, name="about-catchall"),
    path("contacts/<path:extra>", views.contacts, name="contacts-catchall"),
    path("contact/<path:extra>", views.contacts, name="contact-alt-catchall"),
]
