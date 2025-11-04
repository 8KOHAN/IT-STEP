namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            List<string> questions = new List<string>
        {
            "Що таке інкапсуляція?",
            "Поясніть поняття поліморфізму.",
            "Що таке конструктор у C#?",
            "У чому різниця між класом та структурою?",
            "Що таке спадкування?",
            "Для чого потрібен ключове слово 'static'?",
            "Що таке інтерфейс?",
            "Що таке абстрактний клас?",
            "Що таке перевантаження методів?",
            "Як працює збирач сміття (Garbage Collector)?",
            "Що таке властивість (Property)?",
            "У чому різниця між 'ref' та 'out' параметрами?",
            "Що таке делегат?",
            "Як працюють події (Events)?",
            "Що таке LINQ?",
            "Що таке тип nullable?",
            "Для чого потрібен 'using'?",
            "Що таке namespace?",
            "Що таке метод-розширення?",
            "Що таке індексатор?",
            "У чому різниця між масивом і списком?",
            "Як створити об’єкт класу?",
            "Що таке перевантаження операторів?",
            "Що таке try-catch блок?",
            "Як працює finally?",
            "Що таке generic типи?",
            "Як працює ключове слово 'var'?"
        };

            Random rand = new Random();
            List<string> selectedQuestions = questions.OrderBy(x => rand.Next()).Take(10).ToList();

            File.WriteAllLines("questions.txt", selectedQuestions);
            List<string> answers = selectedQuestions.Select(q => $"Питання: {q}\nВідповідь: (Тут має бути відповідь на запитання)").ToList();

            File.WriteAllLines("answers.txt", answers);
        }
    }
}
