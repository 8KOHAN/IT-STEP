using System.Text.Json;

namespace IT_STEP
{
    public class FileService
    {
        public void SaveDictionary(LanguageDictionary dictionary, string path)
        {
            var json = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public LanguageDictionary LoadDictionary(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<LanguageDictionary>(json);
        }

        public void ExportWord(LanguageDictionary dictionary, string word, string path)
        {
            if (!dictionary.Entries.ContainsKey(word))
                return;

            var entry = new DictionaryEntry
            {
                Word = word,
                Translations = dictionary.Entries[word]
            };

            var json = JsonSerializer.Serialize(entry, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }
    }
}
