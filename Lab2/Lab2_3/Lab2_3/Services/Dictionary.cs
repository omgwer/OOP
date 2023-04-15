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
            if (_dictionaryEnToRu.ContainsKey(word))
                throw new ArgumentException("The Word is exits for this dictionary");
            _dictionaryEnToRu.Add(word, new List<string>() { translate });

            if (_dictionaryRuToEn.ContainsKey(translate) && !_dictionaryRuToEn[translate].Contains(word))
                _dictionaryRuToEn[translate].Add(word);
            else
                _dictionaryRuToEn.Add(translate, new List<string>() { word });
        }
        else
        {
            if (_dictionaryRuToEn.ContainsKey(word))
                throw new ArgumentException("The Word is exits for this dictionary");
            _dictionaryRuToEn.Add(word, new List<string>() { translate });

            if (_dictionaryEnToRu.ContainsKey(translate) && !_dictionaryEnToRu[translate].Contains(word))
                _dictionaryEnToRu[translate].Add(word);
            else
                _dictionaryEnToRu.Add(translate, new List<string>() { word });
        }
    }

    private void InitializeRuToEnDictionary()
    {
        foreach (var (englishWord, russianWordsList) in _dictionaryEnToRu)
        foreach (var russianWord in russianWordsList)
            //TODO: похоже на код в методе AddWord возможно вынести
            if (_dictionaryRuToEn.ContainsKey(russianWord) && !_dictionaryRuToEn[russianWord].Contains(englishWord))
                _dictionaryRuToEn[russianWord].Add(englishWord);
            else
                _dictionaryRuToEn.Add(russianWord, new List<string>() { englishWord });
    }
}