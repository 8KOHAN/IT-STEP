using Dapper;
using BoardGamesAnalytics.Data;
using BoardGamesAnalytics.Models;

namespace BoardGamesAnalytics.Repositories;

public class AnalyticsRepository
{
    public IEnumerable<SessionInfo> GetAllSessions()
    {
        using var connection = DbConnectionFactory.CreateConnection();

        return connection.Query<SessionInfo>(@"
            SELECT g.Title AS GameTitle,
                   m.FullName AS MemberName,
                   s.Date,
                   s.DurationMinutes
            FROM Sessions s
            JOIN Games g ON s.GameId = g.Id
            JOIN Members m ON s.MemberId = m.Id
            ORDER BY s.Date");
    }

    public IEnumerable<GameStats> GetTopGames()
    {
        using var connection = DbConnectionFactory.CreateConnection();

        return connection.Query<GameStats>(@"
            SELECT TOP 3
                g.Title,
                SUM(s.DurationMinutes) / 60.0 AS TotalHours
            FROM Sessions s
            JOIN Games g ON s.GameId = g.Id
            GROUP BY g.Title
            ORDER BY TotalHours DESC");
    }

    public IEnumerable<MemberStats> GetMembersRating()
    {
        using var connection = DbConnectionFactory.CreateConnection();

        return connection.Query<MemberStats>(@"
            SELECT m.FullName,
                   SUM(s.DurationMinutes) AS TotalMinutes
            FROM Sessions s
            JOIN Members m ON s.MemberId = m.Id
            GROUP BY m.FullName
            ORDER BY TotalMinutes DESC");
    }

    public GeneralStats GetGeneralStats()
    {
        using var connection = DbConnectionFactory.CreateConnection();

        return connection.QuerySingle<GeneralStats>(@"
            SELECT COUNT(*) AS TotalSessions,
                   SUM(DurationMinutes) AS TotalMinutes
            FROM Sessions");
    }

    public GeneralStats GetStatsByPeriod(DateTime start, DateTime end)
    {
        using var connection = DbConnectionFactory.CreateConnection();

        return connection.QuerySingle<GeneralStats>(@"
            SELECT COUNT(*) AS TotalSessions,
                   SUM(DurationMinutes) AS TotalMinutes
            FROM Sessions
            WHERE Date BETWEEN @Start AND @End",
            new { Start = start, End = end });
    }
}
