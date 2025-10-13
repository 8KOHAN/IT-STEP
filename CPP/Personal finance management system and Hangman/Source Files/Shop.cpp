#include "Shop.h"

Shop::Shop(std::string fileName) noexcept : fileName_(fileName), day_(1), expenseTracker_("Top Spending.txt") {}

void Shop::printProducts(const char currency) const noexcept {
    std::cout << "--МАГАЗИН--\n\n";
    std::cout << "1 - PS5 + Hangman  PRICE  - " << sumProduct(1, currency) << currency << " (вналичие " << inStockProducts_.ps5       << " экземпляра)" << std::endl;
    std::cout << "2 - Kettle         PRICE  - " << sumProduct(2, currency) << currency << " (вналичие " << inStockProducts_.kettle    << " экземпляра)" << std::endl;
    std::cout << "3 - Battery        PRICE  - " << sumProduct(3, currency) << currency << " (вналичие " << inStockProducts_.battery   << " экземпляра)" << std::endl;
    std::cout << "4 - Cigarette      PRICE  - " << sumProduct(4, currency) << currency << " (вналичие " << inStockProducts_.cigarette << " экземпляра)" << std::endl;
    std::cout << "5 - Snickers       PRICE  - " << sumProduct(5, currency) << currency << " (вналичие " << inStockProducts_.snickers  << " экземпляра)" << std::endl;
    std::cout << "6 - Propolis       PRICE  - " << sumProduct(6, currency) << currency << " (вналичие " << inStockProducts_.propolis  << " экземпляра)" << std::endl;
    std::cout << "7 - House          PRICE  - " << sumProduct(7, currency) << currency << " (вналичие " << inStockProducts_.house     << " экземпляра)" << std::endl;
    std::cout << "8 - Keyboard       PRICE  - " << sumProduct(8, currency) << currency << " (вналичие " << inStockProducts_.keyboard  << " экземпляра)" << std::endl;
    std::cout << "9 - Flower         PRICE  - " << sumProduct(9, currency) << currency << " (вналичие " << inStockProducts_.flower    << " экземпляра)" << std::endl;
}

void Shop::buy(std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard) noexcept {
    printProducts((Debit_or_Credit == 'D' ? purses[numPurse].currencyCardD(numCard) : purses[numPurse].currencyCardC(numCard)));
    std::cout << "Enter the number of the product you want to buy - " << std::endl;
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
            spendingHistory_ += "Day - " + std::to_string(day_) + " PS5 was purchased for " + std::to_string(sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(1, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a PS5");
        }
        break;
    case 2:
        if (!checkProductAvailability(inStockProducts_.kettle)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.kettle;
            --inStockProducts_.kettle;
            amountExpenses_ += sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " the kettle was bought for " + std::to_string(sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(2, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a kettle");
        }
        break;
    case 3:
        if (!checkProductAvailability(inStockProducts_.battery)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.battery;
            --inStockProducts_.battery;
            amountExpenses_ += sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " a battery was purchased for " + std::to_string(sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(3, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a battery");
        }
        break;
    case 4:
        if (!checkProductAvailability(inStockProducts_.cigarette)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.cigarette;
            --inStockProducts_.cigarette;
            amountExpenses_ += sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " a cigarette was bought for " + std::to_string(sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(4, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a cigarette");
        }
        break;
    case 5:
        if (!checkProductAvailability(inStockProducts_.snickers)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.snickers;
            --inStockProducts_.snickers;
            amountExpenses_ += sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " a snickers bar was bought for " + std::to_string(sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(5, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "Snickers bought");
        }
        break;
    case 6:
        if(!checkProductAvailability(inStockProducts_.propolis)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.propolis;
            --inStockProducts_.propolis;
            amountExpenses_ += sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " the propolis was bought for " + std::to_string(sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(6, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "the propolis was bought");
        }
        break;
    case 7:
        if (!checkProductAvailability(inStockProducts_.house)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.house;
            --inStockProducts_.house;
            amountExpenses_ += sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " the house was bought for " + std::to_string(sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(7, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a house");
        }
        break;
    case 8:
        if (!checkProductAvailability(inStockProducts_.keyboard)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.keyboard;
            --inStockProducts_.keyboard;
            amountExpenses_ += sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " The keyboard was purchased for " + std::to_string(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a keyboard");
        }
        break;
    case 9:
        if (!checkProductAvailability(inStockProducts_.flower)) break;
        spendSum(purses, numPurse, Debit_or_Credit, numCard, sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)));
        if ((Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard) != oldSum)) {
            ++amountProducts_.flower;
            --inStockProducts_.flower;
            amountExpenses_ += sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard));
            spendingHistory_ += "Day - " + std::to_string(day_) + " the flower was bought for " + std::to_string(sumProduct(9, checkCurrency(purses, numPurse, Debit_or_Credit, numCard))) + checkCurrency(purses, numPurse, Debit_or_Credit, numCard) + '\n';
            expenseTracker_.addExpense(sumProduct(8, checkCurrency(purses, numPurse, Debit_or_Credit, numCard)), checkCurrency(purses, numPurse, Debit_or_Credit, numCard), "bought a flower");
        }
        break;
    }
}

void Shop::spendingHistory() noexcept {
    bool isOpen = true;
    while (isOpen) {
        std::cout << "Enter the number of the spending history you want to view\n1 - Daily spending history\n2 - Weekly spending history\n3 - Monthly spending history\n0 - Exit" << std::endl;
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
        std::cout << "Enter the number of the top purchase history you want to view\n1 - Weekly top purchases\n2 - Monthly top purchases\n0 - Exit." << std::endl;
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

bool Shop::checkHangman() const noexcept {
    return amountProducts_.ps5 > 0;
}

void Shop::nextDay() noexcept {
    ++day_;
    expenseTracker_.nextDay();
}

void Shop::saveToFile() const noexcept {
    std::ofstream file(fileName_, std::ios::out);
    if (!file) {
        std::cerr << "Error opening file for writing!" << std::endl;
        return;
    }
    file << spendingHistory_;
}
