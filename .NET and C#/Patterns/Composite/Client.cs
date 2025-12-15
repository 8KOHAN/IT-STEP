namespace IT_STEP
{
    public class Client
    {
        public void PrintResult(Component component)
        {
            Console.WriteLine($"RESULT: {component.Operation()}");
        }

        public void AddAndPrint(Component parent, Component child)
        {
            if (parent.IsComposite)
            {
                parent.Add(child);
            }

            PrintResult(parent);
        }
    }
}
