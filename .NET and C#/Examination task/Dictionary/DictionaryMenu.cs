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
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWord();
                        break;
                    case "2":
                        ReplaceWord();
                        break;
                    case "3":
                        ReplaceTranslation();
                        break;
                    case "4":
                        RemoveWord();
                        break;
                    case "5":
                        RemoveTranslation();
                        break;
                    case "6":
                        FindTranslations();
                        break;
                    case "7":
                        SaveDictionary();
                        break;
                    case "8":
                        ExportWord();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private void AddWord()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter translation: ");
            string translation = Console.ReadLine();

            _dictService.AddWord(_dictionary, word, translation);
            Console.WriteLine("Word added.");
        }

        private void ReplaceWord()
        {
            Console.Write("Enter existing word: ");
            string oldWord = Console.ReadLine();
            Console.Write("Enter new word: ");
            string newWord = Console.ReadLine();

            _dictService.ReplaceWord(_dictionary, oldWord, newWord);
            Console.WriteLine("Word replaced.");
        }

        private void ReplaceTranslation()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter old translation: ");
            string oldT = Console.ReadLine();
            Console.Write("Enter new translation: ");
            string newT = Console.ReadLine();

            _dictService.ReplaceTranslation(_dictionary, word, oldT, newT);
            Console.WriteLine("Translation replaced.");
        }

        private void RemoveWord()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            _dictService.RemoveWord(_dictionary, word);
            Console.WriteLine("Word removed.");
        }

        private void RemoveTranslation()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter translation to remove: ");
            string tr = Console.ReadLine();

            _dictService.RemoveTranslation(_dictionary, word, tr);
            Console.WriteLine("Translation removed if rules allow.");
        }

        private void FindTranslations()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            var list = _dictService.FindTranslations(_dictionary, word);

            if (list == null)
                Console.WriteLine("Word not found.");
            else
                Console.WriteLine("Translations: " + string.Join(", ", list));
        }

        private void SaveDictionary()
        {
            Console.Write("Enter file path to save: ");
            string path = Console.ReadLine();

            _fileService.SaveDictionary(_dictionary, path);
            Console.WriteLine("Dictionary saved.");
        }

        private void ExportWord()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            _fileService.ExportWord(_dictionary, word, path);
            Console.WriteLine("Word exported.");
        }
    }
}
