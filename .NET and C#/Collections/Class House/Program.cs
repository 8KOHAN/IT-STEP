namespace IT_STEP
{
    public class Program
    {
        public static void Main()
        {
            House house = new House();

            Apartment apt1 = new Apartment(24);
            apt1.AddResident(new Resident("John"));
            apt1.AddResident(new Resident("Anna"));

            Apartment apt2 = new Apartment(22);
            apt2.AddResident(new Resident("Michael"));

            house.AddApartment(apt1);
            house.AddApartment(apt2);

            Console.WriteLine("Residents in the house:");

            foreach (var apartment in house)
            {
                Console.WriteLine($"Apartment #{apartment.ApartmentNumber}:");
                foreach (var resident in apartment)
                {
                    Console.WriteLine(" - " + resident);
                }
            }
        }
    }
}
