namespace IT_STEP
{
    public static class ViewService
    {
        public static void ShowUsersWithMovies()
        {
            using var db = new MoviesContext();

            var data = db.UserMoviesView.ToList();

            foreach (var item in data)
            {
                Console.WriteLine($"User: {item.Username} ({item.Email})");

                if (item.MovieId != null)
                    Console.WriteLine($"Movie: {item.Title} ({item.Year})");
                else
                    Console.WriteLine("No movies");

                Console.WriteLine();
            }
        }
    }
}
