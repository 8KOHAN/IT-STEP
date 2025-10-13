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

	const double amountMoneyCardD(int index) const noexcept;
	const double amountMoneyCardC(int index) const noexcept;

	const char currencyCardD(int index) const noexcept;
	const char currencyCardC(int index) const noexcept;

	void replenishmentCardD(double sum, int index) noexcept;
	void replenishmentCardC(double sum, int index) noexcept;

	void spendCardD(double sum, int index) noexcept;
	void spendCardC(double sum, int index) noexcept;

	double checkCredit(int index) noexcept;
	void takeСredit(double sum, int index) noexcept;
	void returnCredit(double sum, int index) noexcept;

	void setName(const std::string& newName) noexcept;

	void addCardD(const std::string& name, char currency = '$') noexcept;
	void addCardC(const std::string& name, char currency = '$') noexcept;

	void printCardsD() const noexcept;
	void printCardsC() const noexcept;
private:
	std::string name_;
	std::vector<CardDebit> cardsD_;
	std::vector<CardCredit> cardsC_;
	size_t amountCardsD_;
	size_t amountCardsC_;
};
