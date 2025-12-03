namespace IT_STEP
{
    public class DictionaryService
    {
        public void AddWord(LanguageDictionary dictionary, string word, string translation)
        {
            if (!dictionary.Entries.ContainsKey(word))
                dictionary.Entries[word] = new List<string>();

            dictionary.Entries[word].Add(translation);
        }

        public void ReplaceWord(LanguageDictionary dictionary, string oldWord, string newWord)
        {
            if (!dictionary.Entries.ContainsKey(oldWord))
                return;

            var translations = dictionary.Entries[oldWord];
            dictionary.Entries.Remove(oldWord);
            dictionary.Entries[newWord] = translations;
        }

        public void ReplaceTranslation(LanguageDictionary dictionary, string word, string oldTranslation, string newTranslation)
        {
            if (!dictionary.Entries.ContainsKey(word))
                return;

            var list = dictionary.Entries[word];
            int index = list.IndexOf(oldTranslation);

            if (index != -1)
                list[index] = newTranslation;
        }

        public void RemoveTranslation(LanguageDictionary dictionary, string word, string translation)
        {
            if (!dictionary.Entries.ContainsKey(word))
                return;

            var list = dictionary.Entries[word];
            if (list.Count > 1)
                list.Remove(translation);
        }

        public void RemoveWord(LanguageDictionary dictionary, string word)
        {
            dictionary.Entries.Remove(word);
        }

        public List<string> FindTranslations(LanguageDictionary dictionary, string word)
        {
            return dictionary.Entries.ContainsKey(word) ? dictionary.Entries[word] : null;
        }
    }
}
