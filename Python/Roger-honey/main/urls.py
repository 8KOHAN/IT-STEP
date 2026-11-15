from django.urls import path

from .views import (
    AboutView,
    ContactsView,
    EducationView,
    HistoryView,
    HomeView,
    ManagementView,
    TeamView,
)

urlpatterns = [
    path("", HomeView.as_view(), name="home"),
    path("about/", AboutView.as_view(), name="about"),
    path("about/history/", HistoryView.as_view(), name="about-history"),
    path("about/team/", TeamView.as_view(), name="about-team"),
    path("management/", ManagementView.as_view(), name="management"),
    path("contacts/", ContactsView.as_view(), name="contacts"),
    path("contact/", ContactsView.as_view(), name="contact-alt"),
    path("news/education/", EducationView.as_view(), name="news-education"),
]
