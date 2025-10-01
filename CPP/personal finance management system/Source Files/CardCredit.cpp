#include "CardCredit.h"

CardCredit::CardCredit(const std::string& name, char currency) noexcept : CardDebit(name, currency), duty_(0.) {}

const double CardCredit::checkCredit() const noexcept { return duty_; }

void CardCredit::spend(const double sum) noexcept {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "вам не хватает: " << (amountMoney_ - sum) / -1 <<std::endl;
		std::cout << "хотите взять кредит?\nyes/not\n";
		std::string answer;
		std::cout << "ваш выбор: ";
		do {
			std::cin >> answer;
		} while (!(answer == "yes" && answer == "not"));

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

void CardCredit::takeСredit(const double sum) noexcept {
	amountMoney_ += sum;
	duty_ += sum;
}

void CardCredit::returnCredit(const double sum) noexcept {
	if ((amountMoney_ - sum) < 0) {
		std::cout << "не удалось погасить кредит" << std::endl;
		return;
	}
	if ((duty_ - sum) < 0) {
		std::cout << "введина слишком большая сума, ван нужно вернуть " << duty_ << std::endl;
		return;
	}
	amountMoney_ -= sum;
	duty_ -= sum;
}
