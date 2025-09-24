#include "main_functions.h"

int inputNum(int maxNum) {
	bool isOpen = true;
	std::cout << "ваш выбор: ";
	int choice;
	do {
		std::cin >> choice;
		for (int num = 0; num <= maxNum; ++num) {
			if (choice == num) {
				isOpen = false;
				break;
			}
		}
		std::cout << "повторите ввод: ";
	} while (isOpen);
	return choice;
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
	//code
}
