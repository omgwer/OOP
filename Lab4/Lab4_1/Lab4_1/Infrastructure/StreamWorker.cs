namespace Lab4_1.Infrastructure;

public class StreamWorker
{
    private readonly TextReader _textReader;
    private readonly TextWriter _textWriter;

    public StreamWorker(TextReader textReader, TextWriter textWriter)
    {
        _textReader = textReader;
        _textWriter = textWriter;
    }

    public string? ReadLine()
    {
       return _textReader.ReadLine();
    }

    public void Write(string value)
    {
        _textWriter.Write(value);
    }

    public void WriteLine(string value)
    {
        _textWriter.WriteLine(value);
    }
}