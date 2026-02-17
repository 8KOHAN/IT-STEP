namespace IT_STEP
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("""
                1. Register
                2. Login
                0. Exit
                """);

                switch (Console.ReadLine())
                {
                    case "1": AuthService.Register(); break;
                    case "2":
                        if (AuthService.Login())
                            UserMenu();
                        break;
                    case "0": return;
                }
            }
        }

        private static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("""
                --- User Menu ---
                1. Add movie
                2. Delete movie
                3. Edit profile
                4. Show all users and their movies
                0. Logout
                """);

                switch (Console.ReadLine())
                {
                    case "1": MovieService.AddMovie(); break;
                    case "2": MovieService.DeleteMovie(); break;
                    case "3": UserService.EditProfile(); break;
                    case "4": UserService.ShowUsersWithMovies(); break;
                    case "0":
                        AuthService.Logout();
                        return;
                }
            }
        }
    }
}
