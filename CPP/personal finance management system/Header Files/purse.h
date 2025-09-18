#include <iostream>
#include <string>

class Purse 
{
public:
	Purse(std::string name);

	const std::string Name();
	size_t SizeCardsDebit();
	size_t SizeCardsCredit();

	void SetName(std::string NewName);
	void SetCardDebit(std::string NewName);
	void SetCardCredit(std::string NewName);

	void AddCardDebit(std::string Name);
	void AddCardCredit(std::string Name);

private:
	std::string name_;
	//добавить масивы для cards_debit_ и cards_credit_
	size_t number_cards_debit_;
	size_t number_cards_credit_;
};

