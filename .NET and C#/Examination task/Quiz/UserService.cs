using System.Text.Json;

namespace IT_STEP
{
    public class UserService
    {
        private readonly string _filePath;
        private List<User> _users = new List<User>();

        public UserService(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_filePath))
            {
                _users = new List<User>();
                return;
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch
            {
                Console.WriteLine("Warning: users file damaged. Starting fresh.");
                _users = new List<User>();
            }
        }

        private void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch
            {
                Console.WriteLine("Error saving users file.");
            }
        }

        public User Register()
        {
            string username = ReadNonEmpty("Enter username: ");

            while (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("User already exists.");
                username = ReadNonEmpty("Enter username: ");
            }

            string password = ReadPassword();
            DateTime birth = ReadValidDate("Enter birth date (yyyy-mm-dd): ");

            User user = new User
            {
                Username = username,
                Password = password,
                BirthDate = birth
            };

            _users.Add(user);
            Save();
            return user;
        }

        public User Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            var user = _users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && u.Password == password
            );

            if (user == null)
            {
                Console.WriteLine("Incorrect login.");
                return Login();
            }

            return user;
        }

        public void Settings(User user)
        {
            Console.WriteLine("1 - Change password");
            Console.WriteLine("2 - Change birth date");

            string choice = ReadNonEmpty("Choice: ");

            if (choice == "1")
            {
                user.Password = ReadPassword();
            }
            else if (choice == "2")
            {
                user.BirthDate = ReadValidDate("New birth date (yyyy-mm-dd): ");
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Save();
        }

        private string ReadNonEmpty(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Input cannot be empty.");
            }
        }

        private string ReadPassword()
        {
            while (true)
            {
                Console.Write("Enter password (min 4 chars): ");
                string? p = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(p) && p.Length >= 4)
                    return p;

                Console.WriteLine("Password too short.");
            }
        }

        private DateTime ReadValidDate(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out var date))
                    return date;

                Console.WriteLine("Invalid date.");
            }
        }
    }
}
