#pragma once
#include <iostream>
#include <string>

class CardDebit
{
public:
	CardDebit(const std::string& name, char currency = '$') noexcept;

	const std::string name() const noexcept;
	const char currency() const noexcept;
	void setName(const std::string& newName) noexcept;

	void replenishment(const double sum) noexcept;
	virtual void spend(const double sum) noexcept;
	const double quantity() const noexcept;

protected:
	std::string name_;
	double amountMoney_;
	char currency_;
};
