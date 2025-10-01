#include <iostream>
#include <Windows.h>
#include "ClearScreen.h"
#include "purse.h"
#include "functions.h"
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
		std::cout << "день - " << day << "\n\n";

		choice = -1;
		int numPurse;
		while (choice != 2) {
			std::cout << "1 - создайте гаманець\n2 - выберете гаманець\n3 - измените название старого гаманця\n0 - выход" << std::endl;
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
		std::cout << "день - " << day << "\n\n";

		int numCard;
		char Debit_or_Credit;
		choice = -1;
		while (!(choice == 3) && !(choice == 4)) {
			std::cout << "1 - создайте дебетову картку\n2 - создайте кредитну картку\n3 выберете дебетову картку\n4 выберете кредитну картку\n0 - выход" << std::endl;
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
		std::cout << "день - " << day << "\n\n";
		while (choice != 2) {
			std::wcout << L"денег на карте - " << amountMoneyCard(purses, numPurse, Debit_or_Credit, numCard)  << checkCurrency(purses, numPurse, Debit_or_Credit, numCard) << std::endl;
			std::cout << (Debit_or_Credit == 'D' ? "1 - поповненя картки\n2 - открыть магазин\n0 - выход\n" : "1 - поповненя картки\n2 - открыть магазин\n3 - взять кредит\n4 - погасить кредит\n0 - выход\n");
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
				isOpen = checkExit(day);
				break;
			}
			if (isOpen) break;
		}
		if (isOpen) break;

		clearScreen();
		std::cout << "день - " << day << "\n\n";

		choice = -1;
		std::cout << "хотите посмотреть статистику\n1 - да\n2 - нет" << std::endl;
		choice = inputNum(1, 2);
		if (choice == 1) {
			bool isOpen = true;
			while (isOpen) {
				std::cout << "введите номер статистики которую хотите посмотреть\n1 - история трат\n2 - топ 3 покупки\n0 - выход" << std::endl;
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
		if (shop.checkGallows()) {
			bool isOpen = true;
			while (isOpen) {
				std::cout << "хотите сыграть в игру\"Шибениця\"\n1 - да\n2 - нет" << std::endl;
				choice = inputNum(1, 2);
				switch (choice) {
				case 1:
					playGallows();
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
