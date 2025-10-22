namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Warehouse warehouse = new Warehouse();

            warehouse.AddItem(new Item("Laptop", 10, 25000m, ItemCategory.Electronics));
            warehouse.AddItem(new Item("Desk", 5, 3000m, ItemCategory.Furniture));
            warehouse.AddItem(new Item("Apples", 100, 15m, ItemCategory.Food));

            warehouse.DisplayItems();

            warehouse.UpdateItem("Laptop", 8, 24500m);
            warehouse.DisplayItems();

            warehouse.RemoveItem("Desk");
            warehouse.DisplayItems();
        }
    }
}
