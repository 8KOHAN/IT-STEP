#include <iostream>
#include <windows.h>
#include "Pet.h"

int main() {
    SetConsoleOutputCP(1251);

    Dog dog("Рекс", 5, "коричневий");
    Cat cat("Мурка", 3, "сіра");
    Parrot parrot("Кеша", 2, "зелений");

    dog.displayInfo();
    cat.displayInfo();
    parrot.displayInfo();

    return 0;
}
