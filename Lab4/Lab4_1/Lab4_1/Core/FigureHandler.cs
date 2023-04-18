using Lab4_1.Core.Abstraction;
using Lab4_1.Data;
using Lab4_1.Data.Figure;
using Lab4_1.Infrastructure;
using Lab4_1.Infrastructure.Draw;
using Lab4_1.Service;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Core;

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
        while (!string.IsNullOrEmpty(stringValue))
        {
            _commandHandler.HandleStringCommand(stringValue);
            stringValue = _streamWorker.ReadLine();
        }
    }

    public void PrintFigureWithMinPerimeter()
    {
        IShape figureWithMinPerimeter = new Circle(new Point() { X = 1, Y = 1 }, 1);
        double figurePerimeter = double.MaxValue;
        foreach (var shape in _figureList)
        {
            if (shape.GetPerimeter() < figurePerimeter)
                figureWithMinPerimeter = shape;
        }
        _streamWorker.WriteLine(FIGURE_WITH_MIN_PERIMETER);
        _streamWorker.WriteLine(figureWithMinPerimeter.ToString());
    }

    public void PrintFigureWithMaxArea()
    {
        IShape figureWithMaxArea = new Circle(new Point() { X = 1, Y = 1 }, 1);
        double maxArea = 0;
        foreach (var shape in _figureList)
        {
            if (shape.GetArea() > maxArea)
                figureWithMaxArea = shape;
        }
        _streamWorker.WriteLine(FIGURE_WITH_MAX_AREA);
        _streamWorker.WriteLine(figureWithMaxArea.ToString());
    }


    public void HandleInput()
    {
        _streamWorker.WriteLine(@"Program wait input:");
        var command = _streamWorker.ReadLine();
        switch (command)
        {
            case "help" : 
                PrintHelp();
                break;
            case "draw" :
                Draw();
                break;
            case "exit":
                _isRun = false;
                break;
        }
    }

    private void PrintHelp()
    {
        _streamWorker.WriteLine("Available commands:");
        _streamWorker.WriteLine("   - help");
        _streamWorker.WriteLine("   - draw");
        _streamWorker.WriteLine("   - exit");
    }

    private void Draw()
    {
        var canvas = new Canvas(800, 600);
        canvas.Draw();
    }
}