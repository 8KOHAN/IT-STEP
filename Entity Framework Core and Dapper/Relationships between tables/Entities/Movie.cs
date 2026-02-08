namespace IT_STEP
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string Description { get; set; } = "";

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
