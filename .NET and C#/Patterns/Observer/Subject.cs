namespace IT_STEP
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers = new();

        public int State { get; private set; }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine("Subject: Observer attached.");
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("Subject: Observer detached.");
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(State);
            }
        }

        public void DoBusinessLogic()
        {
            Console.WriteLine("\nSubject: Doing something important...");
            State = Random.Shared.Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine($"Subject: State changed to {State}");
            Notify();
        }
    }
}
