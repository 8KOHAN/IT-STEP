#pragma once

#include <iostream>
#include <string>
#include <fstream>
#include <stdexcept>
#include <cctype>
#include "AgeException.h"

int toInt(const std::string& s);

void process();

void checkPassword(const std::string& password);

void ageVerification(int age);
