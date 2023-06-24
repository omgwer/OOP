using ExamApp.Abstraction;

namespace ExamApp.Figures;

/**
 * // Прямоугольник, обладающий координатами верхнего левого угла, шириной и высотой
class CRectangle : public ICanvasDrawable
{
  // Написать недостающий код
};
 */

public class CRectangle : ICanvasDrawable
{
    private Point point;
    private int width;
    private int height;
    
    public CRectangle(Point point, int width, int height)
    {
        ValidateParameters(width, height);
        this.point = point;
        this.width = width;
        this.height = height;
    }

    public void Draw(ICanvas canvas)
    {
        canvas.DrawLine(point.X, point.Y, point.X + width, point.Y);
        canvas.DrawLine(point.X, point.Y, point.X, point.Y + height);
        canvas.DrawLine(point.X + width, point.Y, point.X + width, point.Y + height);
        canvas.DrawLine(point.X, point.Y + height, point.X + width, point.Y + height);
    }

    private static void ValidateParameters(int width, int height)
    {
        if (width <= 0 && height <= 0)
            throw new ArgumentException("Значение не может быть отрицательным");
    }
}