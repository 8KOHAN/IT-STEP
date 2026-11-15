from django.test import TestCase
from django.urls import reverse


class CompanyPageTests(TestCase):
    def test_home_page_renders(self):
        response = self.client.get(reverse("home"))
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, "ROGER HONEY")

    def test_all_required_subsections_render(self):
        route_names = (
            "about-history",
            "about-team",
            "product-categories",
            "news-education",
        )
        for route_name in route_names:
            with self.subTest(route=route_name):
                response = self.client.get(reverse(route_name))
                self.assertEqual(response.status_code, 200)

    def test_unknown_section_returns_custom_404(self):
        response = self.client.get("/this-section-does-not-exist/")
        self.assertEqual(response.status_code, 404)
        self.assertContains(response, "Сторінку", status_code=404)
