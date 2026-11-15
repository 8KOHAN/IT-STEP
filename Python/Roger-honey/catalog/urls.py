from django.urls import path

from .views import ApiaryListView, NewsListView, ProductCategoryView, ProductDetailView, ProductListView

urlpatterns = [
    path("products/", ProductListView.as_view(), name="product-list"),
    path("products/categories/", ProductCategoryView.as_view(), name="product-categories"),
    path("products/<int:pk>/", ProductDetailView.as_view(), name="product-detail"),
    path("apiaries/", ApiaryListView.as_view(), name="apiary-list"),
    path("news/", NewsListView.as_view(), name="news"),
]
