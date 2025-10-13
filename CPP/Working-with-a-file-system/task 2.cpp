int is_vowel(char c) {
    c = tolower(c);
    const char* vowels = "aeiou";
    return strchr(vowels, c) != NULL;
}

int main() {
    FILE* input = fopen("input.txt", "r");
    FILE* output = fopen("stats.txt", "w");

    if (input == NULL || output == NULL) {
        fprintf(stderr, "Failed to open file.\n");
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

    if (char_count > 0 && ch != '\n') {
        line_count++;
    }

    fprintf(output, "Number of characters: %d\n", char_count);
    fprintf(output, "Number of lines: %d\n", line_count);
    fprintf(output, "Number of vowels: %d\n", vowel_count);
    fprintf(output, "Number of consonants: %d\n", consonant_count);
    fprintf(output, "Number of digits: %d\n", digit_count);

    fclose(input);
    fclose(output);

    printf("Statistics are recorded in a file stats.txt\n");
    return 0;
}
