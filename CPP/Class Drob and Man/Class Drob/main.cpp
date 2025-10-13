#include "Drob.h"
#include <windows.h>

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    Drob a, b;
    std::cout << "Fraction A:\n";
    a.input();
    std::cout << "Fraction B:\n";
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
