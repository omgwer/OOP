using System.Text;
using Lab2_3.Dictionary;

namespace Lab2_3.Infrastructure;

public class FileWorker
{
    private readonly string _path;

    public FileWorker(string path)
    {
        _path = path;
    }

    public Dictionary<string, List<string>> OpenFile()
    {
        using StreamReader streamReader = new StreamReader(_path);
        if (!File.Exists(_path))
            throw new FileLoadException(MessageDictionary.FILE_NOT_FOUND_ALERT);
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        while (streamReader.ReadLine() is { } wordsString)
        {
            var translatedWordList = new List<string>();
            var wordWithTranslate = wordsString!.Split(" ");
            if (wordWithTranslate.Length < 2)
            {
                throw new Exception("Word is dont have a translated word");
            }

            for (var i = 1; i < wordWithTranslate.Length; i++)
            {
                translatedWordList.Add(wordWithTranslate[i]);
            }

            dictionary.Add(wordWithTranslate[0], translatedWordList);
        }

        streamReader.Close();
        return dictionary;
    }

    public void SaveToFile(Dictionary<string, List<string>> dictionary)
    {
        List<string> someone = new List<string>();

        foreach (var (key, value) in dictionary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(key);
            stringBuilder.Append(" ");
            var words = string.Join(" ", value);
            stringBuilder.Append(words);
            someone.Add(stringBuilder.ToString());
        }

        File.WriteAllLines(_path, someone);
    }
}