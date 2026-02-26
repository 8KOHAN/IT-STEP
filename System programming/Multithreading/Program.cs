namespace SuperApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using Timer timer = new Timer(new TimerCallback(TimerMethod));
            timer.Change(2000, 1000);

            Console.ReadKey();
        }

        public static void TimerMethod(object timer)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);
        }
    }
}
