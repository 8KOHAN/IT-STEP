namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            Employee e1 = new Employee("Alice Johnson", 28, 45000m);
            Employee e2 = new Employee("Bob Smith", null, 38000m);
            Employee e3 = new Employee("Charlie Davis", 35, null);
            Employee e4 = new Employee("Dana White", null, null);

            e1.DisplayInfo();
            e2.DisplayInfo();
            e3.DisplayInfo();
            e4.DisplayInfo();
        }
    }
}
