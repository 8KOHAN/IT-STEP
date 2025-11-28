namespace IT_STEP
{
    public class Program
    {
        public static void Main()
        {
         var firms = new List<Firm>
            {
                new Firm
                {
                    Name = "Global Food Corp",
                    Founded = new DateTime(2019,5,10),
                    BusinessProfile = "Marketing",
                    DirectorFullName = "John White",
                    Employees = 150,
                    Address = "London",
                    EmployeesList = new List<Employee>
                    {
                        new Employee { FullName="Lionel Messi", Position="Manager", Phone="23123456", Email="di.messi@mail.com", Salary=3000 },
                        new Employee { FullName="Sarah Johnson", Position="Analyst", Phone="23888877", Email="sarah.j@mail.com", Salary=2500 }
                    }
                },

                new Firm
                {
                    Name = "IT White Solutions",
                    Founded = new DateTime(2020,3,1),
                    BusinessProfile = "IT",
                    DirectorFullName = "Mark Black",
                    Employees = 80,
                    Address = "Manchester",
                    EmployeesList = new List<Employee>
                    {
                        new Employee { FullName="Lionel Ritchie", Position="Developer", Phone="23999888", Email="lionel.r@mail.com", Salary=4000 },
                        new Employee { FullName="David Irving", Position="Manager", Phone="23111222", Email="di.irving@mail.com", Salary=3500 }
                    }
                }
            };

        // ------------------------------
        // TASK 1 — FIRM QUERIES
        // ------------------------------

        PrintTitle("All firms");
        PrintFirms(firms);

        PrintTitle("Firms containing 'Food' in their name");
        PrintFirms(firms.Where(f => f.Name.Contains("Food")));

        PrintTitle("Firms in the Marketing sector");
        PrintFirms(firms.Where(f => f.BusinessProfile == "Marketing"));

        PrintTitle("Firms in Marketing or IT");
        PrintFirms(firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT"));

        PrintTitle("Firms with more than 100 employees");
        PrintFirms(firms.Where(f => f.Employees > 100));

        PrintTitle("Firms with 100–300 employees");
        PrintFirms(firms.Where(f => f.Employees >= 100 && f.Employees <= 300));

        PrintTitle("Firms located in London");
        PrintFirms(firms.Where(f => f.Address == "London"));

        PrintTitle("Firms whose director's surname is White");
        PrintFirms(firms.Where(f => f.DirectorFullName.Split(' ').Last() == "White"));

        PrintTitle("Firms founded more than 2 years ago");
        PrintFirms(firms.Where(f => (DateTime.Now - f.Founded).TotalDays > 365 * 2));

        PrintTitle("Firms founded 123 or more days ago");
        PrintFirms(firms.Where(f => (DateTime.Now - f.Founded).TotalDays >= 123));

        PrintTitle("Firms with director Black AND name contains 'White'");
        PrintFirms(firms.Where(f =>
            f.DirectorFullName.Split(' ').Last() == "Black" &&
            f.Name.Contains("White")));


        // ------------------------------
        // TASK 3 — EMPLOYEE QUERIES
        // ------------------------------

        PrintTitle("Employees of 'Global Food Corp'");
        var employeesOfFoodCorp = firms
            .First(f => f.Name == "Global Food Corp")
            .EmployeesList;
        PrintEmployees(employeesOfFoodCorp);

        PrintTitle("Employees of 'Global Food Corp' with salary > 3000");
        var highPaid = employeesOfFoodCorp.Where(e => e.Salary > 3000);
        PrintEmployees(highPaid);

        PrintTitle("All managers across all firms");
        var managers = firms.SelectMany(f => f.EmployeesList)
            .Where(e => e.Position.Equals("Manager", StringComparison.OrdinalIgnoreCase));
        PrintEmployees(managers);

        PrintTitle("Employees whose phone starts with '23'");
        var phone23 = firms.SelectMany(f => f.EmployeesList)
            .Where(e => e.Phone.StartsWith("23"));
        PrintEmployees(phone23);

        PrintTitle("Employees whose email starts with 'di'");
        var emailDi = firms.SelectMany(f => f.EmployeesList)
            .Where(e => e.Email.StartsWith("di", StringComparison.OrdinalIgnoreCase));
        PrintEmployees(emailDi);

        PrintTitle("Employees whose first name is 'Lionel'");
        var lionels = firms.SelectMany(f => f.EmployeesList)
            .Where(e => e.FullName.Split(' ')[0] == "Lionel");
        PrintEmployees(lionels);
        }

        static void PrintTitle(string title)
        {
            Console.WriteLine($"\n=== {title} ===");
        }

        static void PrintFirms(IEnumerable<Firm> firms)
        {
            foreach (var f in firms)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(f);
            }
            Console.WriteLine();
        }

        static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var e in employees)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(e);
            }
            Console.WriteLine();
        }
    }
}
