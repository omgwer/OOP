using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data;

public static class PointHelper
{
    public static Point ConvertToPoint(string x, string y)
    {
        return new Point()
        {
            X = ConvertStringToPointValue(x),
            Y = ConvertStringToPointValue(y)
        };
    }
    
    public static double ConvertStringToPointValue(string value)
    {
        if (double.TryParse(value, out var result) && result >= 0)
            return result;
        throw new ArgumentException(ERROR_TO_CONVERT_STRING_TO_DOUBLE);
    }
}