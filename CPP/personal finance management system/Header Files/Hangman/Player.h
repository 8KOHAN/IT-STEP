#pragma once
#include <string>
#include <vector>

class Player {
public:
    Player() noexcept;
    void addGuess(char letter) noexcept;
    bool hasGuessed(char letter) const noexcept;
    int getAttempts() const noexcept;
    const std::vector<char>& getGuessedLetters() const noexcept;
private:
    std::vector<char> guessedLetters_;
    int attempts_;
};
