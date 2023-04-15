using Lab2_3.Dictionary;

namespace Lab2_3.Tests.Dictionary;

public class MessageDictionaryTest
{
    [Test]
    public void GetTranslateNotFoundMessage_ShouldReplaceWordInMessage()
    {
        // Arrange
        string word = "apple";
        string expectedMessage = $"Translate for this word - {word} not found. Input translated word for add to dictionary or empty string for cancel";

        // Act
        string actualMessage = MessageDictionary.GetTranslateNotFoundMessage(word);

        // Assert
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void GetDeclineToAddWordToDictionaryMessage_ShouldReplaceWordInMessage()
    {
        // Arrange
        string word = "banana";
        string expectedMessage = $"Word {word} ignored";

        // Act
        string actualMessage = MessageDictionary.GetDeclineToAddWordToDictionaryMessage(word);

        // Assert
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void GetWordAddToLibraryMessage_ShouldReplaceWordInMessage()
    {
        // Arrange
        string word = "cherry";
        string expectedMessage = $"Word - {word} added for a dictionary";

        // Act
        string actualMessage = MessageDictionary.GetWordAddToLibraryMessage(word);

        // Assert
        Assert.AreEqual(expectedMessage, actualMessage);
    }
}