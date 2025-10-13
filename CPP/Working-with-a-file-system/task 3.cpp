#define KEY 3

char shift_char(char c, int key) {
    if (c >= 'A' && c <= 'Z')
        return ((c - 'A' + key) % 26) + 'A';
    else if (c >= 'a' && c <= 'z')
        return ((c - 'a' + key) % 26) + 'a';
    else
        return c;
}

int main() {
    FILE* input = fopen("input.txt", "r");
    FILE* output = fopen("output.txt", "w");

    if (!input || !output) {
        fprintf(stderr, "The file could not be opened.\n");
        return 1;
    }

    int ch;
    while ((ch = fgetc(input)) != EOF) {
        fputc(shift_char(ch, KEY), output);
    }

    fclose(input);
    fclose(output);

    printf("Encryption complete. Result in file output.txt\n");
    return 0;
}
