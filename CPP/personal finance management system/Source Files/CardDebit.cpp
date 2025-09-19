#include "CardDebit.h"

CardDebit::CardDebit(std::string name) : name_(name), AmountMoney_(0.) { }

const double CardDebit::quantity() const {
	return AmountMoney_;
}

void CardDebit::replenishment(double sum) {
	if (sum <= 0) return;
	AmountMoney_ += sum;
}

void CardDebit::spend(double sum) {
	if ((AmountMoney_ - sum) < 0) return;
	AmountMoney_ -= sum;
}
