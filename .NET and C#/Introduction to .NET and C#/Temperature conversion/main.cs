namespace IT_STEP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;


            Console.Write("Введіть температуру: ");
            double temp = Convert.ToDouble(Console.ReadLine());

            Console.Write("Оберіть напрямок конвертації (1 - F→C, 2 - C→F): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                double celsius = (temp - 32) * 5 / 9;
                Console.WriteLine($"Температура у Цельсіях: {celsius:F2}°C");
            }
            else if (choice == 2)
            {
                double fahrenheit = temp * 9 / 5 + 32;
                Console.WriteLine($"Температура у Фаренгейтах: {fahrenheit:F2}°F");
            }
            else 
                Console.WriteLine("Невірний вибір.");
        }
    }
}
