namespace App
{
    class Program
    {
        static List<int> numbers = new List<int>();
        static ManualResetEvent dataReadyEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread generatorThread = new Thread(GenerateNumbers);
            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread avgThread = new Thread(FindAverage);

            maxThread.Start();
            minThread.Start();
            avgThread.Start();

            generatorThread.Start();

            generatorThread.Join();
            maxThread.Join();
            minThread.Join();
            avgThread.Join();
        }

        static void GenerateNumbers()
        {
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(rand.Next(0, 5001));
            }

            Console.WriteLine("Number generation finished.");

            dataReadyEvent.Set();
        }

        static void FindMax()
        {
            dataReadyEvent.WaitOne();

            int max = int.MinValue;

            foreach (var n in numbers)
            {
                if (n > max)
                    max = n;
            }

            Console.WriteLine("Maximum value: " + max);
        }

        static void FindMin()
        {
            dataReadyEvent.WaitOne();

            int min = int.MaxValue;

            foreach (var n in numbers)
            {
                if (n < min)
                    min = n;
            }

            Console.WriteLine("Minimum value: " + min);
        }

        static void FindAverage()
        {
            dataReadyEvent.WaitOne();

            double sum = 0;

            foreach (var n in numbers)
            {
                sum += n;
            }

            double avg = sum / numbers.Count;

            Console.WriteLine("Average value: " + avg);
        }
    }
}
