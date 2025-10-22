namespace IT_STEP
{
    public class Warehouse
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Item {item.Name} added to warehouse.");
        }

        public void RemoveItem(string name)
        {
            var item = items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(item.Name))
            {
                items.Remove(item);
                Console.WriteLine($"Item {name} removed from warehouse.");
            }
            else
            {
                Console.WriteLine($"Item {name} not found.");
            }
        }

        public void UpdateItem(string name, int newQuantity, decimal newPrice)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    items[i] = new Item(name, newQuantity, newPrice, items[i].Category);
                    Console.WriteLine($"Item {name} updated.");
                    return;
                }
            }
            Console.WriteLine($"Item {name} not found for update.");
        }

        public void DisplayItems()
        {
            Console.WriteLine("\nCurrent items in warehouse:");
            if (items.Count == 0)
            {
                Console.WriteLine("The warehouse is empty.");
            }
            else
            {
                foreach (var item in items)
                    Console.WriteLine(item);
            }
        }
    }
}
