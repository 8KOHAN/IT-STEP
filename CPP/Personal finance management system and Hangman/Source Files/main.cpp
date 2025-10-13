#include <iostream>
#include <Windows.h>
#include "ClearScreen.h"
#include "Purse.h"
#include "Functions.h"
#include "Shop.h"

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	std::wcout.imbue(std::locale(""));

	std::vector<Purse> purses;
	int day = 1;
	Shop shop("Spending History.txt");
	bool isOpen = false;
	int choice;

	for (; day < 32; ++day) {
		std::cout << "Day - " << day << "\n\n";

		choice = -1;
		int numPurse;
		while (choice != 2) {
			std::cout << "1 - create a gambler\n2 - select a gambler\n3 - change the name of the old gambler\n0 - exit" << std::endl;
			choice = inputNum(0, 3);

			switch (choice) {
			case 1:
				createPurse(purses);
				break;
			case 2:
				numPurse = choicePurse(purses) - 1;
				if (numPurse == -1) choice = -1;
				break;
			case 3:
				setNamePurse(purses);
				break;
			case 0:
				isOpen = checkExit(day);
				break;
			}
			if (isOpen) break;
		}
		if (isOpen) break;
		clearScreen();
		std::cout << "Day - " << day << "\n\n";

		int numCard;
		char Debit_or_Credit;
		choice = -1;
		while (!(choice == 3) && !(choice == 4)) {
			std::cout << "1 - create a debit card\n2 - create a credit card\n3 select a debit card\n4 select a credit card\n0 - exit" << std::endl;
			choice = inputNum(0, 4);
			switch (choice) {
			case 1:
				createCardD(purses, numPurse);
				break;
			case 2:
				createCardC(purses, numPurse);
				break;
			case 3:
				numCard = choiceCardD(purses, numPurse) - 1;
				if (numCard == -1) choice = -1;
				Debit_or_Credit = 'D';
				break;
			case 4:
				numCard = choiceCardC(purses, numPurse) - 1;
				if (numCard == -1) choice = -1;
				Debit_or_Credit = 'C';
				break;
			case 0:
				isOpen = checkExit(day);
				break;
			}
			if (isOpen) break;
		}
		if (isOpen) break;

		choice = -1;
		clearScreen();
		std::cout << "Day - " << day << "\n\n";
		while (choice != 0) {
			std::wcout << L"money on the card - " << amountMoneyCard(purses, numPurse, Debit_or_Credit, numCard)  << checkCurrency(purses, numPurse, Debit_or_Credit, numCard) << std::endl;
			std::cout << (Debit_or_Credit == 'D' ? "1 - top up your card\n2 - open the store\n0 - exit\n" : "1 - top up your card\n2 - open a store\n3 - take out a loan\n4 - pay off the loan\n0 - exit\n");
			choice = inputNum(0, 4);
			switch (choice) {
			case 1:
				replenishment(purses, numPurse, Debit_or_Credit, numCard);
				break;
			case 2:
				if (choice == 0) break;
				clearScreen();
				shop.buy(purses, numPurse, Debit_or_Credit, numCard);
				shop.saveToFile();
				break;
			case 3:
				takeСredit(purses, numPurse, numCard);
				break;
			case 4:
				returnCredit(purses, numPurse, numCard);
				break;
			case 0:
				break;
			}
		}

		clearScreen();
		std::cout << "Day - " << day << "\n\n";

		choice = -1;
		std::cout << "Do you want to see statistics?\n1 - yes\n2 - no" << std::endl;
		choice = inputNum(1, 2);
		if (choice == 1) {
			bool isOpen = true;
			while (isOpen) {
				std::cout << "Enter the number of the statistic you want to view\n1 - spending history\n2 - top 3 purchases\n0 - exit" << std::endl;
				choice = inputNum(0, 2);
				switch (choice) {
				case 1:
					shop.spendingHistory();
					break;
				case 2:
					shop.topSpending();
					break;
				case 0:
					isOpen = false;
					break;
				}
			}
		}

		clearScreen();
		if (shop.checkHangman()) {
			bool isOpen = true;
			while (isOpen) {
				std::cout << "Do you want to play the game Hangman?\n1 - yes\n2 - no" << std::endl;
				choice = inputNum(1, 2);
				switch (choice) {
				case 1:
					playHangman();
					break;
				case 2:
					isOpen = false;
					break;
				}
			}
		}

		shop.nextDay();
		clearScreen();
	}
}
