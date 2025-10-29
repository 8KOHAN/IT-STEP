namespace IT_STEP
{
    public class Trombone : MusicalInstrument
    {
        public Trombone() : base("Trombone", "A brass instrument with a telescoping slide mechanism") { }

        public override void Sound()
        {
            Console.WriteLine("The trombone produces a deep and powerful sound 🎺");
            Console.Beep(200, 400);
            Console.Beep(300, 400);
        }

        public override void History()
        {
            Console.WriteLine("The trombone was developed in the 15th century and used in churches and military bands.");
        }
    }
}

