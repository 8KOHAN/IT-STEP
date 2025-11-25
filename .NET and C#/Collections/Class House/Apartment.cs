using System.Collections;

namespace IT_STEP
{
    public class Apartment : IEnumerable<Resident>
    {
        private readonly List<Resident> _residents = new List<Resident>();

        public int ApartmentNumber { get; }

        public Apartment(int apartmentNumber)
        {
            ApartmentNumber = apartmentNumber;
        }

        public void AddResident(Resident resident)
        {
            _residents.Add(resident);
        }

        public IEnumerator<Resident> GetEnumerator()
        {
            return _residents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"Apartment #{ApartmentNumber}";
        }
    }
}
