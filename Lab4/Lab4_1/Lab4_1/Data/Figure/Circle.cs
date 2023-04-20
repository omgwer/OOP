using Lab4_1.Core.Abstraction;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Data.Figure;

public class Circle : ISolidShape
{
    public Point Center { get; }
    public double Radius { get; }
    public uint OutlineColor { get; }
    public uint FillColor { get; }

    public Circle(Point center, double radius)
        : this(center, radius, COLOR_TRANSPARENT)
    {
    }

    public Circle(Point center, double radius, uint outlineColor)
        : this(center, radius, outlineColor, COLOR_TRANSPARENT)
    {
    }

    public Circle(Point center, double radius, uint outlineColor, uint fillColor)
    {
        Center = center;
        Radius = radius;
        OutlineColor = outlineColor;
        FillColor = fillColor;
    }

    public override string ToString()
    {
        return $"Figure - Circle, Radius - {Radius:0.00}, OutlineColor - {OutlineColor}, " +
               $"FillColor - {FillColor}, Area - {GetArea():0.00}, Perimeter - {GetPerimeter():0.00}";
    }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public uint GetOutlineColor()
    {
        throw new NotImplementedException();
    }

    public uint GetFillColor()
    {
        throw new NotImplementedException();
    }

    public void Draw(ICanvas canvas)
    {
        //var fillResize = Radius * 0.95;
        if (FillColor != COLOR_TRANSPARENT)
            canvas.FillCircle(Center, Radius, FillColor);
        if (OutlineColor != COLOR_TRANSPARENT)
            canvas.DrawCircle(Center, Radius, OutlineColor);
        
    }

    // Красный (Red): 0xFFFF0000 (4294901760)
    // Оранжевый (Orange): 0xFFFFA500 (4294944000)
    // Желтый (Yellow): 0xFFFFFF00 (4294967040)
    // Зеленый (Green): 0xFF008000 (4278255360)
    // Голубой (Cyan): 0xFF00FFFF (4278255615)
    // Синий (Blue): 0xFF0000FF (4278190335)
    // Фиолетовый (Violet): 0xFF8B00FF (4288323071)
    // Черный (Black): 0xFF000000 (4278190080)
    // Прозрачный : (0)
}