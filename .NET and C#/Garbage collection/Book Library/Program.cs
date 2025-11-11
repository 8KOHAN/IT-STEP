namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            using (Book book1 = new Book("Vinipyx", "LEGENDA", 1970, 5))
            {
                book1.DisplayInfo();
            }

            Book book2 = new Book("Clean Code", "Bobik Martin", 2010, 356);
            book2.DisplayInfo();
            book2.Dispose();

            GC.Collect();

            Console.WriteLine("\n\n" + new string('-', 100) + "\n\n");

            Console.WriteLine("=== Testing Library Class ===");

            using (Library library = new Library())
            {
                library.AddBook(new Book("Vinipyx", "LEGENDA", 1970, 5));
                library.AddBook(new Book("Clean Code", "Bobik Martin", 2010, 356));
                library.AddBook(new Book("Relax", "Goniando Rodriges", 2018, 100));

                library.DisplayAllBooks();
            }

            GC.Collect();
        }
    }
}
