namespace IT_STEP
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int Employees { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Founded: {Founded.ToShortDateString()}\n" +
                   $"Business Profile: {BusinessProfile}\n" +
                   $"Director: {DirectorFullName}\n" +
                   $"Employees: {Employees}\n" +
                   $"Address: {Address}\n";
        }
    }
}
