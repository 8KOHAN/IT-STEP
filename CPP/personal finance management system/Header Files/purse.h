#include <vector>
#include "CardDebit.h"
#include "CardCredit.h"

class Purse
{
public:
	Purse(const std::string& name) noexcept;

	const std::string name() const noexcept;
	const size_t amountCardsD() const noexcept;
	const size_t amountCardsC() const noexcept;

	const double amountMoneyCardD(int index) const;
	const double amountMoneyCardC(int index) const;

	void replenishmentCardD(double sum, int index);
	void replenishmentCardC(double sum, int index);

	void takeСredit(double sum, int index);

	void setName(const std::string& newName) noexcept;

	void addCardD(const std::string& name) noexcept;
	void addCardC(const std::string& name) noexcept;

	void printCardsD() const noexcept;
	void printCardsC() const noexcept;
private:
	std::string name_;
	std::vector<CardDebit> cardsD_;
	std::vector<CardCredit> cardsC_;
	size_t amountCardsD_;
	size_t amountCardsC_;
};
