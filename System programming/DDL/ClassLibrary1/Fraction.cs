namespace ClassLibrary1
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public double ToDecimal()
        {
            return (double)Numerator / Denominator;
        }

        public Fraction Add(Fraction other)
        {
            int num = Numerator * other.Denominator + other.Numerator * Denominator;
            int den = Denominator * other.Denominator;

            return new Fraction(num, den);
        }

        public Fraction Subtract(Fraction other)
        {
            int num = Numerator * other.Denominator - other.Numerator * Denominator;
            int den = Denominator * other.Denominator;

            return new Fraction(num, den);
        }

        public void Print()
        {
            Console.WriteLine($"{Numerator}/{Denominator}");
        }
    }
}
