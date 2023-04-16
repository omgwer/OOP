using Lab2_3.Dictionary;
using Lab2_3.Infrastructure;

namespace Lab2_3;

public class Library
{
    private Services.Dictionary _dictionary = new ();
    private StreamWorker _streamService;
    private FileWorker? _fileWorker;
    private bool _isRun;
    private bool _isDictionaryChanged = false;

    public Library(TextReader textReader, TextWriter textWriter)
    {
        _isRun = true;
        _streamService = new StreamWorker(textReader, textWriter);
    }

    public bool IsRun()
    {
        return _isRun;
    }

    public void HandleInput()
    {
        InitializeLibrary();
        
        while (_isRun)
        {
            var wordToTranslate = Read();
            if (wordToTranslate == MessageDictionary.CLOSE_COMMAND)
            {
                CloseLibrary();
                return;
            }
            var translatedWords = TranslateWord(wordToTranslate);
            if (IsTranslateFound(translatedWords))
                PrintTranslatedWords(translatedWords!);
            else
                TryUpdateLibrary(wordToTranslate);
        }
    }

    private void TryUpdateLibrary(string wordToTranslate)
    {
        _streamService.WriteLine(MessageDictionary.GetTranslateNotFoundMessage(wordToTranslate));
        var translateToInputWord = _streamService.Read();
        if (Equals(translateToInputWord, string.Empty))
        {
            _streamService.WriteLine(MessageDictionary.GetDeclineToAddWordToDictionaryMessage(wordToTranslate));
        }
        else
        {
            _isDictionaryChanged = true;
            try
            {
                _dictionary.AddWord(wordToTranslate, translateToInputWord);
                _streamService.WriteLine(MessageDictionary.GetWordAddToLibraryMessage(wordToTranslate));

            }
            catch (ArgumentException ex)
            {
                _streamService.WriteLine(ex.Message);
            }
        }
    }

    private void InitializeLibrary()
    {
        _streamService.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST);
        var optionalFilePath = Read();
        if (optionalFilePath != string.Empty)
        {
            _fileWorker = new FileWorker(optionalFilePath);
            var dictionary = _fileWorker.OpenFile();
            _dictionary.SetDictionary(dictionary);
        }
        else
            _streamService.WriteLine(MessageDictionary.CREATE_NEW_DICTIONARY_ALERT);
    }

    private void CloseLibrary()
    {
        _isRun = false;
        if (!_isDictionaryChanged)
        {
            _streamService.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE);
            return;
        }
        _streamService.WriteLine(MessageDictionary.SAVE_FILE_REQUEST);
        var requestValue = Read();
        if (NeedToSaveFile(requestValue))
        {
            if (_fileWorker == null)
            {
                CreateNewFile();
            }
            _fileWorker!.SaveToFile(_dictionary.GetDictionary());    
            _streamService.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITH_SAVE_MESSAGE);
        }
        _streamService.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE);
    }

    private string Read()
    {
        return _streamService.Read();
    }

    private bool NeedToSaveFile(string value)
    {
        return value == MessageDictionary.ACCEPT_SAVE_DICTIONARY_CHAR || value == MessageDictionary.ACCEPT_SAVE_DICTIONARY_CHAR;
    }

    private void CreateNewFile()
    {
        _streamService.WriteLine(MessageDictionary.SAVE_NEW_FILE_REQUEST);
        _fileWorker = new FileWorker(_streamService.Read());
    }

    private List<string>? TranslateWord(string wordToTranslate)
    {
        return _dictionary.TranslateWord(wordToTranslate);
    }

    private void PrintTranslatedWords(List<string> list)
    {
        foreach (var translatedWord in list)
        {
            _streamService.Write(translatedWord);
            _streamService.Write(" ");
        }
        _streamService.WriteLine(string.Empty);
    }

    private bool IsTranslateFound(List<string>? list)
    {
        return list != null;
    }
}