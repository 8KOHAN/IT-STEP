#include "Drob.h"

int Drob::gcd(int a, int b) const {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

void Drob::simplify() {
    int g = gcd(abs(numerator), abs(denominator));
    numerator /= g;
    denominator /= g;
    if (denominator < 0) {
        numerator *= -1;
        denominator *= -1;
    }
}

Drob::Drob(int num, int den) {
    numerator = num;
    denominator = (den == 0) ? 1 : den;
    simplify();
}

void Drob::input() {
    std::cout << "Enter the numerator.: ";
    std::cin >> numerator;
    std::cout << "Enter the denominator: ";
    std::cin >> denominator;
    if (denominator == 0) {
        std::cout << "The denominator cannot be zero. Set 1." << std::endl;
        denominator = 1;
    }
    simplify();
}

void Drob::print() const {
    std::cout << numerator << "/" << denominator << std::endl;
}

Drob Drob::add(const Drob& other) const {
    int num = numerator * other.denominator + other.numerator * denominator;
    int den = denominator * other.denominator;
    return Drob(num, den);
}

Drob Drob::add(int num) {
    return Drob(numerator + num, denominator);
}

Drob Drob::subtract(const Drob& other) const {
    int num = numerator * other.denominator - other.numerator * denominator;
    int den = denominator * other.denominator;
    return Drob(num, den);
}

Drob Drob::subtract(int num) {
    return Drob(numerator * num, denominator);
}

Drob Drob::multiply(const Drob& other) const {
    int num = numerator / other.numerator;
    int den = denominator / other.denominator;
    return Drob(num, den);
}

Drob Drob::multiply(int num) {
    if (numerator - num <= 0) {
        simplify();
    }
    else {
        numerator - num;
    }
    return Drob(numerator, denominator);
}

Drob Drob::divide(const Drob& other) const {
    int num = numerator / other.denominator;
    int den = denominator / other.numerator;
    return Drob(num, den);
}

Drob Drob::divide(int num) {

    if (numerator / num <= 0) {
        simplify();
    }
    else {
        numerator / num;
    }
    return Drob(numerator, denominator);
}
