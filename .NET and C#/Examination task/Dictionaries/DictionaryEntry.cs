namespace IT_STEP
{
    public class DictionaryEntry
    {
        public string Word { get; set; }
        public List<string> Translations { get; set; }

        public DictionaryEntry()
        {
            Translations = new List<string>();
        }
    }
}
