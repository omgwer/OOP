using Lab4_1.Core.Abstraction;
using Lab4_1.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static Lab4_1.Dictionary.FigureDictionary;

namespace Lab4_1.Infrastructure;

public class Canvas : ICanvas
{
    private RenderWindow _window;
    private readonly uint _width;
    private readonly uint _height;
    private bool _isRun;
    private Thread renderThread;
    private List<Shape> _shapes = new List<Shape>();

    public Canvas(uint width, uint height)
    {
        //  _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
        _width = width;
        _height = height;

       
        // ConvexShape convexShape = new ConvexShape(); // треугольник
        //
        // convexShape.SetPointCount(3);
        // convexShape.SetPoint(0, new Vector2f(35, 35));
        // convexShape.SetPoint(1, new Vector2f(45, 45));
        // convexShape.SetPoint(2, new Vector2f(25, 50));

        //
        // _shapes.Add(rectangleShape);
        // _shapes.Add(convexShape);
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
        throw new NotImplementedException();
    }

    public void FillTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, uint fillColor)
    {
        throw new NotImplementedException();
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

            //TODO: https://www.sfml-dev.org/tutorials/2.4/graphics-vertex-array.php

            while (_window.IsOpen)
            {
                // Process events
                _window.DispatchEvents();

                // Clear screen
                _window.Clear(windowColor);

                foreach (var shape in _shapes)
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


    /*
     *  sf::RectangleShape shape1;
    shape1.setSize({180, 580});
    shape1.setPosition({10, 10});
    shape1.setFillColor(sf::Color(0x4D, 0x4D, 0x4D));
    window.draw(shape1);

    sf::CircleShape shape2(85);
    shape2.setPosition({15, 30});
    shape2.setFillColor(sf::Color(0x0, 0xBB, 0x0));
    window.draw(shape2);
    
     sf::ConvexShape trapeze;
    trapeze.setFillColor(sf::Color(103, 27, 26));
    trapeze.setPosition(400, 150);
    trapeze.setPointCount(4);
    trapeze.setPoint(0, {-220, -20});
    trapeze.setPoint(1, {130, -20});
    trapeze.setPoint(2, {280, 105});
    trapeze.setPoint(3, {-390, 105});
    window.draw(trapeze);
    
    // create an array of 3 vertices that define a triangle primitive
sf::VertexArray triangle(sf::Triangles, 3);

// define the position of the triangle's points
triangle[0].position = sf::Vector2f(10, 10);
triangle[1].position = sf::Vector2f(100, 10);
triangle[2].position = sf::Vector2f(100, 100);

// define the color of the triangle's points
triangle[0].color = sf::Color::Red;
triangle[1].color = sf::Color::Blue;
triangle[2].color = sf::Color::Green;
     */
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