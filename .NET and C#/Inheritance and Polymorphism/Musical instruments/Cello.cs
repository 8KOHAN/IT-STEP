namespace IT_STEP
{
    public class Cello : MusicalInstrument
    {
        public Cello() : base("Cello", "A bowed string instrument with a warm, rich tone") { }

        public override void Sound()
        {
            Console.WriteLine("The cello sounds deep and mellow");
            Console.Beep(300, 400);
            Console.Beep(400, 400);
        }

        public override void History()
        {
            Console.WriteLine("The cello appeared in the 16th century in Italy and became a key orchestral instrument.");
        }
    }
}
