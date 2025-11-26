namespace IT_STEP
{
    public class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }

        public override string ToString()
        {
            return
                "Title: " + Title + "\n" +
                "Author: " + Author + "\n" +
                "Year: " + Year + "\n" +
                "Theme: " + Theme + "\n" +
                "Text:\n" + Text;
        }

        public string ToFileString()
        {
            return Title + "|" + Author + "|" + Year + "|" + Theme + "|" + Text.Replace("\n", "\\n");
        }

        public static Poem FromFileString(string line)
        {
            string[] parts = line.Split('|');

            return new Poem
            {
                Title = parts[0],
                Author = parts[1],
                Year = int.Parse(parts[2]),
                Theme = parts[3],
                Text = parts[4].Replace("\\n", "\n")
            };
        }
    }
}
