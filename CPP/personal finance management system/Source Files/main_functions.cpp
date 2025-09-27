#include "main_functions.h"

const int inputNum(int minNum, int maxNum) {
	bool isOpen = true;
	std::cout << "ваш выбор: ";
	int choice;
	do {
		std::cin >> choice;
		if (choice >= minNum && choice <= maxNum) {
			isOpen = false;
			break;
		}
		std::cout << "повторите ввод: ";
		std::cin.clear();
		std::cin.ignore(10000, '\n');
	} while (isOpen);
	return choice;
}

const double inputDouble() {
	double sum;
	while (!(std::cin >> sum)) {
		std::cout << "Ошибка ввода! Попробуйте снова: ";
		std::cin.clear();
		std::cin.ignore(10000, '\n');
	}
	return sum;
}

void printPurses(const std::vector<Purse>& purses) {
	for (int i = 1; i < purses.size(); ++i)
		std::cout << i << " - " << purses[i].name() << std::endl;
}

void createPurse(std::vector<Purse>& purses) {
	std::string namePurse;
	std::cout << "введите название вашего нового гаманця: ";
	std::cin >> namePurse;
	purses.push_back(Purse(namePurse));
}

const int choicePurse(const std::vector<Purse>& purses) {
	if (!purses.empty()) {
		std::cout << "у вас пока нету не одного гаманця" << std::endl;
		return -1;
	}
	printPurses(purses);
	std::cout << "веберете номер гаманця" << std::endl;
	int choice = inputNum(1, purses.size());
	return choice;
}

void setNamePurse(std::vector<Purse>& purses) {
	printPurses(purses);
	std::cout << "веберете номер гаманця" << std::endl;
	int choice = inputNum(1, purses.size());
	std::cout << "введите новое имя - ";
	std::string newName;
	std::cin >> newName;
	purses[choice].setName(newName);
}

bool checkExit(int day) {
	if (day < 32) {
		std::cout << "вы пока не можете выйти, вам осталось еще провести тут " << 32 - day << " дней" << std::endl;
		return false;
	}
	return true;
}

void createCardD(std::vector<Purse>& purses, int numPurse) {
	std::cout << "введите названия для новой дебетовой картки - ";
	std::string name;
	std::cin >> name;
	purses[numPurse].addCardD(name);
}

void createCardC(std::vector<Purse>& purses, int numPurse) {
	std::cout << "введите названия для новой кредитной картки - ";
	std::string name;
	std::cin >> name;
	purses[numPurse].addCardC(name);
}

const int choiceCardD(const std::vector<Purse>& purses, int numPurse) {
	if (purses[numPurse].amountCardsD() == 0) {
		std::cout << "у вас пока нету не одной дебетовой картки" << std::endl;
		return -1;
	}
	purses[numPurse].printCardsD();
	std::cout << "веберете номер дебетовой картки" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsD());
	return numCard;
}

const int choiceCardC(const std::vector<Purse>& purses, int numPurse) {
	if (purses[numPurse].amountCardsC() == 0) {
		std::cout << "у вас пока нету не одной кредитной картки" << std::endl;
		return -1;
	}
	purses[numPurse].printCardsC();
	std::cout << "веберете номер кредитной картки" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsC());
	return numCard;
}

const double amountMoneyCard(const std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard) {
	return (Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard));
}

void replenishment(std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard) {
	std::cout << "введите суму на которую вы хотите пополнить счет: ";
	double sum = inputDouble();
	(Debit_or_Credit == 'D' ? purses[numPurse].replenishmentCardD(sum, numCard) : purses[numPurse].replenishmentCardC(sum, numCard));
}

void takeСredit(std::vector<Purse>& purses, int numPurse, int numCard) {
	std::cout << "введите суму на который вы хотите взять кредит: ";
	double sum = inputDouble();
	purses[numPurse].takeСredit(sum, numCard);
}
