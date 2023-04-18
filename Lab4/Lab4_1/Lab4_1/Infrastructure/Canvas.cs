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

    public Canvas(uint width, uint height)
    {
        //  _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
        _width = width;
        _height = height;
    }

    public void DrawLine(Point start, Point finish, uint lineColor)
    {
        throw new NotImplementedException();
    }

    public void DrawCircle(Point center, double radius, uint lineColor)
    {
        throw new NotImplementedException();
    }

    public void FillCircle(Point center, double radius, uint fillColor)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Draw()
    {
        if (_isRun)
            return;
        renderThread = new Thread(() =>
        {
            _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            _window.SetActive();
            // Ваш код для отрисовки фигур на canvas
            _window.Closed += new EventHandler(OnClose);
            Color windowColor = new Color(0, 192, 255);

            CircleShape test;
            RectangleShape test1;
            Vertex test2 = new Vertex(new Vector2f(5, 5), new Color(123, 123, 123), new Vector2f(50, 50));
            //TODO: https://www.sfml-dev.org/tutorials/2.4/graphics-vertex-array.php
            
            // Start the game loop
            while (_window.IsOpen)
            {
                // Process events
                _window.DispatchEvents();

                // Clear screen
                _window.Clear(windowColor);

            //    _window.Draw(test2);
                // Update the window
                _window.Display();
            } //End game loop
        });
        renderThread.Start();
        _isRun = true;
    } //End Main()

    private void OnClose(object sender, EventArgs e)
    {
        // Close the window when OnClose event is received
        RenderWindow window = (RenderWindow)sender;
        window.Close();
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