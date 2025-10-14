namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            Console.WriteLine($"Even numbers in the range {a} to {b}:");
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
