namespace IT_STEP
{
    public class DictionaryMenu
    {
        private readonly LanguageDictionary _dictionary;
        private readonly DictionaryService _dictService;
        private readonly FileService _fileService;

        public DictionaryMenu(LanguageDictionary dictionary, DictionaryService dictService, FileService fileService)
        {
            _dictionary = dictionary;
            _dictService = dictService;
            _fileService = fileService;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Dictionary Menu:");
                Console.WriteLine("1. Add Word");
                Console.WriteLine("2. Replace Word");
                Console.WriteLine("3. Replace Translation");
                Console.WriteLine("4. Remove Word");
                Console.WriteLine("5. Remove Translation");
                Console.WriteLine("6. Find Translations");
                Console.WriteLine("7. Save Dictionary");
                Console.WriteLine("8. Export Word");
                Console.WriteLine("0. Back");

                Console.Write("Enter choice: ");
                var choice = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case "1": AddWord(); break;
                    case "2": ReplaceWord(); break;
                    case "3": ReplaceTranslation(); break;
                    case "4": RemoveWord(); break;
                    case "5": RemoveTranslation(); break;
                    case "6": FindTranslations(); break;
                    case "7": SaveDictionary(); break;
                    case "8": ExportWord(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private string ReadValidInput(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(value))
                return null;

            return value;
        }

        private void AddWord()
        {
            string word = ReadValidInput("Enter word: ");
            string translation = ReadValidInput("Enter translation: ");

            if (word == null || translation == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _dictService.AddWord(_dictionary, word, translation);
            Console.WriteLine("Word added.");
        }

        private void ReplaceWord()
        {
            string oldWord = ReadValidInput("Enter existing word: ");
            string newWord = ReadValidInput("Enter new word: ");

            if (oldWord == null || newWord == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _dictService.ReplaceWord(_dictionary, oldWord, newWord);
            Console.WriteLine("Word replaced (if existed).");
        }

        private void ReplaceTranslation()
        {
            string word = ReadValidInput("Enter word: ");
            string oldT = ReadValidInput("Enter old translation: ");
            string newT = ReadValidInput("Enter new translation: ");

            if (word == null || oldT == null || newT == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _dictService.ReplaceTranslation(_dictionary, word, oldT, newT);
            Console.WriteLine("Translation replaced (if existed).");
        }

        private void RemoveWord()
        {
            string word = ReadValidInput("Enter word: ");

            if (word == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _dictService.RemoveWord(_dictionary, word);
            Console.WriteLine("Word removed.");
        }

        private void RemoveTranslation()
        {
            string word = ReadValidInput("Enter word: ");
            string tr = ReadValidInput("Enter translation to remove: ");

            if (word == null || tr == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _dictService.RemoveTranslation(_dictionary, word, tr);
            Console.WriteLine("Translation removed if allowed.");
        }

        private void FindTranslations()
        {
            string word = ReadValidInput("Enter word: ");

            if (word == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            var list = _dictService.FindTranslations(_dictionary, word);

            if (list == null)
            {
                Console.WriteLine("Word not found.");
                return;
            }

            Console.WriteLine("Translations: " + string.Join(", ", list));
        }

        private void SaveDictionary()
        {
            string path = ReadValidInput("Enter file path to save: ");

            if (path == null)
            {
                Console.WriteLine("Path cannot be empty.");
                return;
            }

            _fileService.SaveDictionary(_dictionary, path);
            Console.WriteLine("Dictionary saved.");
        }

        private void ExportWord()
        {
            string word = ReadValidInput("Enter word: ");
            string path = ReadValidInput("Enter file path: ");

            if (word == null || path == null)
            {
                Console.WriteLine("Input cannot be empty.");
                return;
            }

            _fileService.ExportWord(_dictionary, word, path);
            Console.WriteLine("Word exported.");
        }
    }
}
