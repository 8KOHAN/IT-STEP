using System.Diagnostics;

namespace App 
{
    class Program
    {
        static int totalFiles = 0;
        static int processedFiles = 0;
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter folder path:");
            string folder = Console.ReadLine();

            stopwatch.Start();

            string[] files = Directory.GetFiles(folder, "*.txt", SearchOption.AllDirectories);
            totalFiles = files.Length;

            Console.WriteLine($"Files found: {totalFiles}");

            foreach (var file in files)
            {
                ThreadPool.QueueUserWorkItem(async state =>
                {
                    string path = (string)state;

                    Console.WriteLine($"Encryption started: {path}");

                    string content = File.ReadAllText(path);

                    string encrypted = Encrypt(content);

                    string newPath = path + ".enc";

                    await File.WriteAllTextAsync(newPath, encrypted);

                    Interlocked.Increment(ref processedFiles);

                    if (processedFiles == totalFiles)
                    {
                        stopwatch.Stop();

                        Console.WriteLine("\nProcessing completed!");
                        Console.WriteLine($"Files processed: {processedFiles}");
                        Console.WriteLine($"Execution time: {stopwatch.Elapsed}");
                    }

                }, file);
            }

            Console.ReadLine();
        }

        static string Encrypt(string text)
        {
            char key = (char)3;

            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = (char)(text[i] ^ key);
            }

            return new string(result);
        }
    }
}
