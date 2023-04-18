using Lab4_1.Data;

namespace Lab4_1.Core.Abstraction;

public interface ICanvas
{
    void DrawLine(Point start, Point finish, uint lineColor);
    void DrawCircle(Point center, double radius, uint lineColor);
    void FillCircle(Point center, double radius, uint fillColor);
    void DrawTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, double lineColor);
    void FillTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, double fillColor);
    void DrawRectangle(Point firstPoint, double width, double height, double lineColor);
    void FillRectangle(Point firstPoint, double width, double height, double fillColor);
    // void
    void Draw();
}