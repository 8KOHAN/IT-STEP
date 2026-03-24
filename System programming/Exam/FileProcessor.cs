using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace WinFormsApp4
{
    public static class FileProcessor
    {
        public static (bool Found, string CleanContent) Process(string path, List<string> words, ConcurrentDictionary<string, int> stats)
        {
            string text;

            try
            {
                text = File.ReadAllText(path);
            }
            catch
            {
                return (false, null);
            }

            bool found = false;

            foreach (var word in words)
            {
                var matches = Regex.Matches(text, word, RegexOptions.IgnoreCase);

                if (matches.Count > 0)
                {
                    found = true;
                    stats.AddOrUpdate(word, matches.Count, (_, v) => v + matches.Count);
                    text = Regex.Replace(text, word, "*******", RegexOptions.IgnoreCase);
                }
            }

            return (found, text);
        }
    }
}
