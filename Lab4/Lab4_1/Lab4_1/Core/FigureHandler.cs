using Lab4_1.Core.Abstraction;
using Lab4_1.Infrastructure;
using Lab4_1.Service;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Core;

public class FigureHandler
{
    private readonly List<IShape> _figureList = new();
    private readonly StreamWorker _streamWorker;
    private readonly CommandHandler _commandHandler;
    private bool _isRun;
    private readonly ICanvas _canvas;
    Mutex mutexObj = new();

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
        IShape? figureWithMinPerimeter = null;
        double figurePerimeter = double.MaxValue;
        foreach (var shape in _figureList)
        {
            if (shape.GetPerimeter() < figurePerimeter)
            {
                figureWithMinPerimeter = shape;
                figurePerimeter = shape.GetPerimeter();
            }
        }

        _streamWorker.WriteLine(FIGURE_WITH_MIN_PERIMETER);
        _streamWorker.WriteLine(figureWithMinPerimeter!.ToString());
    }

    public void PrintFigureWithMaxArea()
    {
        IShape? figureWithMaxArea = null;
        double maxArea = 0;

        foreach (var shape in _figureList)
        {
            if (shape.GetPerimeter() == 0)
                continue;
            if (shape.GetArea() > maxArea)
            {
                figureWithMaxArea = shape;
                maxArea = shape.GetArea();
            }
        }

        _streamWorker.WriteLine(FIGURE_WITH_MAX_AREA);
        _streamWorker.WriteLine(figureWithMaxArea!.ToString());
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
        if (_figureList.Count == 0)
            _streamWorker.WriteLine("Nothing to draw, figure list is empty!");
        mutexObj.WaitOne();
        foreach (var shape in _figureList)
        {
            shape.Draw(_canvas);
        }
        mutexObj.ReleaseMutex();
        _canvas.Draw(mutexObj);
    }

    private void Clear()
    {
        _canvas.Clear();
    }

    private void PrintInfo()
    {
        if (_figureList.Count == 0)
        {
            _streamWorker.WriteLine("Nothing to print info! Figure list is empty!");
            return;
        }

        PrintFigureWithMaxArea();
        PrintFigureWithMinPerimeter();
    }

    private void Close()
    {
        _isRun = false;
    }
}