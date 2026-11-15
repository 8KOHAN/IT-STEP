from django.http import Http404
from django.shortcuts import render
from django.views.generic import DetailView, ListView

from main.content import ApiaryCard, NewsCard

from .models import Apiary, Article, Category, Product


class ProductListView(ListView):
    model = Product
    template_name = "products.html"
    context_object_name = "products"

    def get_queryset(self):
        return Product.objects.select_related("category").all()

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        database_products = list(context["products"])

        sample_products = [
            {
                "name": "Пилок бджолиний",
                "description": "Різнокольорові квіткові гранули, зібрані бджолами протягом сезону.",
                "price": 180,
                "category": "Продукти бджільництва",
                "image_url": "https://cdn.pixabay.com/photo/2017/07/28/16/30/bee-pollen-2549125_1280.jpg",
                "image_class": "pollen",
            },
            {
                "name": "Мед у стільниках",
                "description": "Натуральний мед у запечатаних воскових комірках.",
                "price": 220,
                "category": "Натуральний мед",
                "image_url": "https://images.pexels.com/photos/8105066/pexels-photo-8105066.jpeg?cs=srgb&dl=pexels-solodsha-8105066.jpg&fm=jpg",
                "image_class": "comb",
            },
            {
                "name": "Мед акацієвий",
                "description": "Світлий мед із ніжним квітковим ароматом та м’яким смаком.",
                "price": 270,
                "category": "Натуральний мед",
                "image_url": "https://images.unsplash.com/photo-1679941350246-7fd54f545720?auto=format&fit=crop&w=1200&q=85",
                "image_class": "acacia",
            },
            {
                "name": "Подарунковий набір",
                "description": "Добірка різних сортів меду для подарунка або дегустації.",
                "price": 420,
                "category": "Подарункові набори",
                "image_url": "https://images.unsplash.com/photo-1777768785267-3615d0e44303?auto=format&fit=crop&w=1200&q=85",
                "image_class": "gift",
            },
            {
                "name": "Перга в меду",
                "description": "Перга — ферментований бджолами пилок, змішаний із натуральним медом для зберігання.",
                "price": "Ціну уточнюйте",
                "category": "Продукти бджільництва",
                "image_url": "/static/images/products/перга.jpg",
                "image_class": "perga",
            },
            {
                "name": "Маточне молочко 4% у меду",
                "description": "Маточне молочко у натуральному меді. Медова основа використовується для консервації цього чутливого продукту.",
                "price": "Ціну уточнюйте",
                "category": "Продукти бджільництва",
                # Official product photo: https://ivan.eco/catalog/matochnoe-molochko-4
                "image_url": "/static/images/products/royal-jelly-khalilov.webp",
                "image_class": "royal-jelly",
            },
            {
                "name": "Трутневий гомогенат 10% у меду",
                "description": "Трутневий гомогенат у натуральному меді. Медова основа використовується для консервації продукту.",
                "price": "Ціну уточнюйте",
                "category": "Продукти бджільництва",
                # Official product photo: https://ivan.eco/catalog/trutnevyy-gomogenat
                "image_url": "/static/images/products/drone-homogenate-khalilov.webp",
                "image_class": "drone-homogenate",
            },
            {
                "name": "Вощина бджолина",
                "description": "Листи натурального бджолиного воску з рельєфом шестикутних комірок для рамок.",
                "price": "Ціну уточнюйте",
                "category": "Вироби з воску",
                "image_url": "https://thehoneyfactory.de/app/uploads/2025/01/72044_Product-1.jpg",
                "image_class": "foundation",
            },
        ]
        # Keep existing database products first; never replace an existing image.
        sample_image_by_name = {
            product["name"].casefold(): product["image_url"]
            for product in sample_products
        }
        for index, product in enumerate(database_products):
            if not product.image_url:
                if index == 0:
                    product.image_class = "honey"
                else:
                    product.image_url = sample_image_by_name.get(
                        product.name.casefold(),
                        sample_products[(index - 1) % len(sample_products)]["image_url"],
                    )

        existing_names = {product.name.casefold() for product in database_products}
        # Avoid showing a demo card twice if it was already added through Django Admin.
        visible_samples = [
            product for product in sample_products
            if product["name"].casefold() not in existing_names
        ]

        if database_products:
            catalog_products = database_products + visible_samples
        else:
            catalog_products = [
                {
                    "name": "Мед різнотрав'я",
                    "description": "Мед із нектару різних польових і садових рослин.",
                    "price": 250,
                    "category": "Натуральний мед",
                    "image_class": "honey",
                },
                *visible_samples,
            ]

        context["products"] = catalog_products
        context.update(
            {
                "active_page": "products",
                "categories": Category.objects.all(),
                "product_data": {
                    "title": "Продукція пасіки",
                    "description": "Знайомтеся з продуктами, які створює бджолина сім'я та дбайлива праця пасічника.",
                    "is_database_content": bool(database_products),
                    "has_sample_products": bool(visible_samples) or not database_products,
                },
            }
        )
        return context


