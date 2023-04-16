using Lab4_1.Data;
using Lab4_1.Data.Figure;

namespace Lab4_1Test.Data.Figure;

public class RectangleTest
{
    private readonly Point _leftTop = new() { X = 1, Y = 1 };
    private readonly double _width = 5;
    private readonly double _height = 3;
    private readonly uint _outlineColor = 0xFF0000;
    private readonly uint _fillColor = 0x00FF00;

    [Test]
    public void ToString_ReturnsCorrectString()
    {
        var rectangle = new Rectangle(_leftTop, _width, _height, _outlineColor, _fillColor);

        var result = rectangle.ToString();

        Assert.That(result, Is.EqualTo($"Figure - Rectangle, LeftTop - {_leftTop}, Width - {_width}, Height - {_height}, " +
                        $"OutlineColor - {_outlineColor}, FillColor - {_fillColor}, Area - {rectangle.GetArea():0.00}, " +
                        $"Perimeter - {rectangle.GetPerimeter():0.00}"));
    }

    [Test]
    public void GetArea_ReturnsCorrectArea()
    {
        var rectangle = new Rectangle(_leftTop, _width, _height);

        var result = rectangle.GetArea();

        Assert.That(result, Is.EqualTo(_width * _height));
    }

    [Test]
    public void GetPerimeter_ReturnsCorrectPerimeter()
    {
        var rectangle = new Rectangle(_leftTop, _width, _height);

        var result = rectangle.GetPerimeter();

        Assert.That(result, Is.EqualTo(2 * (_width + _height)));
    }
}