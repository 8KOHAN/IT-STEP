namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            using var db = new MoviesContext();
            db.Database.EnsureCreated();

            Menu.MainMenu();
        }
    }
}
