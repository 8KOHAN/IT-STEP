namespace IT_STEP
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 5, 10, 15, 20, 25 };

            List<int> result = FilterByTwoCriteria(
                numbers,
                x => x > 10,
                x => x % 5 == 0
            );

            foreach (int num in result)
                Console.WriteLine(num);

            List<string> words = new List<string> { "cat", "car", "dog", "card", "castle" };

            List<string> filteredWords = FilterByTwoCriteria(
                words,
                w => w.StartsWith("ca"),
                w => w.Length > 3
            );

            foreach (string word in filteredWords)
                Console.WriteLine(word);
        }

        public static List<T> FilterByTwoCriteria<T>(
            IEnumerable<T> items,
            Func<T, bool> func1,
            Func<T, bool> func2)
        {
            List<T> result = new List<T>();

            foreach (var item in items)
            {
                if (func1(item) && func2(item))
                {
                    result.Add(item); 
                }
            }

            return result; 
        }
    }
}
