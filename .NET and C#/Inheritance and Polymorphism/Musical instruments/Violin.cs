namespace IT_STEP
{
    public class Violin : MusicalInstrument
    {
        public Violin() : base("Violin", "A string instrument with four strings played with a bow") { }

        public override void Sound()
        {
            Console.WriteLine("The violin sounds bright and expressive 🎻");
            Console.Beep(800, 400);
            Console.Beep(1000, 400);
        }

        public override void History()
        {
            Console.WriteLine("The violin appeared in the 16th century in Italy, evolving from earlier string instruments.");
        }
    }
}
