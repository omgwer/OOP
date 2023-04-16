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
}