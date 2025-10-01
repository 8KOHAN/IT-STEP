#include "functions.h"

const int inputNum(const int minNum, const int maxNum) {
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
	for (int i = 0; i < purses.size(); ++i)
		std::cout << i + 1 << " - " << purses[i].name() << std::endl;
}

void createPurse(std::vector<Purse>& purses) {
	std::string namePurse;
	std::cout << "введите название вашего нового гаманця: ";
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, namePurse);
	purses.push_back(Purse(namePurse));
}

const int choicePurse(const std::vector<Purse>& purses) {
	if (purses.empty()) {
		std::cout << "у вас пока нету не одного гаманця" << std::endl;
		return 0;
	}
	printPurses(purses);
	std::cout << "веберете номер гаманця" << std::endl;
	int choice = inputNum(1, purses.size());
	return choice;
}

void setNamePurse(std::vector<Purse>& purses) {
	if (purses.empty()) {
		std::cout << "у вас пока нету не одного гаманця" << std::endl;
		return;
	}
	printPurses(purses);
	std::cout << "веберете номер гаманця" << std::endl;
	int choice = inputNum(1, purses.size());
	std::cout << "введите новое имя - ";
	std::string newName;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, newName);
	purses[choice].setName(newName);
}

bool checkExit(const int day) {
	if (day < 32) {
		std::cout << "вы пока не можете выйти, вам осталось еще провести тут " << 32 - day << " дней" << std::endl;
		return false;
	}
	return true;
}

void createCardD(std::vector<Purse>& purses, const int numPurse) {
	std::cout << "введите названия для новой дебетовой картки - ";
	std::string name;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, name);
	std::wcout << L"введите номер валюты которую вы хотите использовать\n1 - $\n2 - S (Гривна)\n3 - \u20AC" << std::endl;
	char currency;
	std::cout << "ваш выбор: ";
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
	std::cout << "введите названия для новой кредитной картки - ";
	std::string name;
	std::cin.clear();
	std::cin.ignore(10000, '\n');
	std::getline(std::cin, name);
	std::wcout << L"введите номер валюты которую вы хотите использовать\n1 - $\n2 - S (Гривна)\n3 - \u20AC" << std::endl;
	char currency;
	std::cout << "ваш выбор: ";
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
		std::cout << "у вас пока нету не одной дебетовой картки" << std::endl;
		return 0;
	}
	purses[numPurse].printCardsD();
	std::cout << "веберете номер дебетовой картки" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsD());
	return numCard;
}

const int choiceCardC(const std::vector<Purse>& purses, const int numPurse) {
	if (purses[numPurse].amountCardsC() == 0) {
		std::cout << "у вас пока нету не одной кредитной картки" << std::endl;
		return 0;
	}
	purses[numPurse].printCardsC();
	std::cout << "веберете номер кредитной картки" << std::endl;
	int numCard = inputNum(1, purses[numPurse].amountCardsC());
	return numCard;
}

const double amountMoneyCard(const std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard) {
	return (Debit_or_Credit == 'D' ? purses[numPurse].amountMoneyCardD(numCard) : purses[numPurse].amountMoneyCardC(numCard));
}

void replenishment(std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard) {
	std::cout << "введите суму на которую вы хотите пополнить счет: ";
	double sum = inputDouble();
	(Debit_or_Credit == 'D' ? purses[numPurse].replenishmentCardD(sum, numCard) : purses[numPurse].replenishmentCardC(sum, numCard));
}

void takeСredit(std::vector<Purse>& purses, const int numPurse, const int numCard) {
	std::cout << "введите суму на которую вы хотите взять кредит: ";
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
		std::cout << "нету в наличии";
		return false;
	}
	return true;
}

void returnCredit(std::vector<Purse>& purses, const int numPurse, const int numCard) {
	if (purses[numPurse].checkCredit(numPurse) == 0) {
		std::cout << "у вас нету кредита" << std::endl;
		return;
	}
	std::cout << "введите суму которой вы хотите погасить кредит: ";
	double sum = inputDouble();
	purses[numPurse].returnCredit(sum, numCard);
}

void playGallows() {
	std::cout << "загаданое слово на Английском" << std::endl;
	WordManager wordManager;
	wordManager.loadWords();
	std::string word = wordManager.getRandomWord();

	if (word.empty()) {
		std::cout << "Помилка: список слів порожній!\n";
		return;
	}

	Gallows game(word);
	game.play();
}
