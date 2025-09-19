#pragma once
#include "CardDebit.h"

class CardCredit : public CardDebit
{
public:
	CardCredit(std::string name);

	const double CheckCredit();
	void spend(double sum);
	void TakeСredit(double sum);
	void ReturnCredit(double sum);
private:
	double duty_;
};
