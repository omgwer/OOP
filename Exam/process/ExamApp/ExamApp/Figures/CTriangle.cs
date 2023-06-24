using ExamApp.Abstraction;

namespace ExamApp.Figures;


/**
 * // Треугольник, задается координатами трех вершин
class CTriangle : public ICanvasDrawable
{
  // Написать недостающий код
};
 */
public class CTriangle : ICanvasDrawable
{
    private Point _p1;
    private Point _p2;
    private Point _p3;
    
    public CTriangle(Point p1, Point p2, Point p3)
    {
        _p1 = p1;
        _p2 = p2;
        _p3 = p3;
    }

    public void Draw(ICanvas canvas)
    {
        canvas.DrawLine(_p1.X, _p1.Y, _p2.X, _p2.Y);
        canvas.DrawLine(_p2.X, _p2.Y, _p3.X, _p3.Y);
        canvas.DrawLine(_p3.X, _p3.Y, _p1.X, _p1.Y);
    }
}