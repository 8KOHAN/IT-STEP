#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "CardDebit.h"
#include "CardCredit.h"

class Purse
{
public:
	Purse(const std::string& name) noexcept;

	const std::string name() const noexcept;
	const size_t amountCardsD() const noexcept;
	const size_t amountCardsC() const noexcept;

	void setName(const std::string& newName) noexcept;

	void addCardD(const std::string& name) noexcept;
	void addCardC(const std::string& name) noexcept;

	void printCardsD() const noexcept;
	void printCardsC() const noexcept;
private:
	std::string name_;
	std::vector<CardDebit> cardsD_;
	std::vector<CardCredit> cardsC_;
	size_t amountCardsD_;
	size_t amountCardsC_;
};
