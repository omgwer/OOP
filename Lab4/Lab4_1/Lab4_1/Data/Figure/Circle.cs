using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Circle : ISolidShape
{
    public Point Center { get; }
    public double Radius { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }

    public Circle(Point center, double radius)
        : this(center, radius, DEFAULT_COLOR)
    {
    }

    public Circle(Point center, double radius, uint outlineColor) 
        : this(center, radius, outlineColor, DEFAULT_COLOR)
    {
    }

    public Circle(Point center, double radius, uint outlineColor, uint fillColor)
    {
        Center = center;
        Radius = radius;
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