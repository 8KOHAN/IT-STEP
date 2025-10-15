using System.Text;

namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter an arithmetic expression containing only + and - (integers allowed):");
            string input = Console.ReadLine();

            try
            {
                long result = EvaluateExpression(input ?? string.Empty);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Input error: {fe.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numeric overflow occurred while calculating the expression.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        static long EvaluateExpression(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
                throw new FormatException("Expression is empty.");

            int i = 0;
            int n = expr.Length;

            void SkipSpaces()
            {
                while (i < n && char.IsWhiteSpace(expr[i])) i++;
            }

            long result = 0;

            SkipSpaces();

            int currentSign = +1;
            bool haveLeadingSign = false;
            while (i < n && (expr[i] == '+' || expr[i] == '-'))
            {
                haveLeadingSign = true;
                if (expr[i] == '-') currentSign *= -1;
                i++;
                SkipSpaces();
            }

            long firstNumber = ReadInteger(expr, ref i, n);
            result = checked(result + currentSign * firstNumber);

            SkipSpaces();

            while (i < n)
            {
                SkipSpaces();
                if (i >= n) break;

                char op = expr[i];
                if (op != '+' && op != '-')
                    throw new FormatException($"Unexpected character '{expr[i]}' at position {i + 1}. Expected '+' or '-'.");

                int nextSign = (op == '+') ? +1 : -1;
                i++;
                SkipSpaces();

                while (i < n && (expr[i] == '+' || expr[i] == '-'))
                {
                    if (expr[i] == '-') nextSign *= -1;
                    i++;
                    SkipSpaces();
                }

                long number = ReadInteger(expr, ref i, n);
                result = checked(result + nextSign * number);

                SkipSpaces();
            }

            return result;
        }

        static long ReadInteger(string expr, ref int i, int n)
        {
            if (i >= n || !char.IsDigit(expr[i]))
                throw new FormatException($"Expected a number at position {i + 1}.");

            int start = i;
            StringBuilder sb = new StringBuilder();
            while (i < n && char.IsDigit(expr[i]))
            {
                sb.Append(expr[i]);
                i++;
            }

            string numStr = sb.ToString();
            if (!long.TryParse(numStr, out long value))
                throw new OverflowException("Number is too large.");

            return value;
        }
    }
}
