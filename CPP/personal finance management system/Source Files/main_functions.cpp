#include "main_functions.h"

int inputNum(int minNum, int maxNum) {
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
	} while (isOpen);
	return choice;
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

int choicePurse(const std::vector<Purse>& purses) {
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

void choiceCardD(const std::vector<Purse>& purses, int numPurse) {
	if (purses[numPurse].amountCardsD() == 0) {
		std::cout << "у вас пока нету не одной дебетовой картки" << std::endl;
		return;
	}
	purses[numPurse].printCardsD();
	std::cout << "веберете номер дебетовой картки" << std::endl;
	int choice = inputNum(1, purses[numPurse].amountCardsD());
}

void choiceCardC(const std::vector<Purse>& purses, int numPurse) {
	if (purses[numPurse].amountCardsC() == 0) {
		std::cout << "у вас пока нету не одной кредитной картки" << std::endl;
		return;
	}
	purses[numPurse].printCardsC();
	std::cout << "веберете номер кредитной картки" << std::endl;
	int choice = inputNum(1, purses[numPurse].amountCardsC());
}
