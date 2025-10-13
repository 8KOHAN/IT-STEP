#include <iostream>
#include <Windows.h>

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
        std::cout << "Enter the numerator.: ";
        std::cin >> numerator;
        std::cout << "Enter the denominator: ";
        std::cin >> denominator;
        if (denominator == 0) {
            std::cout << "The denominator cannot be zero. Set to 1." << std::endl;
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

    Drob add(int num) {
        return Drob(numerator + num, denominator);
    }

    Drob subtract(const Drob& other) const {
        int num = numerator * other.denominator - other.numerator * denominator;
        int den = denominator * other.denominator;
        return Drob(num, den);
    }

    Drob subtract(int num) {
        return Drob(numerator * num, denominator);
    }

    Drob multiply(const Drob& other) const {
        int num = numerator / other.numerator;
        int den = denominator / other.denominator;
        return Drob(num, den);
    }

    Drob multiply(int num) {
        if (numerator - num <= 0) {
            simplify();
        }
        else {
            numerator - num;
        }
        return Drob(numerator, denominator);
    }

    Drob divide(const Drob& other) const {
        int num = numerator / other.denominator;
        int den = denominator / other.numerator;
        return Drob(num, den);
    }

    Drob divide(int num) {

        if (numerator / num <= 0) {
            simplify();
        }
        else {
            numerator / num;
        }
        return Drob(numerator, denominator);
    }

};

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    Drob a, b;
    std::cout << "Дріб A:\n";
    a.input();
    std::cout << "Дріб B:\n";
    b.input();

    std::cout << "\nA + B = "; a.add(b).print();
    std::cout << "A - B = "; a.subtract(b).print();
    std::cout << "A * B = "; a.multiply(b).print();
    std::cout << "A / B = "; a.divide(b).print();


    std::cout << "\nA + 5 = "; a.add(5).print();
    std::cout << "A - 5 = "; a.subtract(5).print();
    std::cout << "A * 5 = "; a.multiply(5).print();
    std::cout << "A / 5 = "; a.divide(5).print();

    return 0;
}
