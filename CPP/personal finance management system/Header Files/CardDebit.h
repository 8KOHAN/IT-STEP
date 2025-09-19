#pragma once
#include <iostream>
#include <string>

class CardDebit
{
public:
	CardDebit(std::string name);

	const double quantity() const;
	void replenishment(double sum);
	void spend(double sum);

protected:
	std::string name_;
	double AmountMoney_;
};
