namespace IT_STEP
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = { 7, 14, 21, 3, 5, 28, 42, 9, 49, 1, 70 };

            Func<int[], int, int> countMultiples = (arr, n) =>
            {
                int count = 0;
                foreach (int value in arr)
                {
                    if (value % n == 0)
                        count++;
                }
                return count;
            };

            Console.WriteLine("Divisible by 7: " + countMultiples(numbers, 7));
            Console.WriteLine("Divisible by 3: " + countMultiples(numbers, 3));
            Console.WriteLine("Divisible by 5: " + countMultiples(numbers, 5));
            Console.WriteLine("Divisible by 10: " + countMultiples(numbers, 10));
        }
    }
}
