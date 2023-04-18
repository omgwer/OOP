using Lab4_1;
using Lab4_1.Core;
using Lab4_1.Core.Abstraction;
using Moq;

namespace Lab4_1Test;

public class FigureHandlerTest
{
    private Mock<TextReader> _mockTextReader;
    private Mock<TextWriter> _mockTextWriter;
    private FigureHandler _figureHandler;

    [SetUp]
    public void SetUp()
    {
        _mockTextReader = new Mock<TextReader>();
        _mockTextWriter = new Mock<TextWriter>();
        _figureHandler = new FigureHandler(_mockTextReader.Object, _mockTextWriter.Object, 100, 100);
    }

    [Test]
    public void LoadFiguresForMemory_Should_Call_CommandHandler_HandleStringCommand_Method_With_Valid_Input()
    {
        // Arrange
        var circleFirst = "circle 10 10 5";
        _mockTextReader.SetupSequence(r => r.ReadLine())
            .Returns(circleFirst);
        // Act
    //    _figureHandler.LoadFiguresForMemory();

        // Assert
        _mockTextReader.Verify(r => r.ReadLine(), Times.Exactly(2));
        _mockTextWriter.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void PrintFigureWithMinPerimeter_Should_Print_Figure_With_Min_Perimeter_To_TextWriter()
    {
        // Arrange
        var mockCircle = new Mock<IShape>();
        mockCircle.Setup(c => c.GetPerimeter()).Returns(5);
        mockCircle.Setup(c => c.ToString()).Returns("Circle: (10, 10), radius = 5");
   //     _figureHandler.LoadFiguresForMemory();
     

        // Act
        _figureHandler.PrintFigureWithMinPerimeter();

        // Assert
        _mockTextWriter.Verify(w => w.WriteLine("Figure with min perimeter:"), Times.Once);
        _mockTextWriter.Verify(w => w.WriteLine("Circle: (10, 10), radius = 5"), Times.Once);
    }

    [Test]
    public void PrintFigureWithMaxArea_Should_Print_Figure_With_Max_Area_To_TextWriter()
    {
        // Arrange
        var mockTriangle = new Mock<IShape>();
        mockTriangle.Setup(c => c.GetArea()).Returns(50);
        mockTriangle.Setup(c => c.ToString()).Returns("Triangle: (0, 0), (0, 5), (5, 0)");
    //    _figureHandler.LoadFiguresForMemory();
      

        // Act
        _figureHandler.PrintFigureWithMaxArea();

        // Assert
        _mockTextWriter.Verify(w => w.WriteLine("Figure with max area:"), Times.Once);
        _mockTextWriter.Verify(w => w.WriteLine("Triangle: (0, 0), (0, 5), (5, 0)"), Times.Once);
    }

    [Test]
    public void HandleInput_Should_Set_IsRun_Property_To_False_When_Input_Is_Close()
    {
        // Arrange
        _mockTextReader.Setup(r => r.ReadLine()).Returns("close");

        // Act
        _figureHandler.HandleInput();

        // Assert
        Assert.IsFalse(_figureHandler.IsRun());
    }
}