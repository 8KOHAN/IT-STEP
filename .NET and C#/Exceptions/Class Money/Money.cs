namespace IT_STEP
{
    public class Money
    {
        private int dollars;
        private int cents;

        public int Dollars
        {
            get => dollars;
            private set
            {
                if (value < 0)
                    throw new BankruptException("Amount cannot be negative.");
                dollars = value;
            }
        }

        public int Cents
        {
            get => cents;
            private set
            {
                if (value < 0)
                    throw new BankruptException("Amount cannot be negative.");
                cents = value;
                Normalize();
            }
        }

        public Money(int dollars, int cents)
        {
            if (dollars < 0 || cents < 0)
                throw new BankruptException("Amount cannot be negative.");
            this.dollars = dollars;
            this.cents = cents;
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

        public override string ToString() => $"{dollars} dollars {cents:00} cents";

        private void Normalize()
        {
            if (cents >= 100)
            {
                dollars += cents / 100;
                cents %= 100;
            }
        }

        private int ToCents() => dollars * 100 + cents;

        private static Money FromCents(int totalCents)
        {
            if (totalCents < 0)
                throw new BankruptException("Negative total amount.");
            return new Money(totalCents / 100, totalCents % 100);
        }
    }
}
