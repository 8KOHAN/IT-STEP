using BoardGamesManagement.Data;
using BoardGamesManagement.Entities;

namespace BoardGamesManagement;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDbContext();

        SeedDatabase(context);

        Console.WriteLine("Database created and seeded successfully.");
    }

    private static void SeedDatabase(AppDbContext context)
    {
        if (context.Games.Any())
            return;

        var games = new List<Game>
        {
            new() { Title = "Catan", Genre = "Strategy", MinPlayers = 3, MaxPlayers = 4 },
            new() { Title = "Carcassonne", Genre = "Tile", MinPlayers = 2, MaxPlayers = 5 },
            new() { Title = "Gloomhaven", Genre = "RPG", MinPlayers = 1, MaxPlayers = 4 },
            new() { Title = "Pandemic", Genre = "Cooperative", MinPlayers = 2, MaxPlayers = 4 },
            new() { Title = "Terraforming Mars", Genre = "Strategy", MinPlayers = 1, MaxPlayers = 5 }
        };

        var members = new List<Member>
        {
            new() { FullName = "John Smith", JoinDate = DateTime.Now.AddMonths(-12) },
            new() { FullName = "Emily Johnson", JoinDate = DateTime.Now.AddMonths(-10) },
            new() { FullName = "Michael Brown", JoinDate = DateTime.Now.AddMonths(-8) },
            new() { FullName = "Sarah Davis", JoinDate = DateTime.Now.AddMonths(-6) },
            new() { FullName = "David Wilson", JoinDate = DateTime.Now.AddMonths(-4) }
        };

        context.Games.AddRange(games);
        context.Members.AddRange(members);
        context.SaveChanges();

        var random = new Random();
        var sessions = new List<Session>();

        for (int i = 0; i < 20; i++)
        {
            var randomGame = games[random.Next(games.Count)];
            var randomMember = members[random.Next(members.Count)];

            sessions.Add(new Session
            {
                GameId = randomGame.Id,
                MemberId = randomMember.Id,
                Date = DateTime.Now.AddDays(-random.Next(60)),
                DurationMinutes = random.Next(30, 240)
            });
        }

        context.Sessions.AddRange(sessions);
        context.SaveChanges();
    }
}
