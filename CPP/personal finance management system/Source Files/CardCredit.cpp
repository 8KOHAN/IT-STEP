#include "CardCredit.h"

CardCredit::CardCredit(const std::string& name) : CardDebit(name), duty_(0.) {}

const double CardCredit::checkCredit() const { return duty_; }

void CardCredit::spend(const double sum) {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "вам не хватает: " << (amountMoney_ - sum) / -1 <<std::endl;
		std::cout << "хотите взять кредит?\nyes/not";
		std::string answer;
		do {
		std::cin >> answer;
		} while (answer != "yes" || answer != "not");

		if (answer == "yes") {
			std::cout << "введите суму кредита - ";
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

void CardCredit::takeСredit(const double sum) {
	amountMoney_ += sum;
	duty_ += sum;
}

void CardCredit::returnCredit(const double sum) {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "не удалось погасить кредит" << std::endl;
		return;
	}
	amountMoney_ -= sum;
	duty_ -= sum;
}
