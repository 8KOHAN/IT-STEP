namespace IT_STEP
{
    public static class MovieService
    {
        public static void AddMovie()
        {
            using var db = new MoviesContext();

            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Year: ");
            int.TryParse(Console.ReadLine(), out int year);

            Console.Write("Description: ");
            var description = Console.ReadLine();

            db.Movies.Add(new Movie
            {
                Title = title!,
                Year = year,
                Description = description!,
                UserId = AuthService.CurrentUser!.Id
            });

            db.SaveChanges();
            Console.WriteLine("Movie added.");
        }

        public static void DeleteMovie()
        {
            using var db = new MoviesContext();

            var movies = db.Movies
                .Where(m => m.UserId == AuthService.CurrentUser!.Id)
                .ToList();

            foreach (var m in movies)
                Console.WriteLine($"{m.Id}. {m.Title}");

            Console.Write("Movie ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);

            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                Console.WriteLine("You can delete only your own movies.");
                return;
            }

            db.Movies.Remove(movie);
            db.SaveChanges();
            Console.WriteLine("Movie deleted.");
        }
    }
}
