#include "purse.h"

Purse::Purse(const std::string& name) noexcept : name_(name), amountCardsC_(0), amountCardsD_(0) { }

const std::string Purse::name() const noexcept {
	return name_;
}

const size_t Purse::amountCardsD() const noexcept {
	return amountCardsD_;
}

const size_t Purse::amountCardsC() const noexcept {
	return amountCardsC_;
}

const double Purse::amountMoneyCardD(int index) const noexcept {
	return cardsD_[index].quantity();
}

const double Purse::amountMoneyCardC(int index) const noexcept {
	return cardsC_[index].quantity();
}

const char Purse::currencyCardD(int index) const noexcept {
	return cardsD_[index].currency();
}

const char Purse::currencyCardC(int index) const noexcept {
	return cardsC_[index].currency();
}

void Purse::replenishmentCardD(double sum, int index) noexcept {
	cardsD_[index].replenishment(sum);
}

void Purse::replenishmentCardC(double sum, int index) noexcept {
	cardsC_[index].replenishment(sum);
}

void Purse::spendCardD(const double sum, int index) noexcept {
	cardsD_[index].spend(sum);
}

void Purse::spendCardC(const double sum, int index) noexcept {
	cardsC_[index].spend(sum);
}

double Purse::checkCredit(int index) noexcept {
	return cardsC_[index].checkCredit();
}

void Purse::takeСredit(double sum, int index) noexcept {
	cardsC_[index].takeСredit(sum);
}

void Purse::returnCredit(double sum, int index) noexcept {
	cardsC_[index].returnCredit(sum);
}

void Purse::setName(const std::string& newName) noexcept {
	name_ = newName;
}

void Purse::addCardD(const std::string& name, char currency) noexcept {
	cardsD_.push_back(CardDebit(name, currency));
	++amountCardsD_;
}

void Purse::addCardC(const std::string& name, char currency) noexcept {
	cardsC_.push_back(CardCredit(name, currency));
	++amountCardsC_;
}

void Purse::printCardsD() const noexcept {
	for (int i = 0; i < cardsD_.size(); ++i)
		std::cout  << "card number " << i + 1 << " - " << cardsD_[i].name() << std::endl;
}

void Purse::printCardsC() const noexcept {
	for (int i = 0; i < cardsC_.size(); ++i)
		std::cout << "card number " << i + 1 << " - " << cardsC_[i].name() << std::endl;
}
