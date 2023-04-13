namespace Lab2_3.Services;

interface IStreamService
{
    Dictionary<string, List<string>> OpenFile(string path);
    void SaveToFile(Dictionary<string, List<string>> dictionary, string path);
    void Write();
}

public class StreamService : IStreamService
{
    private StreamReader _reader;
    private StreamWriter _writer;
    public StreamService(StreamReader streamReader, StreamWriter streamWriter)
    {
        _reader = streamReader;
        _writer = streamWriter;
    }

    public Dictionary<string, List<string>> OpenFile(string path)
    {
        using StreamReader streamReader = new StreamReader(path);
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

            //   MiniMiniDictionary.Add(wordWithTranslate[0], translatedWordList);
            //  translatedWordList.Clear();
        }
    }

    public void SaveToFile(Dictionary<string, List<string>> dictionary, string path)
    {
        throw new NotImplementedException();
    }

    public void Write()
    {
        throw new NotImplementedException();
    }
}