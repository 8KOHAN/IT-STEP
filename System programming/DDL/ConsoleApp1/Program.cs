using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            MessageHelper.ShowMessage();

            // 2
            Console.WriteLine("Factorial 5 = " + MathHelper.Factorial(5));
            Console.WriteLine("7 simple? " + MathHelper.IsPrime(7));
            Console.WriteLine("10 even? " + MathHelper.IsEven(10));
            Console.WriteLine("9 odd? " + MathHelper.IsOdd(9));

            // 3
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(3, 4);

            Fraction result = f1.Add(f2);

            Console.Write("1/2 + 3/4 = ");
            result.Print();

            Console.WriteLine("in decimal form: " + result.ToDecimal());
        }
    }
}
