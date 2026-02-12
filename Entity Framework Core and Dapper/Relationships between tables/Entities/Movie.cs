using System.ComponentModel.DataAnnotations;

namespace IT_STEP
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string? Description { get; set; } = "";
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
