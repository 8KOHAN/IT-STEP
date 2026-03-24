namespace WinFormsApp4
{
    public static class ReportService
    {
        public static void Generate(string path, List<string> files, Dictionary<string, int> topWords)
        {
            using var sw = new StreamWriter(path);

            sw.WriteLine("Files:");

            foreach (var f in files)
            {
                var fi = new FileInfo(f);
                sw.WriteLine($"{f} | {fi.Length} bytes");
            }

            sw.WriteLine("\nTop words:");

            foreach (var w in topWords)
            {
                sw.WriteLine($"{w.Key}: {w.Value}");
            }
        }
    }
}
