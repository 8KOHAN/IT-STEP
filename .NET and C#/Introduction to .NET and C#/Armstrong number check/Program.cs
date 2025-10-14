namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int temp = number;
            int sum = 0;
            int digits = number.ToString().Length;

            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }

            if (sum == number)
                Console.WriteLine($"{number} is Armstrong's number");
            else
                Console.WriteLine($"{number} is not an Armstrong number");
        }
    }
}
