#pragma once
#include <iostream>
#include "purse.h"

const int inputNum(const int minNum, const int maxNum);

const double inputDouble();

void printPurses(const std::vector<Purse>& purses);

void createPurse(std::vector<Purse>& purses);

const int choicePurse(const std::vector<Purse>& purses);

void setNamePurse(std::vector<Purse>& purses);

bool checkExit(int day);

void createCardD(std::vector<Purse>& purses, int numPurse);

void createCardC(std::vector<Purse>& purses, int numPurse);

const int choiceCardD(const std::vector<Purse>& purses, int numPurse);

const int choiceCardC(const std::vector<Purse>& purses, int numPurse);

const double amountMoneyCard(const std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard);

void replenishment(const std::vector<Purse>& purses, int numPurse, char Debit_or_Credit, int numCard);

void takeСredit(std::vector<Purse>& purses, int numPurse, int numCard);
