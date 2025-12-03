namespace IT_STEP
{
    public class LanguageDictionary
    {
        public string Type { get; set; }
        public Dictionary<string, List<string>> Entries { get; set; }

        public LanguageDictionary()
        {
            Entries = new Dictionary<string, List<string>>();
        }

        public LanguageDictionary(string type) : this()
        {
            Type = type;
        }
    }
}
