using Lab4_1.Infrastructure;
using Lab4_1.Service;

namespace Lab4_1;

public interface IShape
{
    double GetArea();
    double GetPerimeter();
    string ToString();
    uint GetOutlineColor();
}

public interface ISolidShape : IShape
{
    uint GetFillColor();
}

public class FigureHandler
{
    private List<IShape> _figureList = new();
    private StreamWorker _streamWorker;
    private ValidateService _validateService;
    private CommandHandler _commandHandler;
    private bool _isRun;

    public FigureHandler(TextReader textReader, TextWriter textWriter, uint canvasWidth, uint canvasHeight)
    {
        _isRun = true;
        _streamWorker = new StreamWorker(textReader, textWriter);
        _validateService = new ValidateService(canvasWidth, canvasHeight);
        _commandHandler = new CommandHandler(_figureList, _validateService);
    }

    public bool IsRun()
    {
        return _isRun;
    }

    public void LoadFiguresForMemory()
    {
        var stringValue = _streamWorker.ReadLine();
        while (stringValue != null)
        {
            _commandHandler.HandleStringCommand(stringValue);
        }
    }

    public void PrintFigureWithMinPerimeter()
    {
        
    }

    public void PrintFigureWithMaxArea()
    {
        
    }


    public void HandleInput()
    {
        
    }
}