#include "Flat.h"

Flat::Flat(double a, double p) : area(a), price(p) {}

bool Flat::operator==(const Flat& other) const {
    return area == other.area;
}

Flat& Flat::operator=(const Flat& other) {
    if (this != &other) {
        area = other.area;
        price = other.price;
    }
    return *this;
}

bool Flat::operator>(const Flat& other) const {
    return price > other.price;
}

void Flat::display() const {
    std::cout << "Area: " << area << " м[2], Price: " << price << std::endl;
}
