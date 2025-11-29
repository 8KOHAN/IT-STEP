namespace IT_STEP
{
    public class Magazine
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();

        public void PrintInfo()
        {
            Console.WriteLine("=== Magazine Information ===");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Release Date: {ReleaseDate:yyyy-MM-dd}");
            Console.WriteLine($"Page Count: {PageCount}");
            Console.WriteLine();

            Console.WriteLine("--- Articles ---");
            foreach (var article in Articles)
            {
                Console.WriteLine($"* {article.Title} ({article.CharacterCount} chars)");
                Console.WriteLine($"  Preview: {article.Preview}");
            }
        }
    }
}
