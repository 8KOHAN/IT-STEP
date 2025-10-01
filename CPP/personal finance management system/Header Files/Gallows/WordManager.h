#pragma once
#include <string>
#include <vector>

class WordManager {
public:
    WordManager() noexcept;
    void loadWords() noexcept;
    std::string getRandomWord() noexcept;
private:
    std::vector<std::string> words_;
    std::string filename_;

    std::string decrypt(const std::string& word) noexcept;
};
