namespace IT_STEP
{
    public class Library : IDisposable
    {
        private List<Book> _books;
        private bool _disposed = false;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Cannot add a null book.");
                return;
            }

            _books.Add(book);
            Console.WriteLine($"Book - {book.Title} added to library.");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n=== Library Books ===");
            if (_books.Count == 0)
            {
                Console.WriteLine("No books in the library.");
                return;
            }

            foreach (Book book in _books)
            {
                book.DisplayInfo();
            }
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
                    Console.WriteLine("Clearing library resources...");
                    foreach (Book book in _books)
                    {
                        book.Dispose();
                    }

                    _books.Clear();
                    _books = null;
                }

                _disposed = true;
            }
        }

        ~Library()
        {
            Console.WriteLine("Finalizer Library is being finalized by the garbage collector.");
        }
    }
}
