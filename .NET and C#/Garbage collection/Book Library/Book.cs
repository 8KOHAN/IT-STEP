namespace IT_STEP
{
    public class Book : IDisposable
    {
        private string _title;
        private string _author;
        private int _year;
        private int _pages;
        private bool _disposed = false;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public int Year
        {
            get => _year;
            set => _year = value;
        }

        public int Pages
        {
            get => _pages;
            set => _pages = value;
        }

        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Pages: {Pages}");
            Console.WriteLine(new string('-', 30));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Releasing resources for book - {Title}");
                }
                _disposed = true;
            }
        }
        ~Book()
        {
            Console.WriteLine($"Finalizator Book - {Title}");
        }
    }
}
