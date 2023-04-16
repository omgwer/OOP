using Lab4_1;
using Lab4_1.Data;
using Lab4_1.Data.Figure;
using Lab4_1.Service;

namespace Lab4_1Test.Service;

public class CommandHandlerTest
{
    private ValidateService _validateService;

    [SetUp]
    public void Setup()
    {
        _validateService = new ValidateService(500,500);
    }

    [Test]
    public void HandleStringCommand_AddsLineToList()
    {
        // Arrange
        var shapes = new List<IShape>();
        var commandHandler = new CommandHandler(shapes, _validateService);
        string value = "line 0 0 100 100";

        // Act
        commandHandler.HandleStringCommand(value);

        // Assert
        Assert.That(shapes.Count, Is.EqualTo(1));
        Assert.IsTrue(shapes[0] is Line);
       
        
        Assert.That(((Line)shapes[0]).StartPoint.ToString(), Is.EqualTo(new Point() { X = 0, Y = 0 }.ToString()));
        Assert.That(((Line)shapes[0]).FinishPoint.ToString(), Is.EqualTo(new Point(){X = 100, Y = 100}.ToString()));
    }

    [Test]
    public void HandleStringCommand_AddsCircleToList()
    {
        // Arrange
        var shapes = new List<IShape>();
        var commandHandler = new CommandHandler(shapes, _validateService);
        string value = "circle 50 50 25";

        // Act
        commandHandler.HandleStringCommand(value);

        // Assert
        Assert.That(shapes.Count, Is.EqualTo(1));
        Assert.IsTrue(shapes[0] is Circle);
        Assert.That(((Circle)shapes[0]).Center.ToString(), Is.EqualTo(new Point(){X = 50, Y = 50}.ToString()));
        Assert.That(((Circle)shapes[0]).Radius, Is.EqualTo(25));
    }

    [Test]
    public void HandleStringCommand_ThrowsArgumentOutOfRangeException_ForInvalidFigureType()
    {
        // Arrange
        var shapes = new List<IShape>();
        var commandHandler = new CommandHandler(shapes, _validateService);
        string value = "invalidFigureType";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => commandHandler.HandleStringCommand(value));
    }
}