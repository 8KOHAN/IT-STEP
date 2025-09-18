#pragma once
#include "CardDebit.h"

class CardCredit : public CardDebit
{
public:
	CardCredit(std::string name);

	void spend(double num);
	void TakeСredit(double num);
	void ReturnCredit(double num);
	bool CheckCredit();
};
