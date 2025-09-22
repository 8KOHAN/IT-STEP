#include "CardDebit.h"

CardDebit::CardDebit(std::string name) : name_(name), amountMoney_(0.) { }

const std::string CardDebit::name() {
	return name_;
}

void CardDebit::setName(const std::string newName) {
	name_ = newName;
}

void CardDebit::replenishment(const double sum) {
	if (sum <= 0) return;
	amountMoney_ += sum;
}

void CardDebit::spend(const double sum) {
	if ((amountMoney_ - sum) < 0) return;
	amountMoney_ -= sum;
}

const double CardDebit::quantity() const {
	return amountMoney_;
}
