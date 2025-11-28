namespace IT_STEP
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {FullName},\n" +
                $"Position: {Position},\n" +
                $"Phone: {Phone},\n" +
                $"Email: {Email},\n" +
                $"Salary: {Salary},\n";
        }
    }
}
