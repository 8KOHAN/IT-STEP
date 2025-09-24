#pragma once
#include <iostream>
#include <string>

class CardDebit
{
public:
	CardDebit(const std::string& name);

	const std::string name();
	void setName(const std::string& newName);

	void replenishment(const double sum);
	void spend(const double sum);
	const double quantity() const;

protected:
	std::string name_;
	double amountMoney_;
};
