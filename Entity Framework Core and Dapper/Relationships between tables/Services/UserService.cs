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
    }
}
