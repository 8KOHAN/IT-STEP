#include "Shop.h"

Shop::Shop(std::string fileName) : fileName_(fileName){}

void buy(int choice) {
    switch (choice)
    {
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;
    case 4:
        break;
    case 5:
        break;
    case 6:
        break;
    case 7:
        break;
    case 8:
        break;
    case 9:
        break;
    }
}

void Shop::saveToFile() {
    std::ofstream file(fileName_);
    if (!file) {
        std::cerr << "Ошибка открытия файла для записи!" << std::endl;
        return;
    }
    file << spendingHistory_;
    spendingHistory_ = "";
}
