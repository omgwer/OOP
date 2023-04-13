using Lab3_2.Dictionary;

namespace Lab3_2.Infrastructure;

interface IStreamWorker
{
    Command ReadCommand();
    void Write(string value);
    void WriteLine(string value);
    void WriteResult(double? value);
}

public class StreamWorker
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public StreamWorker(TextReader textReader, TextWriter textWriter)
    {
        _input = textReader;
        _output = textWriter;
    }
    
    ~StreamWorker()
    {
        _input.Close();
        _output.Close();
    }

    public Command ReadCommand()
    {
        var command = _input.ReadLine();
        return command switch
        {
            null => throw new IOException("Error while read stream"),
            "close" => new Command {CommandType = CommandType.CLOSE},
            "exit" => new Command {CommandType = CommandType.CLOSE},
            "help" => new Command() {CommandType = CommandType.HELP},
            _ => CommandAdapter.ConvertToCommand(command)
        };
    }

    public void Write(string value)
    {
        _output.Write(value);
    }

    public void WriteLine(string value)
    {
        _output.WriteLine(value);
    }

    public void WriteResult(double? value)
    {
        _output.Write(value == null ? "nan" : $"{value:0.00}");
    }
}