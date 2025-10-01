#include "ExpenseTracker.h"

ExpenseTracker::ExpenseTracker(std::string fileName) noexcept : fileName_(fileName) {}

void ExpenseTracker::nextDay() noexcept {
    if (expenses.size() == maxSize) {
        expenses.erase(expenses.begin());
    }
    expenses.push_back({});
}


void ExpenseTracker::addExpense(double sum, char currency, std::string message) noexcept {
    if (expenses.empty()) {
        nextDay();
    }
    expenses.back().push_back(Expense(message, sum, currency));
}

void ExpenseTracker::expensesForDay() noexcept {
    if (expenses.empty()) {
        std::cout << "еще не прошел день с того момента как вы начали нас использовать" << std::endl;
        return;
    }
    if (expenses.back().empty()) {
        std::cout << "за последний день небыло покупок\n" << std::endl;
        return;
    }
    std::cout << "траты за последний день" << std::endl;
    for (int i = 0; i < expenses.back().size(); ++i) {
        expenses.back()[i].print();
    }
}

void ExpenseTracker::expensesForWeek() noexcept {
    if (expenses.size() < 7) {
        std::cout << "еще не прошла неделя с того момента как вы начали нас использовать" << std::endl;
        return;
    }
    std::cout << "траты за последнию неделю" << std::endl;
    for (int i = expenses.size() - 7; i < expenses.size(); ++i) {
        std::cout << "день номер " << i + 1 << std::endl;
        for (int y = 0; y < expenses[i].size(); ++y)
            expenses[i][y].print();
    }
}

void ExpenseTracker::expensesForMonth() noexcept {
    if (expenses.size() < 31) {
        std::cout << "еще не прошел месяц с того момента как вы начали нас использовать" << std::endl;
        return;
    }
    std::cout << "траты за последний месяц" << std::endl;
    for (int i = 0; i < expenses.size(); ++i) {
        std::cout << "день номер " << i + 1 << std::endl;
        for (int y = 0; y < expenses[i].size(); ++y)
            expenses[i][y].print();
    }
}

void ExpenseTracker::topSpendingThisWeek() noexcept {
    if (expenses.size() < 7) {
        std::cout << "еще не прошла неделя с того момента как вы начали нас использовать" << std::endl;
        return;
    }
    std::cout << "топ 3 траты за последнию неделю" << std::endl;
    std::vector<Expense> topExpenses;
    for (int i = expenses.size() - 7; i < expenses.size(); ++i) {
        for (const auto& e : expenses[i]) {
            if (topExpenses.size() < 3) {
                topExpenses.push_back(e);
            }
            else {
                auto min = std::min_element(
                    topExpenses.begin(), topExpenses.end(),
                    [](const Expense& a, const Expense& b) {
                        return a.sum() < b.sum();
                    });
                if (e.sum() > min->sum()) {
                    *min = e;
                }
            }
        }
    }
    std::ofstream file(fileName_, std::ios::app);
    file << "топ 3 траты за последнию неделю\n";
    for (int i = 0; i < topExpenses.size(); ++i) {
        topExpenses[i].print();
        topExpenses[i].writeToFile(file);
        std::cout << std::endl;
    }   
}

void ExpenseTracker::topSpendingThisMonth() noexcept {
    if (expenses.size() < 31) {
        std::cout << "еще не прошел месяц с того момента как вы начали нас использовать" << std::endl;
        return;
    }
    std::cout << "топ 3 траты за последний месяц" << std::endl;
    std::vector<Expense> topExpenses;
    for (int i = 0; i < expenses.size(); ++i) {
        for (const auto& e : expenses[i]) {
            if (topExpenses.size() < 3) {
                topExpenses.push_back(e);
            }
            else {
                auto min = std::min_element(
                    topExpenses.begin(), topExpenses.end(),
                    [](const Expense& a, const Expense& b) {
                        return a.sum() < b.sum();
                    });
                if (e.sum() > min->sum()) {
                    *min = e;
                }
            }
        }
    }
    std::ofstream file(fileName_, std::ios::app);
    file << "топ 3 траты за последний месяц\n";
    for (int i = 0; i < topExpenses.size(); ++i) {
        topExpenses[i].print();
        topExpenses[i].writeToFile(file);
        std::cout << std::endl;
    }
}
