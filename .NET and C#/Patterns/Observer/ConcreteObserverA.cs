namespace IT_STEP
{
    public class ConcreteObserverA : IObserver
    {
        public void Update(int state)
        {
            if (state < 3)
            {
                Console.WriteLine("Observer A reacted.");
            }
        }
    }
}
