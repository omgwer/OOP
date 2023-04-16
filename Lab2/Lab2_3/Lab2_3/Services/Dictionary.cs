using Lab2_3.Dictionary;

namespace Lab2_3.Services;

public class Dictionary
{
    private Dictionary<string, List<string>> _dictionaryEnToRu = new();
    private Dictionary<string, List<string>> _dictionaryRuToEn = new();

    public void SetDictionary(Dictionary<string, List<string>> dictionary)
    {
        _dictionaryEnToRu = dictionary;
        InitializeRuToEnDictionary();
    }

    public Dictionary<string, List<string>> GetDictionary()
    {
        return _dictionaryEnToRu;
    }

    public List<string>? TranslateWord(string word)
    {
        if (WordService.IsEnglishWord(word))
            return _dictionaryEnToRu.TryGetValue(word, out List<string>? value) ? value : null;
        else
            return _dictionaryRuToEn.TryGetValue(word, out List<string>? value) ? value : null;
    }

    public void AddWord(string word, string translate)
    {
        if (WordService.IsEnglishWord(word))
        {
            AssertRussianTranslateWordIsValid(translate);
            AssertIsEnglishDictionaryContainKey(word);
            _dictionaryEnToRu.Add(word, new List<string>() { translate });
            SynchronizationRussianDictionary(translate, word);
        }
        else
        {
            AssertEnglishTranslateWordIsValid(translate);
            AssertIsRussianDictionaryContainKey(word);
            _dictionaryRuToEn.Add(word, new List<string>() { translate });
            SynchronizationEnglishDictionary(word, translate);
        }
    }

    private void InitializeRuToEnDictionary()
    {
        foreach (var (englishWord, russianWordsList) in _dictionaryEnToRu)
        foreach (var russianWord in russianWordsList)
            SynchronizationRussianDictionary(russianWord, englishWord);
    }

    private void SynchronizationRussianDictionary(string russianWord, string englishWord)
    {
        if (_dictionaryRuToEn.ContainsKey(russianWord) && !_dictionaryRuToEn[russianWord].Contains(englishWord))
            _dictionaryRuToEn[russianWord].Add(englishWord);
        else
            _dictionaryRuToEn.Add(russianWord, new List<string>() { englishWord });
    }

    private void SynchronizationEnglishDictionary(string russianWord, string englishWord)
    {
        if (_dictionaryEnToRu.ContainsKey(englishWord) && !_dictionaryEnToRu[englishWord].Contains(russianWord))
            _dictionaryEnToRu[englishWord].Add(russianWord);
        else
            _dictionaryEnToRu.Add(englishWord, new List<string>() { russianWord });
    }

    private void AssertIsEnglishDictionaryContainKey(string englishWord)
    {
        AssertDictionaryContainKey(_dictionaryEnToRu, englishWord);
    }

    private void AssertIsRussianDictionaryContainKey(string russianWord)
    {
        AssertDictionaryContainKey(_dictionaryRuToEn, russianWord);
    }

    private void AssertRussianTranslateWordIsValid(string word)
    {
        if (WordService.IsEnglishWord(word))
            throw new ArgumentException(MessageDictionary.GetAddTranslateForEnglishWordErrorMessage(word));
    }

    private void AssertEnglishTranslateWordIsValid(string word)
    {
        if (WordService.IsRussianWord(word))
            throw new ArgumentException(MessageDictionary.GetAddTranslateForRussianWordErrorMessage(word));
    }

    private void AssertDictionaryContainKey(Dictionary<string, List<string>> dictionary, string key)
    {
        if (dictionary.ContainsKey(key))
            throw new ArgumentException(MessageDictionary.WORD_IS_EXIST_FOR_DICTIONARY_MESSAGE);
    }
}