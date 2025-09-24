#pragma once
#include <iostream>
#include "purse.h"

int inputNum(int maxNum);

void createPurse(std::vector<Purse>& purses);

int choicePurse(const std::vector<Purse>& purses);
