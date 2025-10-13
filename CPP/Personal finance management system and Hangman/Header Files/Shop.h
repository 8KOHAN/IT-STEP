#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "Purse.h"
#include "Functions.h"
#include "Products.h"
#include "ExpenseTracker.h"

class Shop
{
public:
	Shop(std::string fileName) noexcept;

	void printProducts(char currency) const noexcept;

	void buy(std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard) noexcept;

	void spendingHistory() noexcept;
	void topSpending() noexcept;

	bool checkHangman() const noexcept;

	void nextDay() noexcept;

	void saveToFile() const noexcept;
private:
	std::string spendingHistory_ = "";
	std::string fileName_;
	AmountProducts amountProducts_;
	InStockProducts inStockProducts_;
	ExpenseTracker expenseTracker_;
	double amountExpenses_ = 0;
	int day_;
};
