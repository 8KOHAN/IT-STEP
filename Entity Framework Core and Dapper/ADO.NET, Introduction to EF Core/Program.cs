namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            Database.Initialize();

            Console.Write("Enter author name to search: ");
            string author = Console.ReadLine();

            var books = Database.FindBooksByAuthor(author);

            Console.WriteLine("\nSearch results:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.Year})");
            }
        }
    }
}
