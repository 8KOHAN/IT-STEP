namespace IT_STEP
{
    public class MainMenu
    {
        private readonly DictionaryService _dictService;
        private readonly FileService _fileService;

        private readonly List<LanguageDictionary> _dictionaries;
        private int _currentDictIndex = -1;

        public MainMenu()
        {
            _dictService = new DictionaryService();
            _fileService = new FileService();
            _dictionaries = new List<LanguageDictionary>();
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Create Dictionary");
                Console.WriteLine("2. Load Dictionary From File");
                Console.WriteLine("3. Select Existing Dictionary");
                Console.WriteLine("4. Open Current Dictionary Menu");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        CreateDictionary();
                        break;

                    case "2":
                        LoadDictionary();
                        break;

                    case "3":
                        SelectDictionary();
                        break;

                    case "4":
                        OpenCurrentDictionaryMenu();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void CreateDictionary()
        {
            Console.Write("Enter dictionary type (e.g. ENG-UKR): ");
            string type = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Dictionary type cannot be empty.");
                return;
            }

            var dict = new LanguageDictionary(type);
            _dictionaries.Add(dict);
            _currentDictIndex = _dictionaries.Count - 1;

            Console.WriteLine("Dictionary created and set as current.");
        }

        private void LoadDictionary()
        {
            Console.Write("Enter path to dictionary file: ");
            string path = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Path cannot be empty.");
                return;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var dict = _fileService.LoadDictionary(path);

            if (dict == null)
            {
                Console.WriteLine("Failed to load dictionary (invalid file).");
                return;
            }

            _dictionaries.Add(dict);
            _currentDictIndex = _dictionaries.Count - 1;

            Console.WriteLine("Dictionary loaded and set as current.");
        }

        private void SelectDictionary()
        {
            if (_dictionaries.Count == 0)
            {
                Console.WriteLine("No dictionaries available.");
                return;
            }

            Console.WriteLine("Available dictionaries:");
            for (int i = 0; i < _dictionaries.Count; i++)
            {
                Console.WriteLine($"{i}. {_dictionaries[i].Type}");
            }

            Console.Write("Enter dictionary index: ");
            string input = Console.ReadLine()?.Trim();

            if (!int.TryParse(input, out int index))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            if (index < 0 || index >= _dictionaries.Count)
            {
                Console.WriteLine("Index out of range.");
                return;
            }

            _currentDictIndex = index;
            Console.WriteLine("Dictionary selected.");
        }

        private void OpenCurrentDictionaryMenu()
        {
            if (_currentDictIndex == -1)
            {
                Console.WriteLine("No dictionary selected.");
                return;
            }

            var dict = _dictionaries[_currentDictIndex];
            var menu = new DictionaryMenu(dict, _dictService, _fileService);

            menu.Show();
        }
    }
}
