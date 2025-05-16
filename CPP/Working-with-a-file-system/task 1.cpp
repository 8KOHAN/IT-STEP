#define MAX_LINE_LENGTH 1024

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    FILE* file1;
    fopen_s(&file1, "file1.txt", "r");
    FILE* file2;
    fopen_s(&file2, "file2.txt", "r");

    if (file1 == NULL || file2 == NULL) {
        std::cout << stderr << " Не вдалося відкрити один або обидва файли.\n";
        return 1;
    }

    char line1[MAX_LINE_LENGTH];
    char line2[MAX_LINE_LENGTH];
    int lineNumber = 1;
    int allMatch = 1;

    while (fgets(line1, MAX_LINE_LENGTH, file1) && fgets(line2, MAX_LINE_LENGTH, file2)) {
        line1[strcspn(line1, "\n")] = '\0';
        line2[strcspn(line2, "\n")] = '\0';

        if (strcmp(line1, line2) != 0) {
            printf("Рядки не збігаються (рядок %d):\n", lineNumber);
            printf("file1.txt: %s\n", line1);
            printf("file2.txt: %s\n", line2);
            allMatch = 0;
        }

        lineNumber++;
    }

    if (fgets(line1, MAX_LINE_LENGTH, file1)) {
        printf("file1.txt має додатковий рядок (рядок %d): %s", lineNumber, line1);
        allMatch = 0;
    }
    else if (fgets(line2, MAX_LINE_LENGTH, file2)) {
        printf("file2.txt має додатковий рядок (рядок %d): %s", lineNumber, line2);
        allMatch = 0;
    }

    if (allMatch) {
        printf("Усі рядки збігаються.\n");
    }

    fclose(file1);
    fclose(file2);

    return 0;
}
