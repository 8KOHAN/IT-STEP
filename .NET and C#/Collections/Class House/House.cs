using System.Collections;

namespace IT_STEP
{
    public class House : IEnumerable<Apartment>
    {
        private readonly List<Apartment> _apartments = new List<Apartment>();

        public void AddApartment(Apartment apartment)
        {
            _apartments.Add(apartment);
        }

        public IEnumerator<Apartment> GetEnumerator()
        {
            return _apartments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
