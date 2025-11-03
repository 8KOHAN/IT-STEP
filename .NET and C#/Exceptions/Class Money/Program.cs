namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            try
            {
                Money a = new Money(10, 50);
                Money b = new Money(3, 75);

                Console.WriteLine($"A = {a}");
                Console.WriteLine($"B = {b}");
                Console.WriteLine($"A + B = {a + b}");
                Console.WriteLine($"A - B = {a - b}");
                Console.WriteLine($"A * 2 = {a * 2}");
                Console.WriteLine($"A / 2 = {a / 2}");
                Console.WriteLine($"++A = {++a}");
                Console.WriteLine($"--B = {--b}");
                Console.WriteLine($"A > B ? {a > b}");
                Console.WriteLine($"A == B ? {a == b}");
            }
            catch (BankruptException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
