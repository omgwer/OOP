using Lab2_5.Infrastructure;
using Moq;

namespace Lab2_5.Tests;

//_textWriterMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);  - проверка что в строке было "что-то"
[TestFixture]
public class HttpUrlHandlerTests
{
    private Mock<TextReader> _textReaderMock;
    private Mock<TextWriter> _textWriterMock;
    private HttpUrlHandler _httpUrlHandler;

    [SetUp]
    public void Setup()
    {
        _textReaderMock = new Mock<TextReader>();
        _textWriterMock = new Mock<TextWriter>();
        _httpUrlHandler = new HttpUrlHandler(_textReaderMock.Object, _textWriterMock.Object);
    }

    [Test]
    public void HandleInput_EmptyStream()
    {
        _textReaderMock.SetupSequence(r => r.ReadLine());

        while (_httpUrlHandler.IsRun)
        {
            _httpUrlHandler.HandleInput();
        }
        
        _textWriterMock.Verify(w => w.WriteLine("Program is run!"), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine("Program is closed"), Times.Once);
    }
    
    [Test]
    public void HandleInput_ValidUrl()
    {
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns("https://google.com")
            .Returns("http://some-one.ru:1234/file.jpg");
            

        while (_httpUrlHandler.IsRun)
        {
            _httpUrlHandler.HandleInput();
        }
        
        _textWriterMock.Verify(w => w.WriteLine("Program is run!"), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine("Program is closed"), Times.Once);
    }
}