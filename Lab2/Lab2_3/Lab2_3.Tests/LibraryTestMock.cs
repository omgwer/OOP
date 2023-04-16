using Lab2_3.Dictionary;
using Moq;

namespace Lab2_3.Tests;

[TestFixture]
public class LibraryTestMock
{
    private const string TEST_FILE_PATH = "test_file_mock.txt";
    private Mock<TextReader> _textReaderMock;
    private Mock<TextWriter> _textWriterMock;
    private Library _library;

    [SetUp]
    public void SetUp()
    {
        _textReaderMock = new Mock<TextReader>();
        _textWriterMock = new Mock<TextWriter>();
        _library = new Library(_textReaderMock.Object, _textWriterMock.Object);
        
        // Create a test file with some sample data
        var testData = new List<string>
        {
            "apple яблоко яблочко",
            "banana банан",
            "cherry вишня",
            "dog собака псина",
            "puppy собака щенок",
            "elephant слон",
        };
        File.WriteAllLines(TEST_FILE_PATH, testData);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Delete the test file
        File.Delete(TEST_FILE_PATH);
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
        
        while (_library.IsRun())
        {
            _library.HandleInput();
        }

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CREATE_NEW_DICTIONARY_ALERT), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE), Times.Once);
    }
    
    [Test]
    public void HandleInput_CallsInitializeLibrary_SaveToFile()
    {
        // Act
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns("")
            .Returns("cat")
            .Returns("кошка")
            .Returns(MessageDictionary.CLOSE_COMMAND)
            .Returns("Y")
            .Returns(TEST_FILE_PATH);
        
        while (_library.IsRun())
        {
            _library.HandleInput();
        }

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetTranslateNotFoundMessage("cat")), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetWordAddToLibraryMessage("cat")), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.SAVE_FILE_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITH_SAVE_MESSAGE), Times.Once);
        Assert.That(File.Exists(TEST_FILE_PATH));
    }

    [Test]
    public void HandleInput_CallsCloseLibrary_WhenCloseCommandIsEntered()
    {
        // Arrange
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns("")
            .Returns("hello")
            .Returns("привет")
            .Returns("hello")
            .Returns(MessageDictionary.CLOSE_COMMAND)
            .Returns("");

        // Act
        while (_library.IsRun())
        {
            _library.HandleInput();
        }
        
        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CREATE_NEW_DICTIONARY_ALERT), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetTranslateNotFoundMessage("hello")), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.GetWordAddToLibraryMessage("hello")), Times.Once);
        _textWriterMock.Verify(w => w.Write("привет"), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.SAVE_FILE_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE), Times.Once);
    }
    
    [Test]
    public void OpenLibraryInFileTest()
    {
        // Arrange
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns(TEST_FILE_PATH)
            .Returns("яблоко")
            .Returns("puppy")
            .Returns("собака")
            .Returns(MessageDictionary.CLOSE_COMMAND);

        // Act
        while (_library.IsRun())
        {
            _library.HandleInput();
        }

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.Write("apple"), Times.Once);
        _textWriterMock.Verify(w => w.Write("собака"), Times.Once);
        _textWriterMock.Verify(w => w.Write("щенок"), Times.Once);
        _textWriterMock.Verify(w => w.Write("dog"), Times.Once);
        _textWriterMock.Verify(w => w.Write("puppy"), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.SAVE_FILE_REQUEST), Times.Never);
    }
    
    [Test]
    public void OpenLibraryInFileTest_WithMask()
    {
        // Arrange
        _textReaderMock.SetupSequence(r => r.ReadLine())
            .Returns(TEST_FILE_PATH)
            .Returns("яБЛокО")
            .Returns("pUPpy")
            .Returns("СОбака")
            .Returns(MessageDictionary.CLOSE_COMMAND);

        // Act
        while (_library.IsRun())
        {
            _library.HandleInput();
        }

        // Assert
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.INITIALIZE_DICTIONARY_REQUEST), Times.Once);
        _textWriterMock.Verify(w => w.Write("aPPle"), Times.Once);
        _textWriterMock.Verify(w => w.Write("сОБака"), Times.Once);
        _textWriterMock.Verify(w => w.Write("щЕНок"), Times.Once);
        _textWriterMock.Verify(w => w.Write("DOg"), Times.Once);
        _textWriterMock.Verify(w => w.Write("PUppy"), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE), Times.Once);
        _textWriterMock.Verify(w => w.WriteLine(MessageDictionary.SAVE_FILE_REQUEST), Times.Never);
    }
}