using System.Text.RegularExpressions;

namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            string text = @"To be, or not to be, that is the question,
                            Whether 'tis nobler in the mind to suffer
                            The slings and arrows of outrageous fortune,
                            Or to take arms against a sea of troubles,
                            And by opposing end them? To die: to sleep;
                            No more; and by a sleep to say we end
                            The heart-ache and the thousand natural shocks
                            That flesh is heir to, 'tis a consummation
                            Devoutly to be wish'd. To die, to sleep";

            string forbiddenWord = "die";

            int replacementCount;
            string censoredText = CensorText(text, forbiddenWord, out replacementCount);

            Console.WriteLine("Результат работы:\n");
            Console.WriteLine(censoredText);
            Console.WriteLine($"\nСтатистика:\n{replacementCount} замены слова \"{forbiddenWord}\".");
        }
        static string CensorText(string text, string forbiddenWord, out int replacementCount)
        {
            string pattern = $@"\b{Regex.Escape(forbiddenWord)}\b";

            replacementCount = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;

            string result = Regex.Replace(text, pattern, new string('*', forbiddenWord.Length), RegexOptions.IgnoreCase);

            return result;
        }
    }
}
