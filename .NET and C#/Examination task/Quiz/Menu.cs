namespace IT_STEP
{
    public class Menu
    {
        private readonly UserService _userService = new UserService("users.txt");
        private readonly QuizService _quizService = new QuizService("quizzes");
        private readonly ResultService _resultService = new ResultService("results.txt");

        public void Start()
        {
            Directory.CreateDirectory("quizzes");

            Console.WriteLine("=== QUIZ APPLICATION ===");

            User user = LoginMenu();
            MainMenu(user);
        }

        private User LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");

                Console.Write("Choice: ");
                string? choice = Console.ReadLine()?.Trim();

                if (choice == "1") return _userService.Login();
                if (choice == "2") return _userService.Register();

                Console.WriteLine("Invalid choice.");
            }
        }

        private void MainMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1 - Start quiz");
                Console.WriteLine("2 - My results");
                Console.WriteLine("3 - Top 20");
                Console.WriteLine("4 - Settings");
                Console.WriteLine("5 - Quiz editor");
                Console.WriteLine("0 - Exit");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": StartQuiz(user); break;
                    case "2": _resultService.ShowUserResults(user.Username); break;
                    case "3": _resultService.ShowTop20(); break;
                    case "4": _userService.Settings(user); break;
                    case "5": _quizService.Editor(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void StartQuiz(User user)
        {
            var quizzes = _quizService.GetQuizNames();

            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quizzes available.");
                return;
            }

            Console.WriteLine("Available quizzes:");
            for (int i = 0; i < quizzes.Count; i++)
                Console.WriteLine($"{i + 1} - {quizzes[i]}");

            int choice = ReadInt("Select quiz or 0 for mixed: ", 0, quizzes.Count);

            List<Question> questions =
                choice == 0
                ? _quizService.LoadMixedQuiz()
                : _quizService.LoadQuiz(quizzes[choice - 1]);

            if (questions.Count == 0)
            {
                Console.WriteLine("Quiz is empty.");
                return;
            }

            int score = 0;

            foreach (var q in questions)
            {
                Console.WriteLine("\n" + q.Text);

                for (int i = 0; i < q.Answers.Count; i++)
                    Console.WriteLine($"{i + 1}. {q.Answers[i].Text}");

                List<int> selected = ReadAnswers(q.Answers.Count);

                bool correct =
                    selected.Count == q.Answers.Count(a => a.IsCorrect) &&
                    selected.All(i => q.Answers[i - 1].IsCorrect);

                if (correct) score++;
            }

            Console.WriteLine($"\nYour score: {score} / {questions.Count}");
            _resultService.SaveResult(user.Username, score);
        }

        private int ReadInt(string msg, int min, int max)
        {
            while (true)
            {
                Console.Write(msg);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int num) && num >= min && num <= max)
                    return num;

                Console.WriteLine("Invalid number.");
            }
        }

        private List<int> ReadAnswers(int max)
        {
            while (true)
            {
                Console.Write("Your answer (comma separated): ");
                string? input = Console.ReadLine();

                try
                {
                    var nums = input
                        .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    if (nums.Any(n => n < 1 || n > max))
                    {
                        Console.WriteLine("Invalid answer numbers.");
                        continue;
                    }

                    return nums;
                }
                catch
                {
                    Console.WriteLine("Invalid format.");
                }
            }
        }
    }
}
