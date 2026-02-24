using BoardGamesAnalytics.Repositories;

namespace BoardGamesAnalytics.Services;

public class AnalyticsService
{
    private readonly AnalyticsRepository _repository = new();

    public void ShowAllSessions()
    {
        var sessions = _repository.GetAllSessions();

        foreach (var s in sessions)
            Console.WriteLine($"{s.GameTitle} | {s.MemberName} | {s.Date:d} | {s.DurationMinutes} min");
    }

    public void ShowTopGames()
    {
        var games = _repository.GetTopGames();

        foreach (var g in games)
            Console.WriteLine($"{g.Title} - {g.TotalHours:F2} hours");
    }

    public void ShowMembersRating()
    {
        var members = _repository.GetMembersRating();

        foreach (var m in members)
            Console.WriteLine($"{m.FullName} - {m.TotalMinutes} min");
    }

    public void ShowGeneralStats()
    {
        var stats = _repository.GetGeneralStats();

        Console.WriteLine($"Sessions: {stats.TotalSessions}");
        Console.WriteLine($"Total Duration: {stats.TotalMinutes} min");
    }

    public void ShowStatsByPeriod()
    {
        Console.Write("Start Date (yyyy-MM-dd): ");
        var start = DateTime.Parse(Console.ReadLine());

        Console.Write("End Date (yyyy-MM-dd): ");
        var end = DateTime.Parse(Console.ReadLine());

        var stats = _repository.GetStatsByPeriod(start, end);

        Console.WriteLine($"Sessions: {stats.TotalSessions}");
        Console.WriteLine($"Minutes: {stats.TotalMinutes}");
    }
}
