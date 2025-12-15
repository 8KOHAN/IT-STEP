namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            var subject = new Subject();

            var observerA = new ConcreteObserverA();
            var observerB = new ConcreteObserverB();

            subject.Attach(observerA);
            subject.Attach(observerB);

            subject.DoBusinessLogic();
            subject.DoBusinessLogic();

            subject.Detach(observerB);

            subject.DoBusinessLogic();
        }
    }
}
