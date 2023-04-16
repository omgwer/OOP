using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Triangle : ISolidShape
{
    public Point FirstPoint { get; }
    public Point SecondPoint { get; }
    public Point ThirdPoint { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        : this(firstPoint, secondPoint, thirdPoint, DEFAULT_COLOR)
    {
    }

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint outlineColor)
        : this(firstPoint, secondPoint, thirdPoint, outlineColor, DEFAULT_COLOR)
    {
    }

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint outlineColor, uint fillColor)
    {
        FirstPoint = firstPoint;
        SecondPoint = secondPoint;
        ThirdPoint = thirdPoint;
        OutlineColor = outlineColor;
        FillColor = fillColor;
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    public double GetArea()
    {
        throw new NotImplementedException();
    }

    public double GetPerimeter()
    {
        throw new NotImplementedException();
    }

    public uint GetOutlineColor()
    {
        throw new NotImplementedException();
    }

    public uint GetFillColor()
    {
        throw new NotImplementedException();
    }
}