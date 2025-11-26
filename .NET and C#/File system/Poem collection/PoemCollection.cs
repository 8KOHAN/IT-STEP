namespace IT_STEP
{
    public class PoemCollection
    {
        private List<Poem> poems = new List<Poem>();

        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public bool RemovePoem(string title)
        {
            Poem poem = poems.Find(p => p.Title.ToLower() == title.ToLower());
            if (poem == null) return false;

            poems.Remove(poem);
            return true;
        }

        public bool UpdatePoem(string title, Poem updated)
        {
            Poem poem = poems.Find(p => p.Title.ToLower() == title.ToLower());
            if (poem == null) return false;

            poem.Title = updated.Title;
            poem.Author = updated.Author;
            poem.Year = updated.Year;
            poem.Text = updated.Text;
            poem.Theme = updated.Theme;

            return true;
        }

        public List<Poem> Search(string word)
        {
            List<Poem> results = new List<Poem>();

            foreach (var poem in poems)
            {
                if (poem.Title.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                    poem.Author.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                    poem.Theme.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                    poem.Text.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(poem);
                }
            }

            return results;
        }

        public IEnumerable<Poem> GetAll()
        {
            return poems;
        }

        public void SaveToFile(string path)
        {
            List<string> lines = new List<string>();

            foreach (var p in poems)
            {
                lines.Add(p.ToFileString());
            }

            File.WriteAllLines(path, lines);
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);
            poems.Clear();

            foreach (string line in lines)
            {
                poems.Add(Poem.FromFileString(line));
            }
        }
    }
}
