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
        AssertIsFileExist();
        using var streamReader = new StreamReader(_path);
        var dictionary = new Dictionary<string, List<string>>();
        while (streamReader.ReadLine() is { } wordsString)
        {
            var translatedWordList = new List<string>();
            var wordWithTranslate = wordsString!.Split(" ");
            ValidateInput(wordWithTranslate);

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
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(key);
            stringBuilder.Append(' ');
            var words = string.Join(" ", value);
            stringBuilder.Append(words);
            someone.Add(stringBuilder.ToString());
        }

        File.WriteAllLines(_path, someone);
    }

    private void ValidateInput(string[] value)
    {
        if (value.Length < 2)
        {
            throw new Exception(MessageDictionary.PARSE_FILE_ERROR_ONE_WORD_IN_LINE);
        }
    }

    private void AssertIsFileExist()
    {
        if (!File.Exists(_path))
            throw new FileNotFoundException(MessageDictionary.FILE_NOT_FOUND_ALERT);
    }
}