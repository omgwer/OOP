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
    private List<Shape> _shapes = new List<Shape>();

    public Canvas(uint width, uint height)
    {
        //  _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
        _width = width;
        _height = height;

        // RectangleShape rectangleShape = new RectangleShape(new Vector2f(150, 5)); // прямоугольник + линия
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
        throw new NotImplementedException();
    }

    public void DrawCircle(Point center, double radius, uint lineColor)
    {
        CircleShape circleShape = new CircleShape((float)radius);
        circleShape.Position = ConvertPointToVector2f(center);
        circleShape.OutlineColor = new Color(lineColor); // TODO: добавлена прозрвчность
        circleShape.FillColor = new Color(Color.Transparent);
        circleShape.OutlineThickness = 25;
        _shapes.Add(circleShape);
    }

    public void FillCircle(Point center, double radius, uint fillColor)
    {
        CircleShape circleShape = new CircleShape((float)radius);
        circleShape.Position = ConvertPointToVector2f(center);
        circleShape.OutlineColor = new Color(Color.Transparent);
        circleShape.FillColor = new Color(fillColor);
        circleShape.OutlineThickness = 25;
        _shapes.Add(circleShape);
    }

    public void DrawTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, double lineColor)
    {
        throw new NotImplementedException();
    }

    public void FillTriangle(Point firstPoint, Point secondPoint, Point thirdPoint, double fillColor)
    {
        throw new NotImplementedException();
    }

    public void DrawRectangle(Point firstPoint, double width, double height, double lineColor)
    {
        throw new NotImplementedException();
    }

    public void FillRectangle(Point firstPoint, double width, double height, double fillColor)
    {
        throw new NotImplementedException();
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
            Color windowColor = new Color(0, 192, 255);

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