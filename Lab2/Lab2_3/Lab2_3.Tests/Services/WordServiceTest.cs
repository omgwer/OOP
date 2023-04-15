using Lab2_3.Services;

namespace Lab2_3.Tests;

public class WordServiceTest
{
    [Test]
    public void IsEnglishWord_ValidWord_ReturnsTrue()
    {
        // Arrange
        string word = "hello";

        // Act
        bool result = WordService.IsEnglishWord(word);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEnglishWord_InvalidWord_ReturnsFalse()
    {
        // Arrange
        string word = "привет";

        // Act
        bool result = WordService.IsEnglishWord(word);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsRussianWord_ValidWord_ReturnsTrue()
    {
        // Arrange
        string word = "привет";

        // Act
        bool result = WordService.IsRussianWord(word);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsRussianWord_InvalidWord_ReturnsFalse()
    {
        // Arrange
        string word = "hello";

        // Act
        bool result = WordService.IsRussianWord(word);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEnglishWord_WordContainsMultipleLanguages_ThrowsArgumentException()
    {
        // Arrange
        string word = "приветhello";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => WordService.IsRussianWord(word));
    }

    [Test]
    public void IsRussianWord_WordContainsMultipleLanguages_ThrowsArgumentException()
    {
        // Arrange
        string word = "helloпривет";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => WordService.IsEnglishWord(word));
    }
}