namespace ExamApp.Abstraction;

/*
 // Холст, позволяющий рисовать графические примитивы
class ICanvas
{
public:
  virtual void DrawLine(int x0, int y0, int x1, int y1) = 0;
  virtual ~ICanvas() {}
};
 */
public interface ICanvas
{
    void DrawLine(int x0, int y0, int x1, int y1);
}