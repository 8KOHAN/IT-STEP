#pragma once
#include "CardDebit.h"

class CardCredit : public CardDebit
{
public:
	CardCredit(const std::string& name);

	const double checkCredit() const;
	void spend(const double sum);
	void takeСredit(const double sum);
	void returnCredit(const double sum);
private:
	double duty_;
};
