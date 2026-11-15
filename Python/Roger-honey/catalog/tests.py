from decimal import Decimal

from django.test import TestCase
from django.urls import reverse

from .models import Apiary, Article, Category, Product, Review
from .templatetags.company_filters import format_price


class CatalogModelTests(TestCase):
    def setUp(self):
        self.category = Category.objects.create(
            name="Натуральний мед",
            slug="natural-honey",
            description="Мед із пасіки.",
        )

    def test_product_uses_category_relationship(self):
        product = Product.objects.create(
            name="Мед різнотрав'я",
            description="Натуральний мед.",
            price=Decimal("250.00"),
            category=self.category,
        )
        self.assertEqual(product.category, self.category)

    def test_all_five_models_are_available(self):
        model_names = {model.__name__ for model in (Category, Product, Apiary, Article, Review)}
        self.assertEqual(model_names, {"Category", "Product", "Apiary", "Article", "Review"})

    def test_catalog_page_uses_database_products(self):
        Product.objects.create(
            name="Мед різнотрав'я",
            description="Натуральний мед.",
            price=Decimal("250.00"),
            category=self.category,
        )
        response = self.client.get(reverse("product-list"))
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, "Мед різнотрав'я", html=True)

    def test_price_filter_formats_hryvnia(self):
        self.assertEqual(format_price(Decimal("1250.00")), "1 250 ₴")
