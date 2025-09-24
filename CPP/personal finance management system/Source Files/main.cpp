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

	for (int day = 1; day < 32; ++day) {
		std::cout << "день - " << day << "\n\n";

		std::cout << "1 - создайте гаманець\n2 - выберете гаманець\n3 измените название старого гаманця\n0 - выход" << std::endl;
		int choice = inputNum(3);

		std::string namePurse;
		switch (choice) {
		case 1:
			createPurse(purses);
			break;
		case 2:
			
			break;
		}


		std::cout << "\n\n\n";
		std::cout << "1 - выберете картку\n2 - создайте картку\n0 - выход" << std::endl;
		//code


		std::cout << "\n\n\n";
		std::cout << "денег на карте - " << std::endl;
		std::cout << "1 - поповненя картки\n2 - открыть магазин\n0 - выход\n";
		//code


		std::cout << "\n\n\n";
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
		std::cout << "введите цыфру товара который вы хотите купить - " << std::endl;
	
		clearScreen();
	}

	// за покупку некоторых товаров должны выводится отчивки 
	// 
	// нужно сделать клас картка, гаманець, магазин, история вытрат и их статистика которая должна сохранятся в фаил
	// 
	//code
}
