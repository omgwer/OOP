using Lab4_1.Data;
using Lab4_1.Data.Figure;

namespace Lab4_1Test.Data.Figure;

public class CircleTest
{
    public class CircleTests
    {
        private readonly Point _center = new () {X = 1, Y = 1};
        private readonly double _radius = 1;
        private readonly uint _outlineColor = 0xFF0000;
        private readonly uint _fillColor = 0x00FF00;

        [Test]
        public void GetArea_ReturnsCorrectValue()
        {
            var circle = new Circle(_center, _radius);

            var result = circle.GetArea();

            Assert.That(result, Is.EqualTo(Math.PI));
        }

        [Test]
        public void GetPerimeter_ReturnsCorrectValue()
        {
            var circle = new Circle(_center, _radius);

            var result = circle.GetPerimeter();

            Assert.That(result, Is.EqualTo(2 * Math.PI));
        }

        [Test]
        public void ToString_ReturnsCorrectString()
        {
            var circle = new Circle(_center, _radius, _outlineColor, _fillColor);

            var result = circle.ToString();

            Assert.That(result,
                Is.EqualTo($"Figure - Circle, Radius - {_radius:0.00}, OutlineColor - {_outlineColor}, " +
                           $"FillColor - {_fillColor}, Area - {Math.PI:0.00}, " +
                           $"Perimeter - {2 * Math.PI:0.00}"));
        }
    }
}