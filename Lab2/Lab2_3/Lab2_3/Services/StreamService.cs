using System.Text;

namespace Lab2_3.Services;

interface IStreamService
{
    Dictionary<string, List<string>> OpenFile(string path);
    void SaveToFile(Dictionary<string, List<string>> dictionary, string path);
    void Write(string value);
    string Read();
}

public class StreamService : IStreamService
{
    private TextReader _reader;
    private TextWriter _writer;

    public StreamService(TextReader streamReader, TextWriter streamWriter)
    {
        _reader = streamReader;
        _writer = streamWriter;
    }

    ~StreamService()
    {
        _reader.Close();
        _writer.Close();
    }

    public Dictionary<string, List<string>> OpenFile(string path)
    {
        using StreamReader streamReader = new StreamReader(path);
        if (!File.Exists(path))
            throw new Exception("File not found!");
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

        return dictionary;
    }

    public void SaveToFile(Dictionary<string, List<string>> dictionary, string path)
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

        File.WriteAllLines(path, someone);
    }

    public void Write(string value)
    {
        _writer.Write(value);
    }

    public string Read()
    {
        var result = _reader.ReadLine();
        if (result != null)
            return result;
        throw new Exception("Error while read stream");
    }
}