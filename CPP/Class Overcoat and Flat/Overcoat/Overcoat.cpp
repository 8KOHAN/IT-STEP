#include "Overcoat.h"

Overcoat::Overcoat(std::string t, double p) : type(t), price(p) {}

bool Overcoat::operator==(const Overcoat& other) const {
    return type == other.type;
}

Overcoat& Overcoat::operator=(const Overcoat& other) {
    if (this != &other) {
        type = other.type;
        price = other.price;
    }
    return *this;
}

bool Overcoat::operator>(const Overcoat& other) const {
    return (type == other.type) && (price > other.price);
}

void Overcoat::display() const {
    std::cout << "Тип: " << type << ", Ціна: " << price << std::endl;
}

