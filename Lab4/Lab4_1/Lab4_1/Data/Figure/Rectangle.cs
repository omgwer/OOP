using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Rectangle : ISolidShape
{
    public Point LeftTop { get; }
    public double Width { get; }
    public double Height { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }
    
    public Rectangle(Point leftTop, double width, double height) 
        : this(leftTop, width, height, DEFAULT_COLOR)
    {
    }

    public Rectangle(Point leftTop, double width, double height, uint outlineColor) 
        : this(leftTop, width, height, outlineColor,DEFAULT_COLOR)
    {
    }

    public Rectangle(Point leftTop, double width, double height, uint outlineColor, uint fillColor)
    {
        LeftTop = leftTop;
        Width = width;
        Height = height;
        OutlineColor =  outlineColor;
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