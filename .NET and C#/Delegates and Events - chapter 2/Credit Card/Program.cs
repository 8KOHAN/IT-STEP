namespace IT_STEP
{
    public class Program
    {
        static void Main()
        {
            CreditCard card = new CreditCard(
                "1234 5678 9000 1111",
                "Ivan Petrenko",
                new DateTime(2028, 12, 1),
                1234,
                1000.0,
                200.0
            );

            card.MoneyAdded += delegate (CreditCard c, double amount)
            {
                Console.WriteLine($"[ADD] {amount} -> New balance: {c.Balance}");
            };

            card.MoneySpent += delegate (CreditCard c, double amount)
            {
                Console.WriteLine($"[SPEND] {amount} -> New balance: {c.Balance}");
            };

            card.CreditStarted += delegate (CreditCard c)
            {
                Console.WriteLine("[CREDIT] Credit money started!");
            };

            card.TargetBalanceReached += delegate (CreditCard c, double balance)
            {
                Console.WriteLine($"[TARGET] Target balance reached: {balance}");
            };

            card.PinChanged += delegate (CreditCard c, int newPIN)
            {
                Console.WriteLine($"[PIN] PIN changed to {newPIN}");
            };

            Console.WriteLine("\n--- TESTING ---");
            try
            {
                card.AddMoney(100);
                card.SpendMoney(350);
                card.AddMoney(500, 400);
                card.PIN = 9999;
                card.SpendMoney(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
