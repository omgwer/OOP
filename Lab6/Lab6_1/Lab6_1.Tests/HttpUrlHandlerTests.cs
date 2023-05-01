using Lab6_1.Infrastructure;

namespace Lab6_1.Tests;

[TestFixture]
public class HttpUrlHandlerTests
{
    private StringReader _stringReader;
    private StringWriter _stringWriter;
    private HttpUrlHandler _httpUrlHandler;

    [SetUp]
    public void Setup()
    {
        _stringReader = new StringReader("http://www.example.com");
        _stringWriter = new StringWriter();
        _httpUrlHandler = new HttpUrlHandler(_stringReader, _stringWriter);
    }

    [Test]
    public void HandleInput_ShouldWriteParsedUrl_WhenInputIsValid()
    {
        // Arrange
        var expectedOutput = "http://www.example.com/\r\n";

        // Act
        _httpUrlHandler.HandleInput();

        // Assert
        Assert.That(_stringWriter.ToString(), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void HandleInput_ShouldWriteError_WhenInputIsInvalid()
    {
        // Arrange
        _stringReader = new StringReader("invalid url");
        _httpUrlHandler = new HttpUrlHandler(_stringReader, _stringWriter);
        var expectedOutput = "Cant convert this string - invalid url. Errors :Invalid scheme.\r\n";

        // Act
        _httpUrlHandler.HandleInput();

        // Assert
        Assert.That(_stringWriter.ToString(), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void HandleInput_ShouldSetIsRunToFalse_WhenInputIsNull()
    {
        // Arrange
        _stringReader = new StringReader("");
        _httpUrlHandler = new HttpUrlHandler(_stringReader, _stringWriter);

        // Act
        _httpUrlHandler.HandleInput();

        // Assert
        Assert.That(_httpUrlHandler.IsRun, Is.False);
    }

    [Test]
    public void HandleInput_ShouldThrowException_WhenUnhandledExceptionOccurs()
    {
        // Arrange
        _stringReader = new StringReader("http://www.example.com");
        _httpUrlHandler = new HttpUrlHandler(_stringReader, _stringWriter);
        var exceptionMessage = "Unhandled exception occurred";
        var expectedException = new Exception("Runtime error" + exceptionMessage);

        // Act & Assert
        Assert.That(() =>
        {
            _httpUrlHandler.HandleInput();
            throw new Exception(exceptionMessage);
        }, Throws.Exception.EqualTo(expectedException));
    }
}