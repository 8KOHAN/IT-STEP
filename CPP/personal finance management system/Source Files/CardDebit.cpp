#include "CardDebit.h"

CardDebit::CardDebit(const std::string& name, char currency) noexcept : name_(name), amountMoney_(0.), currency_(currency){ }

const std::string CardDebit::name() const noexcept {
	return name_;
}

const char CardDebit::currency() const noexcept {
	return currency_;
}

void CardDebit::setName(const std::string& newName) noexcept {
	name_ = newName;
}

void CardDebit::replenishment(const double sum) noexcept {
	if (sum <= 0) return;
	amountMoney_ += sum;
}

void CardDebit::spend(const double sum) noexcept {
	if ((amountMoney_ - sum) < 0) return;
	amountMoney_ -= sum;
}

const double CardDebit::quantity() const noexcept {
	return amountMoney_;
}
