namespace IT_STEP
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }

        private int pin;
        public int PIN
        {
            get => pin;
            set
            {
                pin = value;
                PinChanged?.Invoke(this, pin);
            }
        }

        public double CreditLimit { get; set; }
        public double Balance { get; private set; }

        public event Action<CreditCard, double> MoneyAdded;
        public event Action<CreditCard, double> MoneySpent;
        public event Action<CreditCard> CreditStarted;
        public event Action<CreditCard, double> TargetBalanceReached;
        public event Action<CreditCard, int> PinChanged;

        public CreditCard(string number, string owner, DateTime exp, int pin, double limit, double initialBalance)
        {
            CardNumber = number;
            OwnerName = owner;
            ExpirationDate = exp;
            PIN = pin;
            CreditLimit = limit;
            Balance = initialBalance;
        }


        public void AddMoney(double amount, double targetBalance = double.MaxValue)
        {
            Balance += amount;

            MoneyAdded?.Invoke(this, amount);

            if (Balance >= targetBalance)
                TargetBalanceReached?.Invoke(this, Balance);
        }

        public void SpendMoney(double amount)
        {
            double before = Balance;

            Balance -= amount;

            MoneySpent?.Invoke(this, amount);

            if (Balance < -CreditLimit)
                throw new InvalidOperationException("Credit limit exceeded!");

            if (before >= 0 && Balance < 0)
                CreditStarted?.Invoke(this);
        }
    }
}
