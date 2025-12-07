using System;
using System.Text.Json;

namespace IT_STEP
{
    public class QuizService
    {
        private readonly string _folder;

        public QuizService(string folder)
        {
            _folder = folder;
            Directory.CreateDirectory(folder);
        }

        public List<string> GetQuizNames()
        {
            var files = Directory.GetFiles(_folder, "*.json");

            if (files.Length == 0)
            {
                Console.WriteLine("No quizzes found.");
                return new List<string>();
            }

            return files
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }


        public List<Question> LoadQuiz(string quizName)
        {
            string path = Path.Combine(_folder, quizName + ".json");

            if (!File.Exists(path))
            {
                Console.WriteLine("Quiz file not found.");
                return new List<Question>();
            }

            try
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
            }
            catch
            {
                Console.WriteLine("Error: quiz file is corrupted.");
                return new List<Question>();
            }
        }

        public List<Question> LoadMixedQuiz()
        {
            var all = new List<Question>();

            foreach (var file in Directory.GetFiles(_folder, "*.json"))
            {
                try
                {
                    var q = JsonSerializer.Deserialize<List<Question>>(File.ReadAllText(file));
                    if (q != null) all.AddRange(q);
                }
                catch
                {
                    Console.WriteLine($"Warning: quiz file corrupted: {file}");
                }
            }

            var random = new Random();
            return all.OrderBy(q => random.Next()).Take(20).ToList();
        }

        public void Editor()
        {
            Console.Write("Enter quiz name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Quiz name cannot be empty.");
                return;
            }

            string path = Path.Combine(_folder, $"{name}.json");

            int count;
            Console.Write("How many questions? ");
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                Console.Write("Enter a valid number: ");

            var questions = new List<Question>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Question {i + 1}:");

                string text;
                do
                {
                    Console.Write("Text: ");
                    text = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(text));

                int answerCount;
                Console.Write("How many answers? ");
                while (!int.TryParse(Console.ReadLine(), out answerCount) || answerCount <= 0)
                    Console.Write("Enter a valid number: ");

                var answers = new List<Answer>();

                for (int j = 0; j < answerCount; j++)
                {
                    string answerText;
                    do
                    {
                        Console.Write($"Answer {j + 1}: ");
                        answerText = Console.ReadLine();
                    }
                    while (string.IsNullOrWhiteSpace(answerText));

                    Console.Write("Is correct (y/n): ");
                    bool corr;
                    while (true)
                    {
                        string? input = Console.ReadLine()?.Trim().ToLower();

                        if (input == "y")
                        {
                            corr = true;
                            break;
                        }

                        if (input == "n")
                        {
                            corr = false;
                            break;
                        }
                            
                        Console.WriteLine("Please enter Y or N.");
                    }

                    answers.Add(new Answer { Text = answerText, IsCorrect = corr });
                }

                questions.Add(new Question { Text = text, Answers = answers });
            }

            try
            {
                string json = JsonSerializer.Serialize(questions, new JsonSerializerOptions 
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                Console.WriteLine("Quiz saved.");
            }
            catch
            {
                Console.WriteLine("Error: cannot save quiz.");
            }
        }
    }
}
