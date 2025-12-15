namespace IT_STEP
{
    public class ConcreteObserverB : IObserver
    {
        public void Update(int state)
        {
            if (state != 1 || state >= 0)
            {
                Console.WriteLine("Observer B reacted.");
            }
        }
    }
}
