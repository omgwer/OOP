using System.Text;

namespace Lab2_3;

internal interface IMiniDictionary
{
    public List<string>? TranslateWord(string word);
    public void AddWord(string word);
}

public class MiniDictionary : IMiniDictionary
{
    private Dictionary<string, List<string>> Dictionary { get; } = new Dictionary<string, List<string>>();

    public MiniDictionary() { }

    public MiniDictionary(string pathToFile)
    {
        OpenFile(pathToFile);
    }

    public List<string>? TranslateWord(string word)
    {
        return null;
    }

    public void AddWord(string word)
    {
        throw new NotImplementedException();
    }

    private void OpenFile(string pathToFile)
    {
        using var streamReader = new StreamReader(pathToFile);
        var translatedWordList = new List<string>();
        while (streamReader.ReadLine() is { } wordsString)
        {
            var wordWithTranslate = wordsString!.Split(" ");
            if (wordWithTranslate.Length < 3)
            {
                throw new Exception("Word is dont have a translated word");
            }
            
            for (var i = 1; i < wordWithTranslate.Length; i++)
            {
                translatedWordList.Add(wordWithTranslate[i]);
            }
            
            Dictionary.Add(wordWithTranslate[0], translatedWordList);
            translatedWordList.Clear();
        }
    }


}