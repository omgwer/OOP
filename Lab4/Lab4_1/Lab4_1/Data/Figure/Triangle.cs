using Lab4_1.Core.Abstraction;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Triangle : IShape
{
    public Point FirstPoint { get; }
    public Point SecondPoint { get; }
    public Point ThirdPoint { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }
    private double firstEdgeLength;
    private double secondEdgeLength;
    private double thirdEdgeLength;

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        : this(firstPoint, secondPoint, thirdPoint, COLOR_TRANSPARENT)
    {
    }

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint outlineColor)
        : this(firstPoint, secondPoint, thirdPoint, outlineColor, COLOR_TRANSPARENT)
    {
    }

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint outlineColor, uint fillColor)
    {
        FirstPoint = firstPoint;
        SecondPoint = secondPoint;
        ThirdPoint = thirdPoint;
        OutlineColor = outlineColor;
        FillColor = fillColor;
        GetTriangleEdgesLength();
    }

    public override string ToString()
    {
        return
            $"Figure - Triangle, FirstPoint - {FirstPoint}, SecondPoint - {SecondPoint}, ThirdPoint - {ThirdPoint}, " +
            $"OutlineColor - {OutlineColor}, FillColor - {FillColor}, Area - {GetArea()}, Perimeter - {GetPerimeter()}";
    }

    public void Draw(ICanvas canvas)
    {
        if (OutlineColor != 0)
            canvas.DrawTriangle(FirstPoint,SecondPoint, ThirdPoint, OutlineColor);
        if (FillColor != 0)
            canvas.FillTriangle(FirstPoint,SecondPoint, ThirdPoint, FillColor);
    }

    public double GetArea()
    {
        double halfPerimeter = GetPerimeter() / 2;
        var triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - firstEdgeLength) *
                                     (halfPerimeter - secondEdgeLength) * (halfPerimeter - thirdEdgeLength));
        return triangleArea;
    }

    public double GetPerimeter()
    {
        return firstEdgeLength + secondEdgeLength + thirdEdgeLength;
    }

    public uint GetOutlineColor()
    {
        return OutlineColor;
    }

    public uint GetFillColor()
    {
        return FillColor;
    }

    private void GetTriangleEdgesLength()
    {
        firstEdgeLength = GetEdgeLength(FirstPoint, SecondPoint);
        secondEdgeLength = GetEdgeLength(SecondPoint, ThirdPoint);
        thirdEdgeLength = GetEdgeLength(ThirdPoint, FirstPoint);
    }

    private double GetEdgeLength(Point firstPoint, Point secondPoint)
    {
        var first = secondPoint.X - firstPoint.X;
        var second = secondPoint.Y - firstPoint.Y;
        var result = Math.Sqrt(Math.Pow(first, 2) + Math.Pow(second, 2));
        return result;
    }
}