from django.contrib import admin
from django.urls import include, path

from main.views import page_not_found

handler404 = "main.views.custom_404"

urlpatterns = [
    path("admin/", admin.site.urls),
    path("", include("main.urls")),
    path("", include("catalog.urls")),
    path("<path:unknown_path>", page_not_found, name="page-not-found"),
]
