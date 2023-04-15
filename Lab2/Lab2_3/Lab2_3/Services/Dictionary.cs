namespace Lab2_3.Services;

public class Dictionary
{
    private HashSet<string> _enWords = new();
    private HashSet<string> _ruWords = new();
    private Dictionary<string, List<string>> _dictionaryEnToRu = new();
    private Dictionary<string, List<string>> _dictionaryRuToEn = new();

    public void SetDictionary(Dictionary<string, List<string>> dictionary)
    {
        foreach (var (key, value) in dictionary)
        {
            
        }

        _dictionaryEnToRu = dictionary;
    }

    public Dictionary<string, List<string>> GetDictionary()
    {
        return _dictionaryEnToRu;
    }

    public List<string>? TranslateWord(string word)
    {
        return _dictionaryEnToRu.TryGetValue(word, out List<string>? value) ? value : null;
    }

    public void AddWord(string word, string translate)
    {
        if (!_dictionaryEnToRu.ContainsKey(word))
        {
            _dictionaryEnToRu.Add(word, new List<string>() { translate });
        }
    }
}