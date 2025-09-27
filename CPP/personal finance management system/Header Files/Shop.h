#pragma once
#include <iostream>
#include <string>
#include <fstream>

class Shop
{
public:
	Shop(std::string fileName);

	void buy(int choice);

	void saveToFile();

private:
	std::string spendingHistory_;
	std::string fileName_;
	// написать поля для каждого товара
};
