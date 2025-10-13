#include "Expense.h"

Expense::Expense(std::string message, double sum, char currency) noexcept : message_(message), sum_(sum), currency_(currency) {}

void Expense::print() const noexcept {
    std::cout << message_ << " for : " << sum_ << currency_ << std::endl;
}

void Expense::writeToFile(std::ofstream& file) const noexcept {
    if (!file.is_open()) {
        std::cout << "File not open for writing!" << std::endl;
    }
    file << message_ << " for: " << sum_ << " " << currency_ << std::endl;
}

const double Expense::sum() const noexcept {
    return sum_;
}
