using Lab3_2.Dictionary;

namespace Lab3_2.Infrastructure;

interface IStreamWorker
{
    string Read(TextReader textReader);
    void Write(string value, TextWriter textWriter);
}

public class StreamWorker : IStreamWorker
{
    public string Read(TextReader textReader)
    {
        var lineRead = textReader.ReadLine();
        if (lineRead == null)
            throw new IOException("Error in stream read!!!");
        return lineRead;
    }

    public void Write(string value, TextWriter textWriter)
    {
        throw new NotImplementedException();
    }
}