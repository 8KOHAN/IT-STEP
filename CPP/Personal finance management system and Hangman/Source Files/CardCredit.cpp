#include "CardCredit.h"

CardCredit::CardCredit(const std::string& name, char currency) noexcept : CardDebit(name, currency), duty_(0.) {}

const double CardCredit::checkCredit() const noexcept { return duty_; }

void CardCredit::spend(const double sum) noexcept {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "you're missing: " << (amountMoney_ - sum) / -1 <<std::endl;
		std::cout << "want to take out a loan?\nyes/not\n";
		std::string answer;
		std::cout << "your choice: ";
		do {
			std::cin >> answer;
		} while (!(answer == "yes" && answer == "not"));

		if (answer == "yes") {
			std::cout << "enter the loan amount - ";
			double sum;
			do {
				if (std::cin >> sum) break;
			} while (true);
			takeСredit(sum);
		}

		return;
	}
	amountMoney_ -= sum;
}

void CardCredit::takeСredit(const double sum) noexcept {
	amountMoney_ += sum;
	duty_ += sum;
}

void CardCredit::returnCredit(const double sum) noexcept {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "failed to repay the loan" << std::endl;
		return;
	}
	if ((duty_ - sum) < 0) {
		std::cout << "The amount entered is too large, you need to return it " << duty_ << std::endl;
		return;
	}
	amountMoney_ -= sum;
	duty_ -= sum;
}
