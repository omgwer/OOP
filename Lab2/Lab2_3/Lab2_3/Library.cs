using Lab2_3.Services;

namespace Lab2_3;

interface ILibrary
{
    Library Run();
    void HandleInput();
}

public class Library : ILibrary
{
    private IMiniDictionary _miniDictionary = new MiniDictionary();
    private IStreamService _streamService;
    private bool _isRun = false;

    public Library(TextReader textReader, TextWriter textWriter)
    {
        _isRun = true;
        _streamService = new StreamService(textReader, textWriter);
    }

    public Library Run()
    {
        _isRun = true;
        return this;
    }

    public void HandleInput()
    {
        while (_isRun)
        {
            
        }
    }
}