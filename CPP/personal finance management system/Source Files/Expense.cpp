#include "Expense.h"

Expense::Expense(std::string message, double sum, char currency) noexcept : message_(message), sum_(sum), currency_(currency) {}

void Expense::print() noexcept {
    std::cout << message_ << " за : " << sum_ << currency_ << std::endl;
}

void Expense::writeToFile(std::ofstream& file) noexcept {
    if (!file.is_open()) {
        std::cout << "Файл не открыт для записи!" << std::endl;
    }
    file << message_ << " за: " << sum_ << " " << currency_ << std::endl;
}

const double Expense::sum() const noexcept {
    return sum_;
}
