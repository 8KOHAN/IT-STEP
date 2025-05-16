int is_vowel(char c) {
    c = tolower(c);
    const char* vowels = "aeiou";
    return strchr(vowels, c) != NULL;
}

int main() {
    FILE* input = fopen("input.txt", "r");
    FILE* output = fopen("stats.txt", "w");

    if (input == NULL || output == NULL) {
        fprintf(stderr, "Не вдалося відкрити файл.\n");
        return 1;
    }

    int ch;
    int char_count = 0;
    int line_count = 0;
    int vowel_count = 0;
    int consonant_count = 0;
    int digit_count = 0;

    while ((ch = fgetc(input)) != EOF) {
        char_count++;

        if (ch == '\n') {
            line_count++;
        }

        if (isdigit(ch)) {
            digit_count++;
        } else if (isalpha(ch)) {
            if (is_vowel(ch)) {
                vowel_count++;
            } else {
                consonant_count++;
            }
        }
    }

    // Якщо файл не порожній і останній символ не був \n — додаємо рядок
    if (char_count > 0 && ch != '\n') {
        line_count++;
    }

    fprintf(output, "Кількість символів: %d\n", char_count);
    fprintf(output, "Кількість рядків: %d\n", line_count);
    fprintf(output, "Кількість голосних букв: %d\n", vowel_count);
    fprintf(output, "Кількість приголосних букв: %d\n", consonant_count);
    fprintf(output, "Кількість цифр: %d\n", digit_count);

    fclose(input);
    fclose(output);

    printf("Статистика записана в файл stats.txt\n");
    return 0;
}
