namespace IT_STEP
{
    public class DictionaryService
    {
        private bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public void AddWord(LanguageDictionary dictionary, string word, string translation)
        {
            if (dictionary == null || !IsValid(word) || !IsValid(translation))
                return;

            word = word.Trim();
            translation = translation.Trim();

            if (!dictionary.Entries.ContainsKey(word))
                dictionary.Entries[word] = new List<string>();

            dictionary.Entries[word].Add(translation);
        }

        public void ReplaceWord(LanguageDictionary dictionary, string oldWord, string newWord)
        {
            if (dictionary == null || !IsValid(oldWord) || !IsValid(newWord))
                return;

            oldWord = oldWord.Trim();
            newWord = newWord.Trim();

            if (!dictionary.Entries.ContainsKey(oldWord))
                return;

            if (dictionary.Entries.ContainsKey(newWord))
                return;

            var translations = dictionary.Entries[oldWord];
            dictionary.Entries.Remove(oldWord);
            dictionary.Entries[newWord] = translations;
        }

        public void ReplaceTranslation(LanguageDictionary dictionary, string word, string oldTranslation, string newTranslation)
        {
            if (dictionary == null || !IsValid(word) || !IsValid(oldTranslation) || !IsValid(newTranslation))
                return;

            word = word.Trim();
            oldTranslation = oldTranslation.Trim();
            newTranslation = newTranslation.Trim();

            if (!dictionary.Entries.ContainsKey(word))
                return;

            var list = dictionary.Entries[word];
            int index = list.IndexOf(oldTranslation);

            if (index != -1)
                list[index] = newTranslation;
        }

        public void RemoveTranslation(LanguageDictionary dictionary, string word, string translation)
        {
            if (dictionary == null || !IsValid(word) || !IsValid(translation))
                return;

            word = word.Trim();
            translation = translation.Trim();

            if (!dictionary.Entries.ContainsKey(word))
                return;

            var list = dictionary.Entries[word];
            if (list.Count > 1 && list.Contains(translation))
                list.Remove(translation);
        }

        public void RemoveWord(LanguageDictionary dictionary, string word)
        {
            if (dictionary == null || !IsValid(word))
                return;

            word = word.Trim();

            dictionary.Entries.Remove(word);
        }

        public List<string> FindTranslations(LanguageDictionary dictionary, string word)
        {
            if (dictionary == null || !IsValid(word))
                return null;

            word = word.Trim();

            return dictionary.Entries.ContainsKey(word) ? dictionary.Entries[word] : null;
        }
    }
}
