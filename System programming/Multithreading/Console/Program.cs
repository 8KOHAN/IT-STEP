namespace ConsoleApp1 
{
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main()
        {
            Console.WriteLine("Enter the path to the text file:");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            Console.WriteLine("Enter encryption key:");
            int key = int.Parse(Console.ReadLine());

            Task encryptTask = Task.Run(() => EncryptFile(path, key, cts.Token));

            Console.WriteLine("Press C to cancel encryption.");

            while (!encryptTask.IsCompleted)
            {
                if (Console.KeyAvailable)
                {
                    var keyPress = Console.ReadKey(true);

                    if (keyPress.Key == ConsoleKey.C)
                    {
                        cts.Cancel();
                        break;
                    }
                }
            }

            encryptTask.Wait();
        }

        static void EncryptFile(string path, int key, CancellationToken token)
        {
            try
            {
                string text = File.ReadAllText(path);

                char[] buffer = text.ToCharArray();

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Encryption cancelled.");
                        return;
                    }

                    buffer[i] = (char)(buffer[i] + key);

                    Thread.Sleep(5);
                }

                string encrypted = new string(buffer);

                string newFile = Path.Combine(
                    Path.GetDirectoryName(path),
                    "encrypted.txt");

                File.WriteAllText(newFile, encrypted);

                Console.WriteLine("Encryption completed successfully.");
                Console.WriteLine("Encrypted file saved to: " + newFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
