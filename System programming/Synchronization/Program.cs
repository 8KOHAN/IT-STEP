namespace New_folder;

public class BankAccount
{
    public static int money = 0;
    public static object locker = new object();
}

class Program
{
    static Semaphore semaphore = new Semaphore(3, 3);
    static void Main(string[] args)
    {
        Thread t1 = new Thread(() => Worker());
        Thread t2 = new Thread(() => Worker());
        Thread t3 = new Thread(() => Worker());
        Thread t4 = new Thread(() => Worker());

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("\n");

        t1 = new Thread(() => Worker2());
        t2 = new Thread(() => Worker2());
        t3 = new Thread(() => Worker2());
        t4 = new Thread(() => Worker2());
        Thread t5 = new Thread(() => Worker2());
        Thread t6 = new Thread(() => Worker2());
        Thread t7 = new Thread(() => Worker2());
        Thread t8 = new Thread(() => Worker2());
        Thread t9 = new Thread(() => Worker2());
        Thread t10 = new Thread(() => Worker2());

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();
        t6.Start();
        t7.Start();
        t8.Start();
        t9.Start();
        t10.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();
        t5.Join();
        t6.Join();
        t7.Join();
        t8.Join();
        t9.Join();
        t10.Join();

    }

    static void Worker()
    {
        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            Monitor.Enter(BankAccount.locker);
            BankAccount.money += random.Next(1, 1000);

            BankAccount.money -= random.Next(1, 1000);
            if (BankAccount.money < 0) BankAccount.money = 0;
            Monitor.Exit(BankAccount.locker);
        }
        Console.WriteLine(BankAccount.money);
    }

    static void Worker2()
    {
        Random random = new Random();

        semaphore.WaitOne();
        Console.Write($"ThreadId = {Thread.CurrentThread.ManagedThreadId} num = ");
        Console.WriteLine(random.Next(1, 1000));
        semaphore.Release();
        
    }
}
