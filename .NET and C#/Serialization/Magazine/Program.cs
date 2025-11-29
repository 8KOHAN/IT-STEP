namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Magazine magazine = new Magazine();

            Console.Write("Enter magazine title: ");
            magazine.Title = Console.ReadLine();

            Console.Write("Enter publisher: ");
            magazine.Publisher = Console.ReadLine();

            Console.Write("Enter release date (yyyy-mm-dd): ");
            magazine.ReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter page count: ");
            magazine.PageCount = int.Parse(Console.ReadLine());

            Console.Write("How many articles? ");
            int articleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < articleCount; i++)
            {
                Console.WriteLine($"\n--- Article {i + 1} ---");
                Article article = new Article();

                Console.Write("Title: ");
                article.Title = Console.ReadLine();

                Console.Write("Character count: ");
                article.CharacterCount = int.Parse(Console.ReadLine());

                Console.Write("Preview: ");
                article.Preview = Console.ReadLine();

                magazine.Articles.Add(article);
            }

            string filePath = "magazine.json";
            MagazineSerializer.SaveToFile(filePath, magazine);
            Console.WriteLine("\nMagazine saved to file!");

            Magazine loadedMagazine = MagazineSerializer.LoadFromFile(filePath);
            Console.WriteLine("\nMagazine loaded from file and deserialized:\n");

            loadedMagazine.PrintInfo();
        }
    }
}
