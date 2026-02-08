namespace IT_STEP
{
    public static class AuthService
    {
        public static User? CurrentUser { get; private set; }

        public static void Register()
        {
            using var db = new MoviesContext();

            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            db.Users.Add(new User
            {
                Username = username!,
                Email = email!,
                Password = password!
            });

            db.SaveChanges();
            Console.WriteLine("User registered.");
        }

        public static bool Login()
        {
            using var db = new MoviesContext();

            Console.Write("Username: ");
            var username = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            var password = Console.ReadLine() ?? "";

            var user = db.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }

            CurrentUser = user;
            Console.WriteLine($"Welcome, {user.Username}!");
            return true;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
