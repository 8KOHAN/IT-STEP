#pragma once
#include "CardDebit.h"

class CardCredit : public CardDebit
{
public:
	CardCredit(const std::string& name) noexcept;

	const double checkCredit() const noexcept;
	void spend(const double sum) noexcept override;
	void takeСredit(const double sum) noexcept;
	void returnCredit(const double sum) noexcept;
private:
	double duty_;
};
