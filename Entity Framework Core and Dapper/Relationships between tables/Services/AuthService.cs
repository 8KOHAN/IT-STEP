using Microsoft.EntityFrameworkCore;

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

            db.Database.ExecuteSqlRaw(
                "EXEC AddUser @Username = {0}, @Email = {1}, @Password = {2}",
                username, email, password);

            Console.WriteLine("User registered via stored procedure.");
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
