using Lab4_1.Core.Abstraction;
using Lab4_1.Data;
using Lab4_1.Data.Figure;
using Lab4_1.Infrastructure;
using Lab4_1.Service;
using SFML.Graphics;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Core;

public class FigureHandler
{
    private List<IShape> _figureList = new();
    private StreamWorker _streamWorker;
    private CommandHandler _commandHandler;
    private bool _isRun;
    private ICanvas _canvas;

    public FigureHandler(TextReader textReader, TextWriter textWriter, uint canvasWidth, uint canvasHeight)
    {
        _isRun = true;
        _canvas = new Canvas(canvasWidth, canvasHeight);
        _streamWorker = new StreamWorker(textReader, textWriter);
        _commandHandler = new CommandHandler(_figureList, canvasWidth, canvasHeight);
        _streamWorker.WriteLine(@"Program wait input:");
    }

    public bool IsRun()
    {
        return _isRun;
    }

    public void PrintFigureWithMinPerimeter()
    {
        IShape figureWithMinPerimeter = new Circle(new Point() { X = 0, Y = 0 }, 0);

        if (_figureList.Count == 0)
        {
            _streamWorker.WriteLine("Figure list is empty!");
            return;
        }

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
        if (_figureList.Count == 0)
        {
            _streamWorker.WriteLine("Figure list is empty!");
            return;
        }

        IShape figureWithMaxArea = new Circle(new Point() { X = 1, Y = 1 }, 0);
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
        var command = _streamWorker.ReadLine();
        if (string.IsNullOrEmpty(command)) return;
        switch (command)
        {
            case "draw":
                Draw();
                break;
            case "clear":
                Clear();
                break;
            case "help":
                PrintHelp();
                break;
            case "info":
                PrintInfo();
                break;
            case "exit":
                Close();
                break;
            default:
                try
                {
                    _commandHandler.HandleStringCommand(command);
                }
                catch (ArgumentException ex)
                {
                    _streamWorker.WriteLine(ex.Message);
                }

                break;
        }
    }

    private void PrintHelp()
    {
        _streamWorker.WriteLine("Available commands:");
        _streamWorker.WriteLine("   - %ADD_FIGURE%");
        _streamWorker.WriteLine("   - info");
        _streamWorker.WriteLine("   - clear");
        _streamWorker.WriteLine("   - draw");
        _streamWorker.WriteLine("   - help");
        _streamWorker.WriteLine("   - exit");
    }

    private void Draw()
    {
        foreach (var shape in _figureList)
        {
            shape.Draw(_canvas);
        }
        _canvas.Draw();
    }

    private void Clear()
    {
        _canvas.Clear();
    }

    private void PrintInfo()
    {
        PrintFigureWithMaxArea();
        PrintFigureWithMinPerimeter();
    }

    private void Close()
    {
        _isRun = false;
    }
}