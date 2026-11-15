from decimal import Decimal, InvalidOperation

from django import template

register = template.Library()


@register.filter(name="format_price")
def format_price(value):
    """Format a numeric value as a Ukrainian hryvnia price."""
    try:
        amount = Decimal(str(value))
    except (InvalidOperation, TypeError, ValueError):
        return value

    formatted = f"{amount:,.2f}".replace(",", " ").replace(".", ",")
    if formatted.endswith(",00"):
        formatted = formatted[:-3]
    return f"{formatted} ₴"
