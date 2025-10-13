#include <iostream>
#include <windows.h>
#include "Pet.h"

int main() {
    SetConsoleOutputCP(1251);

    Dog dog("Rex", 5, "brown");
    Cat cat("Murka", 3, "gray");
    Parrot parrot("Casha", 2, "green");

    dog.displayInfo();
    cat.displayInfo();
    parrot.displayInfo();

    return 0;
}
