namespace BoardGamesManagement.Entities;

public class Session
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int MemberId { get; set; }
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }

    public Game Game { get; set; } = null!;
    public Member Member { get; set; } = null!;
}
