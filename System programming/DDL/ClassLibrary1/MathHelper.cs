namespace ClassLibrary1
{
    public class MathHelper
    {
        public static long Factorial(int n)
        {
            long result = 1;

            for (int i = 1; i <= n; i++)
                result *= i;

            return result;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
