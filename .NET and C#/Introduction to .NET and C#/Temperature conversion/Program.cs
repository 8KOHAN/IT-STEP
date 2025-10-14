namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the temperature: ");
            double temp = Convert.ToDouble(Console.ReadLine());

            Console.Write("Choose the conversion direction (1 - F→C, 2 - C→F): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                double celsius = (temp - 32) * 5 / 9;
                Console.WriteLine($"Temperature in Celsius: {celsius:F2}°C");
            }
            else if (choice == 2)
            {
                double fahrenheit = temp * 9 / 5 + 32;
                Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit:F2}°F");
            }
            else 
                Console.WriteLine("Wrong choice");
        }
    }
}
