namespace WinFormsApp4
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using var mutex = new Mutex(true, "MyUniqueApp", out bool created);

            if (!created) return;

            if (args.Length > 0)
            {
                var service = new ScannerService();
                service.Start(new List<string> { "test" }, "output", _ => { }).Wait();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
