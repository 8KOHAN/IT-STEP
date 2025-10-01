#include <fstream>
#include <cstdlib>
#include <ctime>
#include "WordManager.h"

WordManager::WordManager() noexcept : filename_("Gallows.txt") {}

void WordManager::loadWords() noexcept {
    std::ifstream file(filename_.c_str());
    std::string line;
    while (std::getline(file, line)) {
        words_.push_back(decrypt(line));
    }
    file.close();
    std::srand((unsigned)std::time(0));
}

std::string WordManager::decrypt(const std::string& word) noexcept {
    std::string result = word;
    for (size_t i = 0; i < result.size(); i++) {
        result[i] = result[i] - 3;
        result[i] = std::tolower(result[i]);
    }
    return result;
}

std::string WordManager::getRandomWord() noexcept {
    if (words_.empty()) return "";
    int index = std::rand() % words_.size();
    return words_[index];
}
