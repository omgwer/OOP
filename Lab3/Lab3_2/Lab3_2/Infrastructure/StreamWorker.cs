using Lab3_2.Dictionary;

namespace Lab3_2.Infrastructure;

interface IStreamWorker
{
    Command Read(TextReader textReader);
    void Write(string value, TextWriter textWriter);
}

public class StreamWorker : IStreamWorker
{
    public Command? Read(TextReader textReader)
    {
        var t = textReader.ReadLine();
        return null;
    }

    public void Write(string value, TextWriter textWriter)
    {
        throw new NotImplementedException();
    }
}