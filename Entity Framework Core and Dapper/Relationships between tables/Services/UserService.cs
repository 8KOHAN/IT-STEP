namespace IT_STEP
{
    public static class UserService
    {
        public static void EditProfile()
        {
            using var db = new MoviesContext();
            var user = db.Users.Find(AuthService.CurrentUser!.Id);

            Console.Write("New email: ");
            user!.Email = Console.ReadLine()!;

            Console.Write("New password: ");
            user.Password = Console.ReadLine()!;

            db.SaveChanges();
            Console.WriteLine("Profile updated.");
        }

        public static void ShowUsersWithMovies()
        {
            using var db = new MoviesContext();
            var users = db.Users
                          .Select(u => new
                          {
                              u.Username,
                              Movies = u.Movies.Select(m => m.Title)
                          })
                          .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Username}");
                foreach (var movie in user.Movies)
                {
                    Console.WriteLine($"  Movie: {movie}");
                }
            }
        }
    }
}
