using Lab6_1.Exceptions;

namespace Lab6_1.Infrastructure;

public class HttpUrlHandler
{
    private TextReader _streamReader;
    private TextWriter _streamWriter;
    private bool _isRun;
    public bool IsRun => _isRun;

    public HttpUrlHandler(TextReader streamReader, TextWriter streamWriter)
    {
        _streamReader = streamReader;
        _streamWriter = streamWriter;
        _isRun = true;
        _streamWriter.WriteLine("Program is run!");
    }

    public void HandleInput()
    {
        var inputString = _streamReader.ReadLine();
        if (inputString == null)
        {
            _isRun = false;
            _streamWriter.WriteLine("Program is closed");
            return;
        }

        try
        {
            var value = new HttpUrl(inputString);
            _streamWriter.WriteLine(value.ToString());
        }
        catch (UrlParseError ex)
        {
            _streamWriter.WriteLine($"Cant convert this string - {inputString}. Errors :" + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Runtime error" + ex.Message);
        }
    }
}