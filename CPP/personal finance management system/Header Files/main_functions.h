#pragma once
#include <iostream>
#include "purse.h"

int inputNum(int minNum, int maxNum);

void printPurses(const std::vector<Purse>& purses);

void createPurse(std::vector<Purse>& purses);

int choicePurse(const std::vector<Purse>& purses);

void setNamePurse(std::vector<Purse>& purses);

bool checkExit(int day);

void createCardD(std::vector<Purse>& purses, int numPurse);

void createCardC(std::vector<Purse>& purses, int numPurse);

void choiceCardD(const std::vector<Purse>& purses, int numPurse);

void choiceCardC(const std::vector<Purse>& purses, int numPurse);
