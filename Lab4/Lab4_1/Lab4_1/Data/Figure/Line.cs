using Lab4_1.Core.Abstraction;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Line : IShape
{
    public Point StartPoint { get; }
    public Point FinishPoint { get; }
    public uint OutlineColor { get; }

    public Line(Point startPoint, Point finishPoint)
        : this(startPoint, finishPoint, DEFAULT_COLOR)
    {
    }

    public Line(Point startPoint, Point finishPoint, uint outlineColor)
    {
        StartPoint = startPoint;
        FinishPoint = finishPoint;
        OutlineColor = outlineColor;
    }

    public override string ToString()
    {
        return $"Figure - Line, StartPoint - {StartPoint}, FinishPoint - {FinishPoint}, " +
               $"OutlineColor - {OutlineColor}, Area - {GetArea()}, Perimeter - {GetPerimeter()}";
    }

    public void Draw(ICanvas canvas)
    {
        throw new NotImplementedException();
    }

    public double GetArea()
    {
        return 0;
    }

    public double GetPerimeter()
    {
        return 0;
    }

    public uint GetOutlineColor()
    {
        throw new NotImplementedException();
    }
}