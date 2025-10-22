namespace IT_STEP
{
    public struct Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ItemCategory Category { get; set; }

        public Item(string name, int quantity, decimal price, ItemCategory category)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} | Quantity: {Quantity} | Price: {Price} | Category: {Category}";
        }
    }
}
