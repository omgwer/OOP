using Lab4_1.Data;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Service;

public class ValidateService
{
    private readonly uint _canvasWidth;
    private readonly uint _canvasHeight;

    private static readonly int
        LINE_MIN_PARAMETERS_COUNT = 5,
        LINE_MAX_PARAMETERS_COUNT = 6,
        CIRCLE_MIN_PARAMETERS_COUNT = 4,
        CIRCLE_MAX_PARAMETERS_COUNT = 6,
        TRIANGLE_MIN_PARAMETERS_COUNT = 7,
        TRIANGLE_MAX_PARAMETERS_COUNT = 9,
        RECTANGLE_MIN_PARAMETERS_COUNT = 5,
        RECTANGLE_MAX_PARAMETERS_COUNT = 7;

    public ValidateService(uint canvasWidth, uint canvasHeight)
    {
        _canvasWidth = canvasWidth;
        _canvasHeight = canvasHeight;
    }

    public Point ConvertToPoint(string x, string y)
    {
        return new Point()
        {
            X = ConvertStringToPointValue(x),
            Y = ConvertStringToPointValue(y)
        };
    }
    
    public double ConvertStringToPointValue(string value)
    {
        if (double.TryParse(value, out var result) && result >= 0)
            return result;
        throw new ArgumentException(ERROR_TO_CONVERT_STRING_TO_DOUBLE);
    }

    public uint ConvertToColor(string value)
    {
        if (uint.TryParse(value, out var result))
            return result;
        throw new ArgumentException(ERROR_TO_CONVERT_STRING_TO_COLOR);
    }

    public void AssertArgumentCountForFigure(int argumentsCount)
    {
        AssertArgumentsCount(argumentsCount, CIRCLE_MIN_PARAMETERS_COUNT, TRIANGLE_MAX_PARAMETERS_COUNT);
    }

    public void AssertArgumentCountForLine(int argumentsCount)
    {
        AssertArgumentsCount(argumentsCount, LINE_MIN_PARAMETERS_COUNT, LINE_MAX_PARAMETERS_COUNT);
    }

    public void AssertArgumentCountForCircle(int argumentsCount)
    {
        AssertArgumentsCount(argumentsCount, CIRCLE_MIN_PARAMETERS_COUNT, CIRCLE_MAX_PARAMETERS_COUNT);
    }

    public void AssertArgumentCountForTriangle(int argumentsCount)
    {
        AssertArgumentsCount(argumentsCount, TRIANGLE_MIN_PARAMETERS_COUNT, TRIANGLE_MAX_PARAMETERS_COUNT);
    }

    public void AssertArgumentCountForRectangle(int argumentsCount)
    {
        AssertArgumentsCount(argumentsCount, RECTANGLE_MIN_PARAMETERS_COUNT, RECTANGLE_MAX_PARAMETERS_COUNT);
    }

    private void AssertArgumentsCount(int argumentsCount, int minCount, int maxCount)
    {
        if (argumentsCount < minCount || argumentsCount > maxCount)
            throw new ArgumentException(INVALID_ARGUMENT_COUNT_ALERT);
    }
}