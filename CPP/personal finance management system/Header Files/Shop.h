#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "purse.h"
#include "functions.h"
#include "Products.h"

class Shop
{
public:
	Shop(std::string fileName, int& day);

	void printProducts(char currency) const;

	void buy(std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard);

	void statisticsDay();
	void statisticsWeek();
	void statisticsMonth();

	void topSpendingThisWeek();
	void topSpendingThisMonth();

private:
	std::string spendingHistory_ = "";
	std::string fileName_;
	AmountProducts amountProducts_;
	InStockProducts inStockProducts_;
	double amountExpenses_ = 0;
	int& day_;

	void saveToFile();

};

