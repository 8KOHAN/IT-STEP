namespace IT_STEP
{
    public static class UserService
    {
        public static void RegisterUser()
        {
            using var db = new MoviesContext();

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Login: ");
            var login = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            db.Users.Add(new User
            {
                Name = name!,
                Login = login!,
                Password = password!
            });

            db.SaveChanges();
            Console.WriteLine("User registered successfully.");
        }

        public static void ShowUsers()
        {
            using var db = new MoviesContext();
            var users = db.Users.ToList();

            Console.WriteLine("\nUsers:");
            foreach (var u in users)
                Console.WriteLine($"{u.Id}. {u.Name} ({u.Login})");
        }
    }
}
