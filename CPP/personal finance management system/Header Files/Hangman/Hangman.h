#pragma once
#include <string>
#include <ctime>
#include "Player.h"
#include "WordManager.h"

class Hangman {
public:
    Hangman(const std::string& w) noexcept;
    void play() noexcept;
    void showStatistics() const noexcept;
private:
    std::string word_;
    std::string currentState_;
    Player player_;
    time_t startTime_;
};

