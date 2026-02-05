namespace IT_STEP
{
    public static class Menu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("""
                ===== Movies App =====
                1. Users
                2. Movies
                0. Exit
                """);

                switch (Console.ReadLine())
                {
                    case "1":
                        UsersMenu();
                        break;
                    case "2":
                        MoviesMenu();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private static void UsersMenu()
        {
            while (true)
            {
                Console.WriteLine("""
                --- Users ---
                1. Register user
                2. Show users
                0. Back
                """);

                switch (Console.ReadLine())
                {
                    case "1":
                        UserService.RegisterUser();
                        break;
                    case "2":
                        UserService.ShowUsers();
                        break;
                    case "0":
                        return;
                }
            }
        }

        private static void MoviesMenu()
        {
            while (true)
            {
                Console.WriteLine("""
                --- Movies ---
                1. Add movie
                2. Show movies
                0. Back
                """);

                switch (Console.ReadLine())
                {
                    case "1":
                        TitleService.AddTitle();
                        break;
                    case "2":
                        TitleService.ShowTitles();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}