class ProductCategoryView(ListView):
    model = Category
    template_name = "product_categories.html"
    context_object_name = "categories"

    def get_queryset(self):
        return Category.objects.filter(parent__isnull=True).prefetch_related("children")

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        categories = context["categories"]
        if categories:
            context["categories"] = [
                {
                    "name": category.name,
                    "description": category.description,
                    "children": [child.name for child in category.children.all()],
                }
                for category in categories
            ]
        else:
            context["categories"] = [
                {"name": "Натуральний мед", "description": "Мед із різнотрав'я та сезонних медоносів.", "children": ["Різнотрав'я", "Весняний мед"]},
                {"name": "Продукти бджільництва", "description": "Інші продукти, які отримують на пасіці.", "children": ["Пилок", "Віск"]},
                {"name": "Подарункові набори", "description": "Невеликі набори для знайомства з продукцією.", "children": ["Набір для дегустації"]},
            ]
        context["active_page"] = "products"
        return context


class ProductDetailView(DetailView):
    model = Product
    template_name = "product_detail.html"
    context_object_name = "product"

    def get(self, request, *args, **kwargs):
        try:
            return super().get(request, *args, **kwargs)
        except Http404:
            return render(request, "404.html", status=404)

    def get_queryset(self):
        return Product.objects.select_related("category")

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context["active_page"] = "products"
        return context


class ApiaryListView(ListView):
    model = Apiary
    template_name = "apiaries.html"
    context_object_name = "apiaries"

    def get_queryset(self):
        return Apiary.objects.all()

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        if not context["apiaries"]:
            context["apiaries"] = [
                ApiaryCard("Пасіка ROGER HONEY", "Одеська область", "Невелика пасіка для щоденних спостережень, сезонної роботи та уважного догляду за бджолиними сім'ями.", 7),
            ]
        context.update(
            {
                "active_page": "apiaries",
                "apiary_data": {
                    "title": "Наші пасіки",
                    "description": "Кожна пасіка має власні умови, сезонні особливості та щоденну історію.",
                    "is_database_content": Apiary.objects.exists(),
                },
            }
        )
        return context


class NewsListView(ListView):
    model = Article
    template_name = "news.html"
    context_object_name = "news_items"

    def get_queryset(self):
        return Article.objects.filter(is_published=True)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        articles = context["news_items"]
        if articles:
            context["news_items"] = [
                NewsCard(
                    f"{index:02d}",
                    "НОТАТКА З ПАСІКИ",
                    "СТАТТЯ",
                    article.title,
                    article.excerpt,
                    article.slug,
                )
                for index, article in enumerate(articles, start=1)
            ]
        else:
            context["news_items"] = [
                NewsCard("01", "СЕЗОННІСТЬ", "ВЕСНА", "Перші теплі дні на пасіці", "Після зимового спокою починається новий природний цикл. Бджоли поступово повертаються до активного життя.", "first-warm-days"),
                NewsCard("02", "СПОСТЕРЕЖЕННЯ", "БДЖОЛИ", "Життя всередині вулика", "Як організована бджолина сім'я, чим займаються робочі бджоли та чому кожна з них важлива.", "life-inside-the-hive"),
                NewsCard("03", "ПРОДУКТИ ПАСІКИ", "МЕД", "Від квітки до меду", "Нектар, бджоли, стільники та щоденна робота пасічника — історія знайомого золотого продукту.", "from-flower-to-honey"),
            ]
        context.update(
            {
                "active_page": "news",
                "journal_data": {"items": context["news_items"], "count": len(context["news_items"])},
            }
        )
        return context
