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

void Purse::setName(const std::string& newName) noexcept {
	name_ = newName;
}

void Purse::addCardD(const std::string& name) noexcept {
	cardsD_.push_back(name);
	++amountCardsD_;
}

void Purse::addCardC(const std::string& name) noexcept {
	cardsC_.push_back(name);
	++amountCardsC_;
}

void Purse::printCardsD() const noexcept {
	for (int i = 1; i < cardsD_.size(); ++i)
		std::cout  << "карта номер " << i << " - " << cardsD_[i].name() << std::endl;
}

void Purse::printCardsC() const noexcept {
	for (int i = 1; i < cardsC_.size(); ++i)
		std::cout << "карта номер " << i << " - " << cardsC_[i].name() << std::endl;
}
