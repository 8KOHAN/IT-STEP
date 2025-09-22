#include <vector>
#include "CardDebit.h"
#include "CardCredit.h"

class Purse
{
public:
	Purse(const std::string name);

	const std::string name() const;
	const size_t amountCardsD() const;
	const size_t amountCardsC() const;

	void setName(const std::string newName);

	void addCardD(const std::string name);
	void addCardC(const std::string name);

private:
	std::string name_;
	std::vector<CardDebit> cardsD_;
	std::vector<CardCredit> cardsC_;
	size_t amountCardsD_;
	size_t amountCardsC_;
};
