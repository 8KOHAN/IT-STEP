namespace IT_STEP
{
    public abstract class MusicalInstrument
    {
        protected string Name;
        protected string Characteristics;

        public MusicalInstrument(string name, string characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }

        public abstract void Sound();
        public abstract void History();

        public virtual void Show()
        {
            Console.WriteLine($"Instrument: {Name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Description: {Characteristics}");
        }
    }
}

