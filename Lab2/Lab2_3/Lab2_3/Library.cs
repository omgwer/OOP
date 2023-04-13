using Lab2_3.Services;

namespace Lab2_3;

interface ILibrary
{
    void FindWord(string word);
    void SaveDictionary(string path);
    void LoadDictionary(string path);
}

public class Library : ILibrary
{
    private IMiniDictionary _miniDictionary = new MiniDictionary();
    private IStreamService _streamService = new StreamService();

    public void FindWord(string word)
    {
        throw new NotImplementedException();
    }

    public void SaveDictionary(string path)
    {
    }

    public void LoadDictionary(string pathToFile)
    {
        
    }
}