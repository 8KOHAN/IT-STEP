namespace IT_STEP
{
    public static class TitleService
    {
        public static void AddTitle()
        {
            using var db = new MoviesContext();

            Console.Write("Movie name: ");
            var name = Console.ReadLine();

            Console.Write("Duration (min): ");
            int.TryParse(Console.ReadLine(), out int duration);

            db.Titles.Add(new Title
            {
                Name = name!,
                Duration = duration
            });

            db.SaveChanges();
            Console.WriteLine("Movie added.");
        }

        public static void ShowTitles()
        {
            using var db = new MoviesContext();
            var titles = db.Titles.ToList();

            Console.WriteLine("\nMovies:");
            foreach (var t in titles)
                Console.WriteLine($"{t.Id}. {t.Name} ({t.Duration} min)");
        }
    }
}
