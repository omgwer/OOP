using Lab2_3.Services;

namespace Lab2_3;

public class Library
{
    private readonly string closeCommand = "...";
    private MiniDictionary _miniDictionary = new ();
    private StreamService _streamService;
    private bool _isRun;
    private string path = string.Empty;

    public Library(TextReader textReader, TextWriter textWriter)
    {
        _isRun = true;
        _streamService = new StreamService(textReader, textWriter);
    }

    public bool IsRun()
    {
        return _isRun;
    }

    public void HandleInput()
    {
        _streamService.WriteLine("Input file name for open file, or input empty string for create a new dictionary");
        var optionalFilePath = _streamService.Read();
        if (optionalFilePath == closeCommand)
            _streamService.WriteLine("Dictionary is close");
        if (optionalFilePath != string.Empty)
        {
            path = optionalFilePath;
            var dictionary = _streamService.OpenFile(optionalFilePath);
            _miniDictionary.SetDictionary(dictionary);
        }
        else
        {
            _streamService.WriteLine("File name has hot been input! Dictionary create in program memory");
        }

        while (_isRun)
        {
            var wordToTranslate = _streamService.Read();
            if (wordToTranslate == closeCommand)
            {
                _streamService.WriteLine("Dictionary has been changed , input 'Y' or 'y' for save changes");
                var requestValue = _streamService.Read();
                if (requestValue == "Y" | requestValue == "y")
                {
                    if (path == string.Empty)
                    {
                        _streamService.WriteLine("File name is not entered, please input file name");
                        path = _streamService.Read();
                    }
                    _streamService.SaveToFile(_miniDictionary.GetDictionary(), path);    
                }

                _isRun = false;
                return;
            }
            var translatedWords = _miniDictionary.TranslateWord(wordToTranslate);
            if (translatedWords == null)
            {
                _streamService.WriteLine($"Translate for this word - {wordToTranslate} not found. Input translated word for add to dictionary or empty string for cancel");
                var translateToInputWord = _streamService.Read();
                if (Equals(translatedWords, ""))
                {
                    _streamService.WriteLine($"Word {wordToTranslate} ignored");
                }
                else
                {
                    _miniDictionary.AddWord(wordToTranslate, translateToInputWord);
                    _streamService.WriteLine($"Word - {translateToInputWord} added for a dictionary");
                }
            }
            else
            {
                foreach (var translatedWord in translatedWords)
                {
                    _streamService.Write(translatedWord + " ");
                    _streamService.WriteLine(string.Empty);
                }
            }
        }
    }
}