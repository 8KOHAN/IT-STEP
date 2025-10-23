namespace IT_STEP
{
    struct DecimalNumber
    {
        public int Value { get; set; }

        public DecimalNumber(int value)
        {
            Value = value;
        }
      
        public string ToBinary()
        {
            return Convert.ToString(Value, 2);
        }
      
        public string ToOctal()
        {
            return Convert.ToString(Value, 8);
        }
      
        public string ToHexadecimal()
        {
            return Convert.ToString(Value, 16).ToUpper();
        }
      
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            DecimalNumber number = new DecimalNumber(255);

            Console.WriteLine($"Decimal number: {number}");
            Console.WriteLine($"Binary system: {number.ToBinary()}");
            Console.WriteLine($"Octal system: {number.ToOctal()}");
            Console.WriteLine($"Hexadecimal system: {number.ToHexadecimal()}");
        }
    }
}
