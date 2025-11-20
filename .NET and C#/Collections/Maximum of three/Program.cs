namespace IT_STEP
{
    public class Program
    {
        public static void Main()
        {
            int result = MaxOfThree(5, 12, 9);
            Console.WriteLine(result);

            double result2 = MaxOfThree(3.14, 2.7, 3.1415);
            Console.WriteLine(result2);

        }

        public static T MaxOfThree<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;

            if (b.CompareTo(max) > 0)
                max = b;

            if (c.CompareTo(max) > 0)
                max = c;

            return max;
        }
    }
}
