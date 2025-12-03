namespace IT_STEP
{
    public class MainMenu
    {
        private readonly DictionaryService _dictService;
        private readonly FileService _fileService;

        private LanguageDictionary _currentDictionary;

        public MainMenu()
        {
            _dictService = new DictionaryService();
            _fileService = new FileService();
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Create Dictionary");
                Console.WriteLine("2. Load Dictionary");
                Console.WriteLine("3. Open Dictionary Menu");
                Console.WriteLine("0. Exit");

                Console.Write("Enter choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDictionary();
                        break;

                    case "2":
                        LoadDictionary();
                        break;

                    case "3":
                        if (_currentDictionary != null)
                        {
                            var dictMenu = new DictionaryMenu(_currentDictionary, _dictService, _fileService);
                            dictMenu.Show();
                        }
                        else
                        {
                            Console.WriteLine("No dictionary loaded.");
                        }
                        break;

                    case "0":
                        return;
                }
            }
        }

        private void CreateDictionary()
        {
            Console.Write("Enter dictionary type (e.g. ENG-UKR): ");
            string type = Console.ReadLine();
            _currentDictionary = new LanguageDictionary(type);
            Console.WriteLine("Dictionary created.");
        }

        private void LoadDictionary()
        {
            Console.Write("Enter path to dictionary file: ");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                _currentDictionary = _fileService.LoadDictionary(path);
                Console.WriteLine("Dictionary loaded.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
