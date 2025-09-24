#include "purse.h"

Purse::Purse(const std::string& name): name_(name), amountCardsC_(0), amountCardsD_(0) { }

const std::string Purse::name() const{
	return name_;
}

const size_t Purse::amountCardsD() const{
	return amountCardsD_;
}

const size_t Purse::amountCardsC() const{
	return amountCardsC_;
}

void Purse::setName(const std::string& newName) {
	name_ = newName;
}

void Purse::addCardD(const std::string& name) {
	cardsD_.push_back(name);
	++amountCardsD_;
}

void Purse::addCardC(const std::string& name) {
	cardsC_.push_back(name);
	++amountCardsC_;
}
