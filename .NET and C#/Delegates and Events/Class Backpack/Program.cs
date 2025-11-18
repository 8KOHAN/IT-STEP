namespace IT_STEP
{
    public class Program
    {
        static void Main()
        {
            Backpack backpack = new Backpack
            {
                Color = "Black",
                Brand = "Nike",
                Fabric = "Polyester",
                Weight = 1.2,
                Capacity = 15.0
            };

            backpack.ObjectAdded += delegate (BackpackItem item)
            {
                Console.WriteLine($"[ADD] '{item.Name}' added with volume {item.Volume}");
            };

            backpack.ObjectRemoved += delegate (BackpackItem item)
            {
                Console.WriteLine($"[REMOVE] '{item.Name}' removed");
            };

            backpack.ObjectChanged += delegate (BackpackItem item)
            {
                Console.WriteLine($"[CHANGE] '{item.Name}' volume updated to {item.Volume}");
            };

            try
            {
                backpack.AddObject("Laptop", 3.0);
                backpack.AddObject("Water Bottle", 2.5);

                backpack.ChangeObject("Laptop", 4.0);

                backpack.RemoveObject("Water Bottle");

                backpack.AddObject("dumbbell", 20.0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR: " + ex.Message);
            }
        }
    }
}
