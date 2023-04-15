using Lab2_3.Services;

namespace Lab2_3.Tests.Services;

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
    
    [Test]
    public void Convert_RussianWord_ToMask_MaskEqualLenghtToWord()
    {
        // Arrange
        var word = "hello";
        bool[] mask = {true,false, true, true, false};

        // Act
        var result = WordService.ConvertStringByMask(word, mask);

        // Assert
        Assert.That(result, Is.EqualTo("HeLLo"));
    }
    
    [Test]
    public void Convert_EnglishWord_ToMask_MaskEqualLenghtToWord()
    {
        // Arrange
        var word = "привет";
        bool[] mask = {true,false, true, true, false, true};

        // Act
        var result = WordService.ConvertStringByMask(word, mask);

        // Assert
        Assert.That(result, Is.EqualTo("ПрИВеТ"));
    }
    
    [Test]
    public void Convert_RussianWord_ToMask_MaskIsShortedThatTheWord()
    {
        // Arrange
        var word = "Барсик";
        bool[] mask = {false,true, true, true};

        // Act
        var result = WordService.ConvertStringByMask(word, mask);

        // Assert
        Assert.That(result, Is.EqualTo("бАРСик"));
    }
    
    [Test]
    public void GetWordMask_GetMaskEnglishWord()
    {
        // Arrange
        var word = "HeLLo";
        bool[] expectedResult = {true,false, true, true, false};

        // Act
        var result = WordService.GetWordMask(word);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void GetWordMask_GetMaskRussianWord()
    {
        // Arrange
        var word = "кОТОфЕй";
        bool[] expectedResult = {false, true, true,true, false, true, false};

        // Act
        var result = WordService.GetWordMask(word);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}