using Lab4_1.Data;
using Lab4_1.Data.Figure;

namespace Lab4_1Test.Data.Figure;

public class LineTest
{
    private readonly Point _startPoint = new Point(){X = 1, Y = 1};
    private readonly Point _finishPoint = new() {X = 1, Y = 1};
    private readonly uint _outlineColor = 0xFF0000;

    [Test]
    public void ToString_ReturnsCorrectString()
    {
        var line = new Line(_startPoint, _finishPoint, _outlineColor);

        var result = line.ToString();

        Assert.That(result, Is.EqualTo($"Figure - Line, StartPoint - {_startPoint}, FinishPoint - {_finishPoint}, " +
                        $"OutlineColor - {_outlineColor}, Area - 0, Perimeter - 0"));
    }
}