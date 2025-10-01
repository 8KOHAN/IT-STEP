#include "Player.h"

Player::Player() noexcept : attempts_(0) {}

void Player::addGuess(char letter) noexcept {
    guessedLetters_.push_back(letter);
    ++attempts_;
}

bool Player::hasGuessed(char letter) const noexcept {
    for (size_t i = 0; i < guessedLetters_.size(); i++) {
        if (guessedLetters_[i] == letter) return true;
    }
    return false;
}

int Player::getAttempts() const noexcept {
    return attempts_;
}

const std::vector<char>& Player::getGuessedLetters() const noexcept {
    return guessedLetters_;
}
