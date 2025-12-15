namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            var client = new Client();

            var leaf = new Leaf();
            Console.WriteLine("Simple component:");
            client.PrintResult(leaf);

            var tree = new Composite();

            var branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());

            var branch2 = new Composite();
            branch2.Add(new Leaf());

            tree.Add(branch1);
            tree.Add(branch2);

            Console.WriteLine("\nComposite tree:");
            client.PrintResult(tree);

            Console.WriteLine("\nManaging tree without knowing concrete classes:");
            client.AddAndPrint(tree, leaf);
        }
    }
}
