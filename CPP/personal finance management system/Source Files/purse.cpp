#include "purse.h"

Purse::Purse(std::string name): name_(name) { }

const std::string Purse::name() const{
	return name_;
}

const size_t Purse::AmountCardsD() const{
	return numberCardsD_;
}

const size_t Purse::AmountCardsC() const{
	return numberCardsC_;
}
