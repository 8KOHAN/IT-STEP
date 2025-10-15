namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            const int rows = 5;
            const int cols = 5;
            const int minValue = -100;
            const int maxValue = 100;

            int[,] matrix = CreateMatrix(rows, cols, minValue, maxValue);

            Console.WriteLine("Matrix:");
            PrintMatrix(matrix);

            int sum = SumBetweenMinMax(matrix);
            Console.WriteLine($"\nSum of elements between min and max: {sum}");
        }

        static int[,] CreateMatrix(int rows, int cols, int minVal, int maxVal)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(minVal, maxVal + 1);
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static int SumBetweenMinMax(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int totalElements = rows * cols;

            int[] flat = new int[totalElements];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    flat[index++] = matrix[i, j];
            }

            int minIndex = 0;
            int maxIndex = 0;
            for (int i = 1; i < flat.Length; i++)
            {
                if (flat[i] < flat[minIndex])
                    minIndex = i;
                if (flat[i] > flat[maxIndex])
                    maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex) + 1;
            int end = Math.Max(minIndex, maxIndex);

            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += flat[i];
            }

            return sum;
        }
    }
}
