namespace IT_STEP
{
    public class Backpack
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Fabric { get; set; }
        public double Weight { get; set; }
        public double Capacity { get; set; }

        private List<BackpackItem> items = new List<BackpackItem>();

        public event Action<BackpackItem> ObjectAdded;
        public event Action<BackpackItem> ObjectRemoved;
        public event Action<BackpackItem> ObjectChanged;

        private double CurrentVolume()
        {
            double sum = 0;
            foreach (BackpackItem item in items)
                sum += item.Volume;
            return sum;
        }

        public void AddObject(string name, double volume)
        {
            if (CurrentVolume() + volume > Capacity)
                throw new InvalidOperationException("Backpack capacity exceeded!");

            BackpackItem newItem = new BackpackItem(name, volume);
            items.Add(newItem);

            ObjectAdded?.Invoke(newItem);
        }

        public void RemoveObject(string name)
        {
            BackpackItem? item = items.Find(i => i.Name == name);
            if (item != null)
            {
                items.Remove(item);
                ObjectRemoved?.Invoke(item);
            }
        }

        public void ChangeObject(string name, double newVolume)
        {
            BackpackItem? item = items.Find(i => i.Name == name);
            if (item == null)
                throw new ArgumentException("Object not found in backpack!");

            double otherVolume = CurrentVolume() - item.Volume;

            if (otherVolume + newVolume > Capacity)
                throw new InvalidOperationException("Backpack capacity exceeded!");

            item.Volume = newVolume;

            ObjectChanged?.Invoke(item);
        }
    }
}
