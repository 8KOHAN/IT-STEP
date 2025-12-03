using System.Text.Json;

namespace IT_STEP
{
    public class FileService
    {
        public void SaveDictionary(LanguageDictionary dictionary, string path)
        {
            if (dictionary == null || string.IsNullOrWhiteSpace(path))
                return;

            try
            {
                var json = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
            }
            catch
            {
                Console.WriteLine("Failed to save dictionary.");
            }
        }

        public LanguageDictionary LoadDictionary(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return null;

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<LanguageDictionary>(json);
            }
            catch
            {
                Console.WriteLine("Failed to load dictionary. The file is invalid.");
                return null;
            }
        }

        public void ExportWord(LanguageDictionary dictionary, string word, string path)
        {
            if (dictionary == null || string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(path))
                return;

            word = word.Trim();

            if (!dictionary.Entries.ContainsKey(word))
                return;

            try
            {
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
            catch
            {
                Console.WriteLine("Failed to export word.");
            }
        }
    }
}
