from django.contrib import admin

from .models import Apiary, Article, Category, Product, Review


@admin.register(Category)
class CategoryAdmin(admin.ModelAdmin):
    list_display = ("name", "slug", "parent")
    search_fields = ("name", "description")
    prepopulated_fields = {"slug": ("name",)}


@admin.register(Product)
class ProductAdmin(admin.ModelAdmin):
    list_display = ("name", "category", "price")
    list_filter = ("category",)
    search_fields = ("name", "description")


@admin.register(Apiary)
class ApiaryAdmin(admin.ModelAdmin):
    list_display = ("name", "location", "hive_count", "established_year")
    search_fields = ("name", "location")


@admin.register(Article)
class ArticleAdmin(admin.ModelAdmin):
    list_display = ("title", "is_published")
    list_filter = ("is_published",)
    search_fields = ("title", "excerpt", "content")
    prepopulated_fields = {"slug": ("title",)}


@admin.register(Review)
class ReviewAdmin(admin.ModelAdmin):
    list_display = ("author_name", "rating", "is_published", "created_at")
    list_filter = ("rating", "is_published")
    search_fields = ("author_name", "text")
