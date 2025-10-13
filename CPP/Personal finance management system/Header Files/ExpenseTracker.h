#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include "Expense.h"

class ExpenseTracker 
{
public:
    ExpenseTracker(std::string fileName) noexcept;

    void nextDay() noexcept;

    void addExpense(double sum, char currency, std::string message = "") noexcept;

    void expensesForDay() noexcept;
    void expensesForWeek() noexcept;
    void expensesForMonth() noexcept;

    void topSpendingThisWeek() noexcept;
    void topSpendingThisMonth() noexcept;
private:
    std::vector<std::vector<Expense>> expenses;
    std::string fileName_;
    int maxSize = 31;
};
