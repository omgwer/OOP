using Lab4_1.Core.Abstraction;
using Lab4_1.Data;
using Lab4_1.Data.Figure;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Service;

public class CommandHandler
{
    private static readonly string SPACE = " ";
    private ValidateService _validateService;
    private List<IShape> _shapes;

    public CommandHandler(List<IShape> shapes, uint canvasWidth, uint canvasHeight)
    {
        _validateService = new ValidateService(canvasWidth, canvasHeight);
        _shapes = shapes;
    }

    public void HandleStringCommand(string value)
    {
        var stringList = value.Split(SPACE);
        _validateService.AssertArgumentCountForFigure(stringList.Length);
        var figureType = ConvertFirstArgumentToFigureType(stringList.First());

        switch (figureType)
        {
            case FigureType.LINE:
                _validateService.AssertArgumentCountForLine(stringList.Length);
                AddLineToList(stringList);
                break;
            case FigureType.CIRCLE:
                _validateService.AssertArgumentCountForCircle(stringList.Length);
                AddCircleToList(stringList);
                break;
            case FigureType.TRIANGLE:
                AddTriangleToList(stringList);
                _validateService.AssertArgumentCountForTriangle(stringList.Length);
                break;
            case FigureType.RECTANGLE:
                AddRectangleToList(stringList);
                _validateService.AssertArgumentCountForRectangle(stringList.Length);
                break;
            default:
                throw new ArgumentException("invalid command");
        }
    }

    private FigureType ConvertFirstArgumentToFigureType(string value)
    {
        return value switch
        {
            "line" => FigureType.LINE,
            "circle" => FigureType.CIRCLE,
            "triangle" => FigureType.TRIANGLE,
            "rectangle" => FigureType.RECTANGLE,
            _ => throw new ArgumentException(ERROR_TO_CONVERT_STRING_TO_FIGURE_TYPE)
        };
    }

    private void AddLineToList(string[] list)
    {
        Point startPoint = _validateService.ConvertToPoint(list[1], list[2]);
        Point finishPoint = _validateService.ConvertToPoint(list[3], list[4]);
        uint outlineColor = DEFAULT_COLOR;
        if (list.Length == 6)
            outlineColor = _validateService.ConvertToColor(list[5]);
        _shapes.Add(new Line(startPoint, finishPoint, outlineColor));
    }

    private void AddCircleToList(string[] list)
    {
        Point center = _validateService.ConvertToPoint(list[1], list[2]);
        double radius = _validateService.ConvertStringToPointValue(list[3]);
        uint outlineColor = DEFAULT_COLOR;
        uint fillColor = DEFAULT_COLOR;
        if (list.Length >= 5)
            outlineColor = _validateService.ConvertToColor(list[4]);
        if (list.Length >= 6)
            fillColor = _validateService.ConvertToColor(list[5]);
        _shapes.Add(new Circle(center, radius, outlineColor, fillColor));
    }

    private void AddTriangleToList(string[] list)
    {
        Point firstPoint = _validateService.ConvertToPoint(list[1], list[2]);
        Point secondPoint = _validateService.ConvertToPoint(list[3], list[4]);
        Point thirdPoint = _validateService.ConvertToPoint(list[5], list[6]);
        uint outlineColor = DEFAULT_COLOR;
        uint fillColor = DEFAULT_COLOR;
        if (list.Length >= 8)
            outlineColor = _validateService.ConvertToColor(list[7]);
        if (list.Length >= 9)
            fillColor = _validateService.ConvertToColor(list[8]);
        _shapes.Add(new Triangle(firstPoint, secondPoint, thirdPoint, outlineColor, fillColor));
    }

    private void AddRectangleToList(string[] list)
    {
        Point leftTop = _validateService.ConvertToPoint(list[1], list[2]);
        double width = _validateService.ConvertStringToPointValue(list[3]);
        double height = _validateService.ConvertStringToPointValue(list[4]);
        uint outlineColor = DEFAULT_COLOR;
        uint fillColor = DEFAULT_COLOR;
        if (list.Length >= 6)
            outlineColor = _validateService.ConvertToColor(list[5]);
        if (list.Length >= 7)
            fillColor = _validateService.ConvertToColor(list[6]);
        _shapes.Add(new Rectangle(leftTop, width, height, outlineColor, fillColor));
    }
}