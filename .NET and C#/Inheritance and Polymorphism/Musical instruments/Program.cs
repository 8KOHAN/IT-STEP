namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            MusicalInstrument[] instruments =
            {
                new Violin(),
                new Trombone(),
                new Ukulele(),
                new Cello()
            };

            foreach (var instrument in instruments)
            {
                Console.WriteLine("------------------------------");
                instrument.Show();
                instrument.Desc();
                instrument.History();
                instrument.Sound();
            }

            Console.WriteLine("\nAll instruments demonstrated!");
        }
    }
}
