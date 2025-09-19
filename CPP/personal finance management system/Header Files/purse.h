#include <vector>
#include "CardDebit.h"
#include "CardCredit.h"

class Purse
{
public:
	Purse(std::string name);

	const std::string name() const;
	const size_t AmountCardsD() const;
	const size_t AmountCardsC() const;

	void SetName(std::string NewName);
	void SetCardD(std::string NewName);
	void SetCardC(std::string NewName);

	void AddCardD(std::string Name);
	void AddCardC(std::string Name);

private:
	std::string name_;
	std::vector<CardDebit> CardsD_;
	std::vector<CardCredit> CardsC_;
	size_t numberCardsD_;
	size_t numberCardsC_;
};
