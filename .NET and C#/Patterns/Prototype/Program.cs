namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            var original = new Person
            {
                Age = 33,
                BirthDate = new DateTime(1992, 1, 20),
                Name = "Jack Daniels",
                IdInfo = new IdInfo(1)
            };

            var copy = original.DeepCopy();

            Print("Original (before the changes)", original);
            Print("Copy (before the changes)", copy);

            original.Age = 25;
            original.BirthDate = new DateTime(2000, 6, 12);
            original.Name = "Frank";
            original.IdInfo.IdNumber = 2;

            Print("Original (after the changes)", original);
            Print("Copy (after the changes)", copy);
        }

        static void Print(string title, Person person)
        {
            Console.WriteLine(title);
            Console.WriteLine($"  Name: {person.Name}");
            Console.WriteLine($"  Age: {person.Age}");
            Console.WriteLine($"  BirthDate: {person.BirthDate:dd.MM.yyyy}");
            Console.WriteLine($"  ID: {person.IdInfo.IdNumber}");
            Console.WriteLine();
        }
    }
}
