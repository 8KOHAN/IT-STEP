namespace IT_STEP
{
    public class Program
    {
        public static void Main()
        {
            var firms = new List<Firm>
            {
                new Firm { Name="Global Food Corp", Founded=new DateTime(2019,5,10),
                    BusinessProfile="Marketing", DirectorFullName="John White",
                    Employees=150, Address="London" },

                new Firm { Name="IT White Solutions", Founded=new DateTime(2020,3,1),
                    BusinessProfile="IT", DirectorFullName="Mark Black",
                    Employees=80, Address="Manchester" },

                new Firm { Name="MarketPro", Founded=new DateTime(2022,1,15),
                    BusinessProfile="Marketing", DirectorFullName="Susan Green",
                    Employees=250, Address="London" },

                new Firm { Name="FoodLine Services", Founded=new DateTime(2024,1,1),
                    BusinessProfile="Logistics", DirectorFullName="Alan White",
                    Employees=50, Address="Liverpool" }
            };

            Console.WriteLine("=== All firms ===");
            Print(firms);
            Console.WriteLine();

            Console.WriteLine("=== Firms whose names contain 'Food' ===");
            Print(firms.Where(f => f.Name.Contains("Food")));
            Console.WriteLine();

            Console.WriteLine("=== Firms in the Marketing sector ===");
            Print(firms.Where(f => f.BusinessProfile == "Marketing"));
            Console.WriteLine();

            Console.WriteLine("=== Firms in Marketing or IT ===");
            Print(firms.Where(f =>
                f.BusinessProfile == "Marketing" ||
                f.BusinessProfile == "IT"));
            Console.WriteLine();

            Console.WriteLine("=== Firms with more than 100 employees ===");
            Print(firms.Where(f => f.Employees > 100));
            Console.WriteLine();

            Console.WriteLine("=== Firms with 100–300 employees ===");
            Print(firms.Where(f => f.Employees >= 100 && f.Employees <= 300));
            Console.WriteLine();

            Console.WriteLine("=== Firms located in London ===");
            Print(firms.Where(f => f.Address == "London"));
            Console.WriteLine();

            Console.WriteLine("=== Firms whose director's surname is White ===");
            Print(firms.Where(f => f.DirectorFullName.Split(' ').Last() == "White"));
            Console.WriteLine();

            Console.WriteLine("=== Firms founded more than two years ago ===");
            Print(firms.Where(f => (DateTime.Now - f.Founded).TotalDays > 365 * 2));
            Console.WriteLine();

            Console.WriteLine("=== Firms founded 123 or more days ago ===");
            Print(firms.Where(f => (DateTime.Now - f.Founded).TotalDays >= 123));
            Console.WriteLine();

            Console.WriteLine("=== Firms with director Black AND whose name contains 'White' ===");
            Print(firms.Where(f =>
                f.DirectorFullName.Split(' ').Last() == "Black" &&
                f.Name.Contains("White")));
            Console.WriteLine();
        }
        static void Print(IEnumerable<Firm> firms)
        {
            foreach (var f in firms)
            {
                Console.WriteLine(f);
            }
        }
    }
}
