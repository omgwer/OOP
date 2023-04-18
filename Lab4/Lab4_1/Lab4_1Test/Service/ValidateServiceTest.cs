using Lab4_1.Service;

namespace Lab4_1Test.Service;

public class ValidateServiceTest
{
    private ValidateService validateService;

    [SetUp]
    public void SetUp()
    {
        validateService = new ValidateService(100, 100);
    }

    [Test]
    public void ConvertToPoint_Should_ReturnCorrectPoint()
    {
        var point = validateService.ConvertToPoint("10", "20");
        Assert.That(point.X, Is.EqualTo(10));
        Assert.That(point.Y, Is.EqualTo(20));
    }
    
    
    [Test]
    public void ConvertToPoint_Should_ReturnInCorrectPoint()
    {
        Assert.Throws<ArgumentException>(() => validateService.ConvertToPoint("-10", "0"));
    }

    [Test]
    public void ConvertStringToPointValue_Should_ReturnCorrectValue()
    {
        var value = validateService.ConvertStringToPointValue("10");
        Assert.That(value, Is.EqualTo(10));
    }

    [Test]
    public void ConvertStringToPointValue_Should_ThrowArgumentException_When_ValueIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => validateService.ConvertStringToPointValue("-10"));
    }

    [Test]
    public void ConvertToColor_Should_ReturnCorrectColor()
    {
        var color = validateService.ConvertToColor("123456");
        Assert.That(color, Is.EqualTo((uint)123456));
    }

    [Test]
    public void ConvertToColor_Should_ThrowArgumentException_When_ValueIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => validateService.ConvertToColor("not_a_color"));
    }

    [Test]
    public void AssertArgumentCountForFigure_Should_NotThrowException_When_CountIsInRange()
    {
        Assert.DoesNotThrow(() => validateService.AssertArgumentCountForFigure(5));
    }

    [Test]
    public void AssertArgumentCountForFigure_Should_ThrowArgumentException_When_CountIsBelowMin()
    {
        Assert.Throws<ArgumentException>(() => validateService.AssertArgumentCountForFigure(3));
    }

    [Test]
    public void AssertArgumentCountForFigure_Should_ThrowArgumentException_When_CountIsAboveMax()
    {
        Assert.Throws<ArgumentException>(() => validateService.AssertArgumentCountForFigure(10));
    }
}