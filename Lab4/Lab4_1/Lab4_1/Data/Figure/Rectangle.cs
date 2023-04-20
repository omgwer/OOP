using Lab4_1.Core.Abstraction;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Rectangle : IShape
{
    public Point LeftTop { get; }
    public double Width { get; }
    public double Height { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }

    public Rectangle(Point leftTop, double width, double height)
        : this(leftTop, width, height, COLOR_TRANSPARENT)
    {
    }

    public Rectangle(Point leftTop, double width, double height, uint outlineColor)
        : this(leftTop, width, height, outlineColor, COLOR_TRANSPARENT)
    {
    }

    public Rectangle(Point leftTop, double width, double height, uint outlineColor, uint fillColor)
    {
        LeftTop = leftTop;
        Width = width;
        Height = height;
        OutlineColor = outlineColor;
        FillColor = fillColor;
    }

    public override string ToString()
    {
        return $"Figure - Rectangle, LeftTop - {LeftTop}, Width - {Width}, Height - {Height}, " +
               $"OutlineColor - {OutlineColor}, FillColor - {FillColor}, Area - {GetArea():0.00}, Perimeter - {GetPerimeter():0.00}";
    }

    public void Draw(ICanvas canvas)
    {
        if (OutlineColor != 0)
            canvas.DrawRectangle(LeftTop, Width, Height, OutlineColor);
        if (FillColor != 0)
            canvas.FillRectangle(LeftTop, Width, Height, FillColor);
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public uint GetOutlineColor()
    {
        return OutlineColor;
    }

    public uint GetFillColor()
    {
        return FillColor;
    }
}