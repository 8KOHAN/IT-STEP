namespace IT_STEP
{
    public class BackpackItem
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public BackpackItem(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}
