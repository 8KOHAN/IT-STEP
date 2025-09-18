#pragma once

#include <iostream>
#include <string>

class CardDebit
{
	CardDebit();

	double quantity();
	void replenishment();
	void virtual spend();

private:
	std::string name;
	double AmountMoney;
};

