namespace Lab2_3.Infrastructure;

public class StreamWorker
{
    private TextReader _reader;
    private TextWriter _writer;

    public StreamWorker(TextReader streamReader, TextWriter streamWriter)
    {
        _reader = streamReader;
        _writer = streamWriter;
    }

    ~StreamWorker()
    {
        _reader.Close();
        _writer.Close();
    }

    public void Write(string value)
    {
        _writer.Write(value);
    }
    
    public void WriteLine(string value)
    {
        _writer.WriteLine(value);
    }

    public string Read()
    {
        var result = _reader.ReadLine();
        if (result != null)
            return result;
        throw new Exception("Error while read stream");
    }
}