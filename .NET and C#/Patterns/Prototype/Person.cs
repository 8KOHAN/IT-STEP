namespace IT_STEP
{
    public class Person
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public IdInfo IdInfo { get; set; }

        public Person DeepCopy()
        {
            return new Person
            {
                Age = Age,
                BirthDate = BirthDate,
                Name = Name,              
                IdInfo = new IdInfo(IdInfo.IdNumber)
            };
        }

    }
}
