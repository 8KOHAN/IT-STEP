namespace IT_STEP
{
    public class Money
    {
        private int _dollars;
        private int _cents;

        public int Dollars
        {
            get => _dollars;
            private set
            {
                if (value < 0)
                    throw new BankruptException("Amount cannot be negative.");
                _dollars = value;
            }
        }

        public int Cents
        {
            get => _cents;
            private set
            {
                if (value < 0)
                    throw new BankruptException("Amount cannot be negative.");
                _cents = value;
                Normalize();
            }
        }

        public Money(int dollars, int cents)
        {
            if (dollars < 0 || cents < 0)
                throw new BankruptException("Amount cannot be negative.");
            this._dollars = dollars;
            this._cents = cents;
            Normalize();
        }


        public static Money operator +(Money a, Money b)
            => FromCents(a.ToCents() + b.ToCents());

        public static Money operator -(Money a, Money b)
            => FromCents(a.ToCents() - b.ToCents());

        public static Money operator *(Money a, int n)
            => FromCents(a.ToCents() * n);

        public static Money operator /(Money a, int n)
        {
            if (n <= 0)
                throw new ArgumentException("Division by non-positive number.");
            return FromCents(a.ToCents() / n);
        }

        public static Money operator ++(Money a)
            => FromCents(a.ToCents() + 1);

        public static Money operator --(Money a)
            => FromCents(a.ToCents() - 1);

        public static bool operator <(Money a, Money b) => a.ToCents() < b.ToCents();
        public static bool operator >(Money a, Money b) => a.ToCents() > b.ToCents();
        public static bool operator ==(Money a, Money b) => a.ToCents() == b.ToCents();
        public static bool operator !=(Money a, Money b) => a.ToCents() != b.ToCents();

        public override bool Equals(object obj)
        {
            if (obj is Money m)
                return this == m;
            return false;
        }

        public override int GetHashCode() => ToCents().GetHashCode();

        public override string ToString() => $"{_dollars} dollars {_cents:00} cents";

        private void Normalize()
        {
            if (_cents >= 100)
            {
                _dollars += _cents / 100;
                _cents %= 100;
            }
        }

        private int ToCents() => _dollars * 100 + _cents;

        private static Money FromCents(int totalCents)
        {
            if (totalCents < 0)
                throw new BankruptException("Negative total amount.");
            return new Money(totalCents / 100, totalCents % 100);
        }
    }
}
