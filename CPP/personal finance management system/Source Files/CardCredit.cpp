#include "CardCredit.h"

CardCredit::CardCredit(std::string name) : CardDebit(name), duty_(0.) {}

const double CardCredit::CheckCredit() { return duty_; }

void CardCredit::spend(double sum) {
	if ((AmountMoney_ - sum) < 0) {
		std::cout << "вам не хватает: " << (AmountMoney_ - sum) / -1 <<std::endl;
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
			TakeСredit(sum);
		}

		return;
	}
	AmountMoney_ -= sum;
}

void CardCredit::TakeСredit(double sum) {
	AmountMoney_ += sum;
	duty_ += sum;
}

void CardCredit::ReturnCredit(double sum) {
	if ((AmountMoney_ - sum) < 0) {
		std::cout << "не удалось погасить кредит" << std::endl;
		return;
	}
	AmountMoney_ -= sum;
	duty_ -= sum;
}
