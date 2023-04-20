using Lab4_1.Core.Abstraction;
using Lab4_1.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Lab4_1.Infrastructure;

public class Canvas : ICanvas
{
    private RenderWindow _window;
    private readonly uint _width;
    private readonly uint _height;
    private bool _isRun;
    private Thread renderThread;
    private List<Shape> _shapes = new();

    public Canvas(uint width, uint height)
    {
        _width = width;
        _height = height;
    }

    public void DrawLine(Point start, Point finish, uint lineColor)
    {
        Vector2f startPoint = ConvertPointToVector2f(start);
        Vector2f endPoint = ConvertPointToVector2f(finish);
        Vector2f direction = endPoint - startPoint;
        float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
        float thickness = 5;
        RectangleShape line = new RectangleShape(new Vector2f(length, thickness));
        line.Position = startPoint;
        line.FillColor = ConvertUintToColor(lineColor);
        line.Rotation = (float)Math.Atan2(direction.Y, direction.X) * 180 / (float)Math.PI;
        _shapes.Add(line);
    }

    // TODO: при масшабировании скрывать, а не скейлить
    public void DrawCircle(Point center, double radius, uint lineColor)
    {
        CircleShape circleShape = new CircleShape((float)radius);
        circleShape.Position = ConvertPointToVector2f(center);
        circleShape.OutlineColor = ConvertUintToColor(lineColor);
        circleShape.FillColor = new Color(Color.Transparent);
        circleShape.OutlineThickness = 4;
        _shapes.Add(circleShape);
    }

    public void FillCircle(Point center, double radius, uint fillColor)
    {
        CircleShape circleShape = new CircleShape((float)radius);
        circleShape.Position = ConvertPointToVector2f(center);
        circleShape.OutlineColor = new Color(Color.Transparent);
        circleShape.FillColor = ConvertUintToColor(fillColor);
        _shapes.Add(circleShape);
    }

    public void DrawTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint lineColor)
    {
        ConvexShape convexShape = new ConvexShape();

        convexShape.SetPointCount(3);
        convexShape.SetPoint(0, ConvertPointToVector2f(firstPoint));
        convexShape.SetPoint(1, ConvertPointToVector2f(secondPoint));
        convexShape.SetPoint(2, ConvertPointToVector2f(thirdPoint));

        convexShape.OutlineColor = ConvertUintToColor(lineColor);
        convexShape.FillColor = Color.Transparent;
        convexShape.OutlineThickness = 4;

        _shapes.Add(convexShape);
    }

    public void FillTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint fillColor)
    {
        ConvexShape convexShape = new ConvexShape();

        convexShape.SetPointCount(3);
        convexShape.SetPoint(0, ConvertPointToVector2f(firstPoint));
        convexShape.SetPoint(1, ConvertPointToVector2f(secondPoint));
        convexShape.SetPoint(2, ConvertPointToVector2f(thirdPoint));

        convexShape.OutlineColor = Color.Transparent;
        convexShape.FillColor = ConvertUintToColor(fillColor);
        convexShape.OutlineThickness = 4;

        _shapes.Add(convexShape);
    }

    public void DrawRectangle(Point firstPoint, double width, double height, uint lineColor)
    {
        RectangleShape rectangleShape = new RectangleShape();
        rectangleShape.Position = ConvertPointToVector2f(firstPoint);
        rectangleShape.Size = new Vector2f((float)width, (float)height);
        rectangleShape.OutlineColor = ConvertUintToColor(lineColor);
        rectangleShape.FillColor = Color.Transparent;
        rectangleShape.OutlineThickness = 4;
        _shapes.Add(rectangleShape);
    }

    public void FillRectangle(Point firstPoint, double width, double height, uint fillColor)
    {
        RectangleShape rectangleShape = new RectangleShape();
        rectangleShape.Position = ConvertPointToVector2f(firstPoint);
        rectangleShape.Size = new Vector2f((float)width, (float)height);
        rectangleShape.FillColor = ConvertUintToColor(fillColor);
        rectangleShape.OutlineColor = Color.Transparent;
        _shapes.Add(rectangleShape);
    }

    public void Clear()
    {
        _shapes.Clear();
    }

    public void Draw()
    {
        if (_isRun)
            return;
        renderThread = new Thread(() =>
        {
            _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            _window.SetActive();
            _window.Closed += new EventHandler(OnClose);
            Color windowColor = new Color(Color.White);
            while (_window.IsOpen)
            {
                // Process events
                _window.DispatchEvents();

                // Clear screen
                _window.Clear(windowColor);

                var shapes = new List<Shape>(_shapes);
                foreach (var shape in shapes)
                {
                    _window.Draw(shape);
                }


                _window.Display();
            }
        });
        renderThread.Start();
        _isRun = true;
    }

    private void OnClose(object sender, EventArgs e)
    {
        RenderWindow window = (RenderWindow)sender;
        window.Close();
    }

    private Vector2f ConvertPointToVector2f(Point point)
    {
        return new Vector2f((float)point.X, (float)point.Y);
    }

    private Color ConvertUintToColor(uint color)
    {
        byte red = (byte)((color >> 16) & 0xFF);
        byte green = (byte)((color >> 8) & 0xFF);
        byte blue = (byte)(color & 0xFF);
        byte alpha = (byte)((color >> 24) & 0xFF);
        return new Color(red, green, blue, alpha);
    }
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