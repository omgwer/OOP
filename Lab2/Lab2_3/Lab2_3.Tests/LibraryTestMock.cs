using Lab2_3.Dictionary;
using Moq;

namespace Lab2_3.Tests;

[TestFixture]
public class LibraryTestMock
{
    private Mock<TextReader> _textReaderMock;
    private Mock<TextWriter> _textWriterMock;
    private Library _library;

    [SetUp]
    public void SetUp()
    {
        _textReaderMock = new Mock<TextReader>();
        _textWriterMock = new Mock<TextWriter>();
        _library = new Library(_textReaderMock.Object, _textWriterMock.Object);
    }

    [Test]
    public void IsRun_ReturnsTrue_WhenLibraryIsInitialized()
    {
        // Act
        var result = _library.IsRun();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void HandleInput_CallsInitializeLibrary()
    {
        // Act
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns("")
            .Returns(MessageDictionary.CLOSE_COMMAND)
            .Returns("");
        _library.HandleInput();

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.SAVE_FILE_REQUEST), Times.Once);
    }

    [Test]
    public void HandleInput_CallsCloseLibrary_WhenCloseCommandIsEntered()
    {
        // Arrange
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns("")
            .Returns("hello")
            .Returns("привет")
            .Returns("привет")
            .Returns(MessageDictionary.CLOSE_COMMAND)
            .Returns("");

        // Act
        while (_library.IsRun())
        {
            _library.HandleInput();
        }
        
        // Assert
        _textWriterMock.Verify(w => w.Write("hello"), Times.Exactly(1));
    }

    [Test]
    public void HandleInput_PrintsTranslateNotFoundMessage_WhenWordIsNotInDictionary()
    {
        // Arrange
        var wordToTranslate = "unknown";
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns(wordToTranslate)
            .Returns(string.Empty);

        // Act
        _library.HandleInput();

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetTranslateNotFoundMessage(wordToTranslate)), Times.Once);
    }

    [Test]
    public void HandleInput_AddsWordToDictionary_WhenUserEntersTranslation()
    {
        // Arrange
        var wordToTranslate = "unknown";
        var translation = "inconnu";
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns(wordToTranslate)
            .Returns(translation);

        // Act
        _library.HandleInput();

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetWordAddToLibraryMessage(wordToTranslate)), Times.Once);
    }

    [Test]
    public void HandleInput_DoesNotAddWordToDictionary_WhenUserDeclinesTranslation()
    {
        // Arrange
        var wordToTranslate = "unknown";
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns(wordToTranslate)
            .Returns(string.Empty);

        // Act
        _library.HandleInput();

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetDeclineToAddWordToDictionaryMessage(wordToTranslate)), Times.Once);
    }
}