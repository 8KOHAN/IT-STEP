from django.core.validators import MaxValueValidator, MinValueValidator
from django.db import models


class Category(models.Model):
    name = models.CharField(max_length=100, verbose_name="Назва")
    slug = models.SlugField(max_length=100, unique=True, verbose_name="URL-адреса")
    description = models.TextField(verbose_name="Опис")
    parent = models.ForeignKey(
        "self",
        on_delete=models.SET_NULL,
        null=True,
        blank=True,
        related_name="children",
        verbose_name="Батьківська категорія",
    )

    class Meta:
        ordering = ("name",)
        verbose_name = "Категорія"
        verbose_name_plural = "Категорії"

    def __str__(self):
        return self.name


class Product(models.Model):
    name = models.CharField(max_length=150, verbose_name="Назва")
    description = models.TextField(verbose_name="Опис")
    price = models.DecimalField(max_digits=10, decimal_places=2, verbose_name="Ціна")
    category = models.ForeignKey(
        Category,
        on_delete=models.PROTECT,
        related_name="products",
        verbose_name="Категорія",
    )
    image_url = models.URLField(blank=True, verbose_name="Зображення (URL)")

    class Meta:
        ordering = ("name",)
        verbose_name = "Продукт"
        verbose_name_plural = "Продукти"

    def __str__(self):
        return self.name


class Apiary(models.Model):
    name = models.CharField(max_length=120, verbose_name="Назва пасіки")
    location = models.CharField(max_length=180, verbose_name="Розташування")
    description = models.TextField(verbose_name="Опис")
    hive_count = models.PositiveIntegerField(default=0, verbose_name="Кількість вуликів")
    established_year = models.PositiveSmallIntegerField(null=True, blank=True, verbose_name="Рік заснування")

    class Meta:
        ordering = ("name",)
        verbose_name = "Пасіка"
        verbose_name_plural = "Пасіки"

    def __str__(self):
        return self.name


class Article(models.Model):
    title = models.CharField(max_length=180, verbose_name="Заголовок")
    slug = models.SlugField(max_length=180, unique=True, verbose_name="URL-адреса")
    excerpt = models.CharField(max_length=280, verbose_name="Короткий опис")
    content = models.TextField(verbose_name="Текст")
    is_published = models.BooleanField(default=True, verbose_name="Опубліковано")

    class Meta:
        ordering = ("title",)
        verbose_name = "Стаття"
        verbose_name_plural = "Статті"

    def __str__(self):
        return self.title


class Review(models.Model):
    author_name = models.CharField(max_length=100, verbose_name="Ім'я автора")
    text = models.TextField(verbose_name="Відгук")
    rating = models.PositiveSmallIntegerField(
        default=5,
        validators=[MinValueValidator(1), MaxValueValidator(5)],
        verbose_name="Оцінка",
    )
    is_published = models.BooleanField(default=False, verbose_name="Опубліковано")
    created_at = models.DateTimeField(auto_now_add=True, verbose_name="Дата створення")

    class Meta:
        ordering = ("-created_at",)
        verbose_name = "Відгук"
        verbose_name_plural = "Відгуки"

    def __str__(self):
        return f"{self.author_name} — {self.rating}/5"
