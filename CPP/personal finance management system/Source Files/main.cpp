#include <iostream>
#include <Windows.h>
#include "ClearScreen.h"
#include "purse.h"
#include "main_functions.h"

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	std::vector<Purse> purses;
	bool isOpen = false;

	for (int day = 1; day < 32; ++day) {

		std::cout << "день - " << day << "\n\n";

		int choice = -1;
		int numPurse;
		while (choice != 2 || choice == 0) {
			std::cout << "1 - создайте гаманець\n2 - выберете гаманець\n3 измените название старого гаманця\n0 - выход" << std::endl;
			choice = inputNum(0, 3);

			switch (choice) {
			case 1:
				createPurse(purses);
				break;
			case 2:
				numPurse = choicePurse(purses);
				break;
			case 3:
				setNamePurse(purses);
				break;
			case 0:
				isOpen = checkExit(day);
				break;
			}
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
				numCard = choiceCardD(purses, numPurse);
				Debit_or_Credit = 'D';
				break;
			case 4:
				numCard = choiceCardC(purses, numPurse);
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
		while (choice != 2) {
			clearScreen();
			std::cout << "день - " << day << "\n\n";

			std::cout << "денег на карте - " << amountMoneyCard(purses, numPurse, Debit_or_Credit, numCard) << std::endl;
			std::cout << (Debit_or_Credit == 'D' ? "1 - поповненя картки\n2 - открыть магазин\n0 - выход\n" : "1 - поповненя картки\n2 - открыть магазин\n3 - взять кредит\n0 - выход\n");
			choice = inputNum(0, 3);
			switch (choice) {
			case 1:
				replenishment(purses, numPurse, Debit_or_Credit, numCard);
				break;
			case 2:
				clearScreen();
				std::cout << "день - " << day << "\n\n";
				std::cout << "--МАГАЗИН--\n\n";
				std::cout << "1 - ps5        ЦЕНА - 1500$      (вналичие 2 экземпляра)" << std::endl;
				std::cout << "2 - чайник     ЦЕНА - 20$        (вналичие 10 экземпляров)" << std::endl;
				std::cout << "3 - Батарейка  ЦЕНА - 1$         (вналичие 200 экземпляров)" << std::endl;
				std::cout << "4 - сигарета   ЦЕНА - 666$       (вналичие 1 экземпляр)" << std::endl;
				std::cout << "5 - сникерс    ЦЕНА - 2$         (вналичие 20 экземпляров)" << std::endl;
				std::cout << "6 - прополес   ЦЕНА - 20$        (вналичие 5 экземпляров)" << std::endl;
				std::cout << "7 - дом        ЦЕНА - 5 000 000$ (вналичие 1 экземпляр)" << std::endl;
				std::cout << "8 - клавиатуру ЦЕНА - 50$        (вналичие 3 экземпляра)" << std::endl;
				std::cout << "9 - цветок     ЦЕНА - 25$        (вналичие 10 экземпляров)" << std::endl;
				std::cout << "0 - выход" << std::endl;
				std::cout << "введите номер товара который вы хотите купить - " << std::endl;
				
				choice = inputNum(0, 9);
				if (choice == 0) break;
				//code
				
				break;
			case 3:
				takeСredit(purses, numPurse, numCard);
				break;
			case 0:
				isOpen = checkExit(day);
				break;
			}
			if (isOpen) break;
		}
		if (isOpen) break;
		clearScreen();
	}
}
