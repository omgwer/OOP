namespace Lab4_1.Core.Abstraction;

public interface IShape
{
    double GetArea();
    double GetPerimeter();
    string ToString();
    uint GetOutlineColor();
}