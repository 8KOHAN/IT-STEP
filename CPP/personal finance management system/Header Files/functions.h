#pragma once
#include <iostream>
#include <vector>  
#include "purse.h"
#include "ClearScreen.h"
#include "Gallows.h"

const int inputNum(const int minNum, const int maxNum);

const double inputDouble();

void printPurses(const std::vector<Purse>& purses);

void createPurse(std::vector<Purse>& purses);

const int choicePurse(const std::vector<Purse>& purses);

void setNamePurse(std::vector<Purse>& purses);

bool checkExit(const int day);

void createCardD(std::vector<Purse>& purses, const int numPurse);

void createCardC(std::vector<Purse>& purses, const int numPurse);

const int choiceCardD(const std::vector<Purse>& purses, const int numPurse);

const int choiceCardC(const std::vector<Purse>& purses, const int numPurse);

const double amountMoneyCard(const std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard);

void replenishment(std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard);

void takeСredit(std::vector<Purse>& purses, const int numPurse, const int numCard);

void spendSum(std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard, double sum);

double sumProduct(const int numProduct, const char currency);

const char checkCurrency(const std::vector<Purse>& purses, const int numPurse, const char Debit_or_Credit, const int numCard);

const bool checkProductAvailability(int Product);

void returnCredit(std::vector<Purse>& purses, const int numPurse, const int numCard);

void playGallows();
