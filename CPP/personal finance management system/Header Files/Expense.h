#pragma once
#include <iostream>
#include <fstream>
#include <string>

class Expense {
public:
    Expense(std::string message, double sum, char currency) noexcept;
    void print() noexcept;
    const double sum() const noexcept;
    void writeToFile(std::ofstream& file) noexcept;
private:
    std::string message_;
    double sum_;
    char currency_;
};
