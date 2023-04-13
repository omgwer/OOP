namespace Lab2_3.Services;

public interface IMiniDictionary
{
    public void SetDictionary(Dictionary<string, List<string>> dictionary);
    public Dictionary<string, List<string>> GetDictionary();
    public List<string>? TranslateWord(string word);
    public void AddWord(string word, string translate);
}

public class MiniDictionary : IMiniDictionary
{
    private Dictionary<string, List<string>> _dictionary = new();

    public void SetDictionary(Dictionary<string, List<string>> dictionary)
    {
        _dictionary = dictionary;
    }

    public Dictionary<string, List<string>> GetDictionary()
    {
        return _dictionary;
    }

    public List<string>? TranslateWord(string word)
    {
        return _dictionary.TryGetValue(word, out List<string>? value) ? value : null;
    }

    public void AddWord(string word, string translate)
    {
        if (!_dictionary.ContainsKey(word))
        {
            _dictionary.Add(word, new List<string>() { translate });
        }
    }
}