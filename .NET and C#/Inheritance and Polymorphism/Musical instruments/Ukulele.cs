namespace IT_STEP
{
    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Ukulele", "A small four-stringed guitar-like instrument") { }

        public override void Sound()
        {
            Console.WriteLine("The ukulele sounds cheerful and bright 🎶");
            Console.Beep(600, 300);
            Console.Beep(700, 300);
        }

        public override void History()
        {
            Console.WriteLine("The ukulele originated in Hawaii in the 19th century, inspired by Portuguese guitars.");
        }
    }
}
