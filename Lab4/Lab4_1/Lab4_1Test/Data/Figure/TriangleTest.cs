using Lab4_1.Data;
using Lab4_1.Data.Figure;

namespace Lab4_1Test.Data.Figure;

public class TriangleTest
{
    private const double DELTA = 0.001; // Delta value used for double comparisons

    [Test]
    public void TestGetArea()
    {
        // Arrange
        var triangle = new Triangle(new Point {X = 0, Y = 0}, new Point {X = 0, Y = 3}, new Point {X = 4, Y = 0});

        // Act
        var area = triangle.GetArea();

        // Assert
        Assert.That(area, Is.EqualTo(6).Within(DELTA));
    }

    [Test]
    public void TestGetPerimeter()
    {
        // Arrange
        var triangle = new Triangle(new Point {X = 0, Y = 0}, new Point {X = 0, Y = 3}, new Point {X = 4, Y = 0});

        // Act
        var perimeter = triangle.GetPerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(12).Within(DELTA));
    }

    [Test]
    public void TestToString()
    {
        // Arrange
        var triangle = new Triangle(new Point {X = 0, Y = 0}, new Point {X = 0, Y = 3}, new Point {X = 4, Y = 0});

        // Act
        var result = triangle.ToString();

        // Assert
        Assert.That(result, Is.EqualTo("Figure - Triangle, FirstPoint - X:0 Y:0, SecondPoint - X:0 Y:3, ThirdPoint - X:4 Y:0, OutlineColor - 0, FillColor - 0, Area - 6, Perimeter - 12"));
    }
}