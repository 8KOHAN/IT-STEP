#pragma once
#include <iostream>
#include <string>
#include <vector>

class Expense {
public:
    Expense(std::string message, double sum, char currency);
    void print();
private:
    std::string message_;
    double sum_;
    char currency_;
};

class ExpenseTracker {
public:
    ExpenseTracker();

    void nextDay();

    void addExpense(double sum, char currency, std::string message = "");

    void expensesForDay();
    void expensesForWeek();
    void expensesForMonth();
private:
    std::vector<std::vector<Expense>> expenses;
    int maxSize = 31;
    int index = 0;
};

