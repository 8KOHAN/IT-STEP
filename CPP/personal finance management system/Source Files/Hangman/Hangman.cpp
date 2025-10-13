#include "Hangman.h"

Hangman::Hangman(const std::string& w) noexcept : word_(w) {
    currentState_ = std::string(word_.size(), '_');
    startTime_ = std::time(0);
}

void Hangman::play() noexcept {
    while (currentState_ != word_) {
        std::cout << "Word: " << currentState_ << std::endl;
        std::cout << "Enter a letter: ";
        char guess;
        std::cin >> guess;

        if (player_.hasGuessed(guess)) {
            std::cout << "You have already entered this letter!\n";
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
            std::cout << "There is no such letter!" <<std::endl;
        }
    }
    showStatistics();
}

void Hangman::showStatistics() const noexcept {
    time_t endTime = std::time(0);
    double duration = difftime(endTime, startTime_);

    std::cout << "\nYou guessed the word.: " << word_ << std::endl;
    std::cout << "Game time: " << duration << " Sec" << std::endl;
    std::cout << "Number of attempts: " << player_.getAttempts() << std::endl;
    std::cout << "Letters entered: ";
    for (size_t i = 0; i < player_.getGuessedLetters().size(); i++) {
        std::cout << player_.getGuessedLetters()[i] << " ";
    }
    std::cout << std::endl;
}

