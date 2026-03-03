using System;
using System.Threading.Tasks;

namespace BreakfastApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting breakfast preparation...\n");

            Task<CoffeeCup> coffeeTask = PourCoffeeAsync();
            Task<Egg> eggsTask = FryEggsAsync();
            Task<Bacon> baconTask = FryBaconAsync();
            Task<Toast> toastTask = MakeToastWithJamAsync();
            Task<Juice> juiceTask = PourJuiceAsync();

            await Task.WhenAll(coffeeTask, eggsTask, baconTask, toastTask, juiceTask);

            Console.WriteLine("\nBreakfast is ready!");
        }

        static async Task<CoffeeCup> PourCoffeeAsync()
        {
            Console.WriteLine("Starting to pour coffee...");
            await Task.Delay(1000);
            Console.WriteLine("Coffee is ready!");
            return new CoffeeCup();
        }

        static async Task<Egg> FryEggsAsync()
        {
            Console.WriteLine("Starting to cook eggs...");
            await Task.Delay(2000);
            Console.WriteLine("Eggs are ready!");
            return new Egg();
        }

        static async Task<Bacon> FryBaconAsync()
        {
            Console.WriteLine("Starting to fry bacon...");
            await Task.Delay(2500);
            Console.WriteLine("Bacon is ready!");
            return new Bacon();
        }

        static async Task<Toast> MakeToastWithJamAsync()
        {
            Console.WriteLine("Starting to toast bread...");
            await Task.Delay(1500);

            Console.WriteLine("Spreading jam on toast...");
            await Task.Delay(500);

            Console.WriteLine("Toast with jam is ready!");
            return new Toast();
        }

        static async Task<Juice> PourJuiceAsync()
        {
            Console.WriteLine("Pouring juice...");
            await Task.Delay(800);
            Console.WriteLine("Juice is ready!");
            return new Juice();
        }
    }

    class CoffeeCup { }
    class Egg { }
    class Bacon { }
    class Toast { }
    class Juice { }
}
