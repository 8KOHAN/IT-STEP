#include <iostream>

class Drob {
private:
    int numerator;
    int denominator;

    int gcd(int a, int b) const {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    void simplify() {
        int g = gcd(abs(numerator), abs(denominator));
        numerator /= g;
        denominator /= g;
        if (denominator < 0) {
            numerator *= -1;
            denominator *= -1;
        }
    }

public:
    Drob(int num = 0, int den = 1) {
        numerator = num;
        denominator = (den == 0) ? 1 : den;
        simplify();
    }

    void input() {
        std::cout << "Введіть чисельник: ";
        std::cin >> numerator;
        std::cout << "Введіть знаменник: ";
        std::cin >> denominator;
        if (denominator == 0) {
            std::cout << "Знаменник не може дорівнювати нулю. Встановлено 1." << std::endl;
            denominator = 1;
        }
        simplify();
    }

    void print() const {
        std::cout << numerator << "/" << denominator << std::endl;
    }

    Drob add(const Drob& other) const {
        int num = numerator * other.denominator + other.numerator * denominator;
        int den = denominator * other.denominator;
        return Drob(num, den);
    }

    Drob subtract(const Drob& other) const {
        int num = numerator * other.denominator - other.numerator * denominator;
        int den = denominator * other.denominator;
        return Drob(num, den);
    }

    Drob multiply(const Drob& other) const {
        int num = numerator * other.numerator;
        int den = denominator * other.denominator;
        return Drob(num, den);
    }

    Drob divide(const Drob& other) const {
        int num = numerator * other.denominator;
        int den = denominator * other.numerator;
        return Drob(num, den);
    }
};

int main() {
    Drob a, b;
    std::cout << "Дріб A:\n";
    a.input();
    std::cout << "Дріб B:\n";
    b.input();

    std::cout << "\nA + B = "; a.add(b).print();
    std::cout << "A - B = "; a.subtract(b).print();
    std::cout << "A * B = "; a.multiply(b).print();
    std::cout << "A / B = "; a.divide(b).print();

    return 0;
}
