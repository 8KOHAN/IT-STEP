namespace BoardGamesManagement.Entities;

public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime JoinDate { get; set; }
    
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
