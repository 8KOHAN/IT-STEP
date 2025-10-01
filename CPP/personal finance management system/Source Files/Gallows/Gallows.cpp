#include <iostream>
#include "Gallows.h"

Gallows::Gallows(const std::string& w) noexcept : word_(w) {
    currentState_ = std::string(word_.size(), '_');
    startTime_ = std::time(0);
}

void Gallows::play() noexcept {
    while (currentState_ != word_) {
        std::cout << "Слово: " << currentState_ << "\n";
        std::cout << "Введіть літеру: ";
        char guess;
        std::cin >> guess;

        if (player_.hasGuessed(guess)) {
            std::cout << "Ви вже вводили цю літеру!\n";
            continue;
        }

        player_.addGuess(guess);

        bool found = false;
        for (size_t i = 0; i < word_.size(); i++) {
            if (word_[i] == guess) {
                currentState_[i] = guess;
                found = true;
            }
        }

        if (!found) {
            std::cout << "Такої літери немає!\n";
        }
    }
    showStatistics();
}

void Gallows::showStatistics() const noexcept {
    time_t endTime = std::time(0);
    double duration = difftime(endTime, startTime_);

    std::cout << "\nВи відгадали слово: " << word_ << "\n";
    std::cout << "Час гри: " << duration << " сек\n";
    std::cout << "Кількість спроб: " << player_.getAttempts() << "\n";
    std::cout << "Введені літери: ";
    for (size_t i = 0; i < player_.getGuessedLetters().size(); i++) {
        std::cout << player_.getGuessedLetters()[i] << " ";
    }
    std::cout << "\n";
}
