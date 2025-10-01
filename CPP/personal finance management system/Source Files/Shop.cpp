#include "Shop.h"

Shop::Shop(std::string fileName) noexcept : fileName_(fileName), day_(1), expenseTracker_("Top Spending.txt") {}

void Shop::printProducts(const char currency) const noexcept {
    std::cout << "--МАГАЗИН--\n\n";
    std::cout << "1 - ps5 + Gallows  ЦЕНА  - " << sumProduct(1, currency) << currency << " (вналичие " << inStockProducts_.ps5       << " экземпляра)" << std::endl;
    std::cout << "2 - чайник         ЦЕНА  - " << sumProduct(2, currency) << currency << " (вналичие " << inStockProducts_.kettle    << " экземпляра)" << std::endl;
    std::cout << "3 - Батарейка      ЦЕНА  - " << sumProduct(3, currency) << currency << " (вналичие " << inStockProducts_.battery   << " экземпляра)" << std::endl;
    std::cout << "4 - сигарета       ЦЕНА  - " << sumProduct(4, currency) << currency << " (вналичие " << inStockProducts_.cigarette << " экземпляра)" << std::endl;
    std::cout << "5 - сникерс        ЦЕНА  - " << sumProduct(5, currency) << currency << " (вналичие " << inStockProducts_.snickers  << " экземпляра)" << std::endl;
    std::cout << "6 - прополес       ЦЕНА  - " << sumProduct(6, currency) << currency << " (вналичие " << inStockProducts_.propolis  << " экземпляра)" << std::endl;
    std::cout << "7 - дом            ЦЕНА  - " << sumProduct(7, currency) << currency << " (вналичие " << inStockProducts_.house     << " экземпляра)" << std::endl;
    std::cout << "8 - клавиатуру     ЦЕНА  - " << sumProduct(8, currency) << currency << " (вналичие " << inStockProducts_.keyboard  << " экземпляра)" << std::endl;
    std::cout << "9 - цветок         ЦЕНА  - " << sumProduct(9, currency) << currency << " (вналичие " << inStockProducts_.flower    << " экземпляра)" << std::endl;
}

void Shop::buy(std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard) noexcept {
    printProducts((Debit_or_Credit == 'D' ? purses[numPurse].currencyCardD(numCard) : purses[numPurse].currencyCardC(numCard)));
    std::cout << "введите номер товара который вы хотите купить - " << std::endl;
    int choice;
    choice = inputNum(1, 9);
    double oldSum = (Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard));
    switch (choice)
    {
    case 1:
        if (!checkProductAvailability(inStockProducts_.ps5)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.ps5;
            --inStockProducts_.ps5;
            amountExpenses_ += sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " была куплена ps5 за " + std::to_string(sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплена ps5");
        }
        break;
    case 2:
        if (!checkProductAvailability(inStockProducts_.kettle)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.kettle;
            --inStockProducts_.kettle;
            amountExpenses_ += sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " был куплен чайник за " + std::to_string(sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплен чайник");
        }
        break;
    case 3:
        if (!checkProductAvailability(inStockProducts_.battery)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.battery;
            --inStockProducts_.battery;
            amountExpenses_ += sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " была куплена батарейка за " + std::to_string(sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплена батарейка");
        }
        break;
    case 4:
        if (!checkProductAvailability(inStockProducts_.cigarette)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.cigarette;
            --inStockProducts_.cigarette;
            amountExpenses_ += sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " была куплена сигарета за " + std::to_string(sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплена сигарета");
        }
        break;
    case 5:
        if (!checkProductAvailability(inStockProducts_.snickers)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.snickers;
            --inStockProducts_.snickers;
            amountExpenses_ += sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " был куплен сникерс за " + std::to_string(sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплен сникерс");
        }
        break;
    case 6:
        if(!checkProductAvailability(inStockProducts_.propolis)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.propolis;
            --inStockProducts_.propolis;
            amountExpenses_ += sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " был куплен праполес за " + std::to_string(sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплен праполес");
        }
        break;
    case 7:
        if (!checkProductAvailability(inStockProducts_.house)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.house;
            --inStockProducts_.house;
            amountExpenses_ += sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " был куплен дом за " + std::to_string(sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплен дом");
        }
        break;
    case 8:
        if (!checkProductAvailability(inStockProducts_.keyboard)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.keyboard;
            --inStockProducts_.keyboard;
            amountExpenses_ += sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " была куплена клавиатура за " + std::to_string(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплена клавиатура");
        }
        break;
    case 9:
        if (!checkProductAvailability(inStockProducts_.flower)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.flower;
            --inStockProducts_.flower;
            amountExpenses_ += sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "день - " + std::to_string(day_) + " был куплен цветок за " + std::to_string(sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "куплен цветок");
        }
        break;
    }
}

void Shop::spendingHistory() noexcept {
    bool isOpen = true;
    while (isOpen) {
        std::cout << "введите номер истории трат которую вы хотите посмотреть\n1 - дневная история трат\n2 - недельная история трат\n3 - месячная история трат\n0 - выход" << std::endl;
        int choice = inputNum(0, 3);
        switch (choice)
        {
        case 0:
            isOpen = false;
            break;
        case 1:
            expenseTracker_.expensesForDay();
            break;
        case 2:
            expenseTracker_.expensesForWeek();
            break;
        case 3:
            expenseTracker_.expensesForMonth();
            break;
        }
    }
}

void Shop::topSpending() noexcept {
    bool isOpen = true;
    while (isOpen) {
        std::cout << "введите номер истории топ покупки которую вы хотите посмотреть\n1 - недельные топ покупки\n2 - месячные топ покупки\n0 - выход" << std::endl;
        int choice = inputNum(0, 2);
        switch (choice)
        {
        case 0:
            isOpen = false;
            break;
        case 1:
            expenseTracker_.topSpendingThisWeek();
            break;
        case 2:
            expenseTracker_.topSpendingThisMonth();
            break;
        }
    }
}

bool Shop::checkGallows() noexcept {
    return amountProducts_.ps5 > 0;
}

void Shop::nextDay() noexcept {
    ++day_;
    expenseTracker_.nextDay();
}

void Shop::saveToFile() noexcept {
    std::ofstream file(fileName_, std::ios::out);
    if (!file) {
        std::cerr << "Ошибка открытия файла для записи!" << std::endl;
        return;
    }
    file << spendingHistory_;
}
