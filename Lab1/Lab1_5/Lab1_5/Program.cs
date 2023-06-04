
namespace  Lab1_5;

public class Program
{
    private struct Command
    {
        public string inputFileName;
        public string outputFileName;
    }

    public static void Main(string[] args)
    {
        Command command = ParseArgs(args);
        using TextReader inputStream = new StreamReader(command.inputFileName);
        using TextWriter outputStream = new StreamWriter(command.outputFileName);
        
        var canvasInfo = Fill.ReadCanvasFromStream(inputStream);
        var fillResult = Fill.FillCanvas(canvasInfo);
        Fill.WriteToStream(outputStream, fillResult);
    }

    private static Command ParseArgs(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Invalid arguments count!");
        }

        return new Command()
        {
            inputFileName = args.First(),
            outputFileName = args.Last()
        };
    }
}