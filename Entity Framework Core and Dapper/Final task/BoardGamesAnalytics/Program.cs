using BoardGamesAnalytics.Services;

namespace BoardGamesAnalytics;
public class Program
{
    public static void Main(string[] args)
    {
        var service = new AnalyticsService();

        while (true)
        {
            Console.WriteLine("\n=== BOARD GAMES ANALYTICS ===");
            Console.WriteLine("1 - All sessions");
            Console.WriteLine("2 - Top 3 games");
            Console.WriteLine("3 - Participant rating");
            Console.WriteLine("4 - General statistics");
            Console.WriteLine("5 - Statistics for the period");
            Console.WriteLine("0 - Exit");

            Console.Write("Select option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    service.ShowAllSessions();
                    break;

                case "2":
                    service.ShowTopGames();
                    break;

                case "3":
                    service.ShowMembersRating();
                    break;

                case "4":
                    service.ShowGeneralStats();
                    break;

                case "5":
                    service.ShowStatsByPeriod();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
