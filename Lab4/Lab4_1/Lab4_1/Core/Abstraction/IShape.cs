namespace Lab4_1.Core.Abstraction;

public interface IShape : ICanvasDrawable
{
    double GetArea();
    double GetPerimeter();
    string ToString();
    uint GetOutlineColor();
}