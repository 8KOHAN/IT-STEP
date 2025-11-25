namespace IT_STEP
{
    public class Resident
    {
        public string Name { get; set; }

        public Resident(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
