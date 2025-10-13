#include "Functions.h"

const int inputNum(const int minNum, const int maxNum) {
	bool isOpen = true;
	std::cout << "your choice: ";
	int choice;
	do {
		std::cin >> choice;
		if (choice >= minNum && choice <= maxNum) {
			isOpen = false;
			break;
		}
		std::cout << "re-enter: ";
		std::cin.clear();
		std::cin.ignore(10000, '\n');
	} while (isOpen);
	return choice;
}

const double inputDouble() {
	double sum;
	while (!(std::cin >> sum)) {
		std::cout << "Input error! Try again: ";
		std::cin.clear();
		std::cin.ignore(10000, '\n');
	}
	return sum;
}

void printPurses(const std::vector<Purse>& purses) {
	for (int i = 0; i < purses.size(); ++i)
		std::cout << i + 1 << " - " << purses[i].name() << std::endl;
}

void createPurse(std::vector<Purse>& purses) {
	std::string namePurse;
	std::cout << "enter the name of your new wallet: ";
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, namePurse);
	purses.push_back(Purse(namePurse));
}

const int choicePurse(const std::vector<Purse>& purses) {
	if (purses.empty()) {
		std::cout << "You don't have more than one wallet yet." << std::endl;
		return 0;
	}
	printPurses(purses);
	std::cout << "select wallet number" << std::endl;
	int choice = inputNum(1, purses.size());
	return choice;
}

void setNamePurse(std::vector<Purse>& purses) {
	if (purses.empty()) {
		std::cout << "You don't have more than one wallet yet." << std::endl;
		return;
	}
	printPurses(purses);
	std::cout << "select wallet number" << std::endl;
	int choice = inputNum(1, purses.size());
	std::cout << "enter new name - ";
	std::string newName;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, newName);
	purses[choice].setName(newName);
}

bool checkExit(const int day) {
	if (day < 32) {
		std::cout << "You can't go out yet, you still have time to spend here " << 32 - day << " days" << std::endl;
		return false;
	}
	return true;
}

void createCardD(std::vector<Purse>& purses, const int numPurse) {
	std::cout << "Enter the name for the new debit card - ";
	std::string name;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, name);
	std::wcout << L"Enter the number of the currency you want to use\n1 - $\n2 - S (Hryvnia)\n3 - \u20AC" << std::endl;
	char currency;
	std::cout << "your choice: ";
	int choice = inputNum(1,3);
	switch (choice) {
	case 1:
		currency = '$';
		break;
	case 2:
		currency = 'S';
		break;
	case 3:
		currency = '\u20AC';
		break;
	}
	purses[numPurse].addCardD(name, currency);
}

void createCardC(std::vector<Purse>& purses, const int numPurse) {
	std::cout << "Enter the name for the new credit card - ";
	std::string name;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, name);
	std::wcout << L"Enter the number of the currency you want to use\n1 - $\n2 - S (Hryvnia)\n3 - \u20AC" << std::endl;
	char currency;
	std::cout << "your choice: ";
	int choice = inputNum(1, 3);
	switch (choice) {
	case 1:
		currency = '$';
		break;
	case 2:
		currency = 'S';
		break;
	case 3:
		currency = '\u20AC';
		break;
	}
	purses[numPurse].addCardC(name, currency);
}

const int choiceCardD(const std::vector<Purse>& purses, const int numPurse) {
	if (purses[numPurse].amountCardsD() == 0) {
		std::cout << "You don't have any debit cards yet" << std::endl;
		return 0;
	}
	purses[numPurse].printCardsD();
	std::cout << "select a debit card number" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsD());
	return numCard;
}

const int choiceCardC(const std::vector<Purse>& purses, const int numPurse) {
	if (purses[numPurse].amountCardsC() == 0) {
		std::cout << "You don't have any credit cards yet" << std::endl;
		return 0;
	}
	purses[numPurse].printCardsC();
	std::cout << "weberete credit card number" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsC());
	return numCard;
}

const double amountMoneyCard(const std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard) {
	return (Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard));
}

void replenishment(std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard) {
	std::cout << "Enter the amount you want to top up your account with: ";
	double sum = inputDouble();
	(Debit_or_Credit == 'D' ? purses[numPurse].replenishmentCardD(sum, numCard) : purses[numPurse].replenishmentCardC(sum, numCard));
}

void takeСredit(std::vector<Purse>& purses, const int numPurse, const int numCard) {
	std::cout << "Enter the amount you want to borrow: ";
	double sum = inputDouble();
	purses[numPurse].takeСredit(sum, numCard);
}

void spendSum(std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard, const double sum) {
	(Debit_or_Credit == 'D' ? purses[numPurse].spendCardD(sum, numCard) : purses[numPurse].spendCardC(sum, numCard));
}

double sumProduct(const int numProduct, const char currency) {
	double sum;
	switch (numProduct)
	{
	case 1:
		sum = 1500;
		break;
	case 2:
		sum = 20;
		break;
	case 3:
		sum = 1;
		break;
	case 4:
		sum = 666;
		break;
	case 5:
		sum = 2;
		break;
	case 6:
		sum = 20;
		break;
	case 7:
		sum = 5000000;
		break;
	case 8:
		sum = 50;
		break;
	case 9:
		sum = 25;
		break;
	}

	switch (currency)
	{
	case '$':
		return sum;
		break;
	case 'S':
		return sum * 40.99;
		break;
	case '\u20AC':
		return sum * 0.85;
		break;
	}

	return  -1;
}

const char checkCurrency(const std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard) {
	return (Debit_or_Credit == 'D' ? purses[numPurse].currencyCardD(numCard) : purses[numPurse].currencyCardC(numCard));
}

const bool checkProductAvailability(int Product) {
	if (!Product) {
		std::cout << "out of stock";
		return false;
	}
	return true;
}

void returnCredit(std::vector<Purse>& purses, const int numPurse, const int numCard) {
	if (purses[numPurse].checkCredit(numPurse) == 0) {
		std::cout << "you don't have a loan" << std::endl;
		return;
	}
	std::cout << "Enter the amount you want to repay the loan: ";
	double sum = inputDouble();
	purses[numPurse].returnCredit(sum, numCard);
}

void playHangman() {
	WordManager wordManager;
	wordManager.loadWords();
	std::string word = wordManager.getRandomWord();

	if (word.empty()) {
		std::cout << "Error: word list is empty!\n";
		return;
	}

	Hangman game(word);
	game.play();
}
