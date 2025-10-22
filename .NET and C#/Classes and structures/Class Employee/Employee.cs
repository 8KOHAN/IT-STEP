namespace IT_STEP
{
    internal class Employee
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }

        public Employee(string name, int? age, decimal? salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Employee Information:");
            Console.WriteLine($"Name: {Name}");

            if (Age.HasValue)
                Console.WriteLine($"Age: {Age.Value}");
            else
                Console.WriteLine("Age: (not specified)");

            if (Salary.HasValue)
                Console.WriteLine($"Salary: {Salary.Value:C}");
            else
                Console.WriteLine("Salary: (not specified)");

            Console.WriteLine(new string('-', 30));
        }
    }
}
