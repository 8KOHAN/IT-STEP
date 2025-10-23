namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            Product apples = new Product("Apples", 50, 1.25);
            Product oranges = new Product("Oranges", 30, 1.25);

            Console.WriteLine("Initial products:");
            Console.WriteLine(apples);
            Console.WriteLine(oranges);

            apples = apples + 10;
            oranges = oranges - 5;

            Console.WriteLine("\nAfter changes:");
            Console.WriteLine(apples);
            Console.WriteLine(oranges);

            Console.WriteLine($"\nDo apples and oranges have the same price? {(apples == oranges)}");

            Console.WriteLine(apples > oranges
                ? "Apples have more quantity."
                : "Oranges have more or equal quantity.");
        }
    }
}
