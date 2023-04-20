using Lab4_1.Core;
using Moq;

namespace Lab4_1Test.Core;

public class FigureHandlerTest
{
    private Mock<TextReader> _mockTextReader;
    private Mock<TextWriter> _mockTextWriter;
    private FigureHandler _figureHandler;
    private const int _canvasWidth = 800;
    private const int _canvasHeight = 600;

    [SetUp]
    public void SetUp()
    {
        _mockTextReader = new Mock<TextReader>();
        _mockTextWriter = new Mock<TextWriter>();
        _figureHandler = new FigureHandler(_mockTextReader.Object, _mockTextWriter.Object, _canvasWidth, _canvasHeight);
    }

    [Test]
    public void LoadFiguresForMemory_Should_Call_CommandHandler_HandleStringCommand_Method_With_Valid_Input()
    {
        // Arrange
        var triangleFirst = "triangle 10 10 90 20 20 90 4278190080 4278255615";
        var triangleSecond = "triangle 25 25 40 60 20 90 4278190080";
        _mockTextReader.SetupSequence(r => r.ReadLine())
            .Returns(triangleFirst)
            .Returns(triangleSecond)
            .Returns("info");


        while (_figureHandler.IsRun())
        {
            _figureHandler.HandleInput();
        }


        // Assert
        _mockTextReader.Verify(r => r.ReadLine(), Times.Exactly(2));
        _mockTextWriter.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void DrawHouse()
    {
        _mockTextReader.SetupSequence(r => r.ReadLine())
            .Returns("rectangle 0 550 800 50 4278255360 4278255360") // земля
            .Returns("rectangle 150 200 500 344 4288323071 4288323071") // дом
            .Returns("rectangle 250 50 40 90 4278190080 4278190080") // труба
            .Returns("triangle 120 200 670 200 400 50 4294901760 4294901760") //крыша
            .Returns("circle 250 5 15 4288323071 4288323071") // smoke
            .Returns("rectangle 200 445 70 100 4294967040 4294967040") // door
            .Returns("circle 410 300 70 4278255615 4278255615") // окно
            .Returns("line 405 370 555 370 4278190080") // окно
            .Returns("line 480 295 480 445 4278190080") // окно
            .Returns("circle 725 45 35 4294967040 4294967040") // sun
            .Returns("draw")
            .Returns("info");

        while (_figureHandler.IsRun())
        {
            _figureHandler.HandleInput();
        }


        // Assert
        _mockTextReader.Verify(r => r.ReadLine(), Times.Exactly(2));
        _mockTextWriter.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Never);
    }
}