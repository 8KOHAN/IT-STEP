namespace IT_STEP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PoemCollection collection = new PoemCollection();
            string filePath = "poems.txt";

            collection.LoadFromFile(filePath);

            while (true)
            {
                Console.WriteLine("\n=== POEM COLLECTION APP ===");
                Console.WriteLine("1. Add poem");
                Console.WriteLine("2. Remove poem");
                Console.WriteLine("3. Update poem");
                Console.WriteLine("4. Search poems");
                Console.WriteLine("5. Show all");
                Console.WriteLine("6. Save");
                Console.WriteLine("7. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        collection.AddPoem(CreatePoem());
                        break;

                    case "2":
                        Console.Write("Enter title to remove: ");
                        Console.WriteLine(collection.RemovePoem(Console.ReadLine())
                            ? "Removed." : "Not found.");
                        break;

                    case "3":
                        Console.Write("Enter title to update: ");
                        string oldTitle = Console.ReadLine();
                        Console.WriteLine(collection.UpdatePoem(oldTitle, CreatePoem())
                            ? "Updated." : "Not found.");
                        break;

                    case "4":
                        Console.Write("Enter word to search: ");
                        var results = collection.Search(Console.ReadLine());

                        foreach (var r in results)
                        {
                            Console.WriteLine("---------");
                            Console.WriteLine(r);
                        }
                        break;

                    case "5":
                        foreach (var p in collection.GetAll())
                        {
                            Console.WriteLine("---------");
                            Console.WriteLine(p);
                        }
                        break;

                    case "6":
                        collection.SaveToFile(filePath);
                        Console.WriteLine("Saved.");
                        break;

                    case "7":
                        collection.SaveToFile(filePath);
                        return;

                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }
            }
        }

        static Poem CreatePoem()
        {
            Poem poem = new Poem();

            Console.Write("Title: ");
            poem.Title = Console.ReadLine();

            Console.Write("Author: ");
            poem.Author = Console.ReadLine();

            Console.Write("Year: ");
            poem.Year = int.Parse(Console.ReadLine());

            Console.Write("Theme: ");
            poem.Theme = Console.ReadLine();

            Console.Write("Text (end with empty line):\n");

            string text = "";
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) break;
                text += line + "\n";
            }
            poem.Text = text.Trim();

            return poem;
        }
    }
}
