#include <iostream>
#include <windows.h>

#include "Overcoat.h"
#include "Flat.h"

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    Overcoat coat1("Пуховик", 1500);
    Overcoat coat2("Пуховик", 2000);
    Overcoat coat3("Плащ", 1800);

    std::cout << "Overcoat comparison:" << std::endl;
    coat1.display();
    coat2.display();
    coat3.display();

    std::cout << "\ncoat1 == coat2: " << (coat1 == coat2 ? "Так" : "Ні") << std::endl;
    std::cout << "coat2 > coat1: " << (coat2 > coat1 ? "Так" : "Ні") << std::endl;

    coat3 = coat1;
    std::cout << "coat3 після присвоєння coat1: ";
    coat3.display();

    Flat flat1(60.5, 50000);
    Flat flat2(60.5, 55000);
    Flat flat3(70.0, 60000);

    std::cout << "\nFlat comparison:" << std::endl;
    flat1.display();
    flat2.display();
    flat3.display();

    std::cout << "\nflat1 == flat2: " << (flat1 == flat2 ? "Так" : "Ні") << std::endl;
    std::cout << "flat2 > flat1: " << (flat2 > flat1 ? "Так" : "Ні") << std::endl;

    flat3 = flat1;
    std::cout << "flat3 після присвоєння flat1: ";
    flat3.display();

    return 0;
}
