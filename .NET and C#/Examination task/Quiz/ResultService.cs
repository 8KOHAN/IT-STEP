using System.Text.Json;

namespace IT_STEP
{
    public class ResultService
    {
        private readonly string _filePath;
        private List<Result> _results = new List<Result>();

        public ResultService(string filePath)
        {
            _filePath = filePath;
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_filePath))
            {
                _results = new List<Result>();
                return;
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                _results = JsonSerializer.Deserialize<List<Result>>(json) ?? new List<Result>();
            }
            catch
            {
                _results = new List<Result>();
            }
        }

        private void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(_results, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(_filePath, json);
            }
            catch
            {
                Console.WriteLine("Error: failed to save results.");
            }
        }

        public void SaveResult(string username, int score)
        {
            _results.Add(new Result
            {
                Username = username,
                Score = score,
                Date = DateTime.Now
            });

            Save();
        }

        public void ShowUserResults(string username)
        {
            var userResults = _results.Where(r => r.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (!userResults.Any())
            {
                Console.WriteLine("You have no results yet.");
                return;
            }

            foreach (var r in userResults)
                Console.WriteLine($"{r.Date}: {r.Score} points");
        }

        public void ShowTop20()
        {
            var top = _results
                .OrderByDescending(r => r.Score)
                .Take(20);

            foreach (var r in top)
                Console.WriteLine($"{r.Username}: {r.Score}");
        }
    }
}
