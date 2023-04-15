namespace Lab2_3.Tests.Services;

public class DictionaryTest
{
    private Lab2_3.Services.Dictionary _dictionary;

    [SetUp]
    public void Setup()
    {
        _dictionary = new Lab2_3.Services.Dictionary();
    }

    [Test]
    public void SetDictionary_ValidDictionary_DictionarySet()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("hello", new List<string>() { "привет" });

        // Act
        _dictionary.SetDictionary(dictionary);

        // Assert
        Assert.That(_dictionary.GetDictionary(), Is.EqualTo(dictionary));
    }

    [Test]
    public void SetDictionary_NullDictionary_DictionaryNotSet()
    {
        // Act & Assert
        Assert.Throws<NullReferenceException>(() => _dictionary.SetDictionary(null));
    }

    [Test]
    public void TranslateWord_ExistingEnglishWord_ReturnsCorrectTranslation()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("hello", new List<string>() { "привет" });
        _dictionary.SetDictionary(dictionary);

        // Act
        var translation = _dictionary.TranslateWord("hello");

        // Assert
        Assert.That(translation, Is.Not.Null);
        Assert.That(translation.Count, Is.EqualTo(1));
        Assert.That(translation[0], Is.EqualTo("привет"));
    }

    [Test]
    public void TranslateWord_ExistingRussianWord_ReturnsCorrectTranslation()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("hello", new List<string>() { "привет" });
        _dictionary.SetDictionary(dictionary);

        // Act
        var translation = _dictionary.TranslateWord("привет");

        // Assert
        Assert.That(translation, Is.Not.Null);
        Assert.That(translation.Count, Is.EqualTo(1));
        Assert.That(translation[0], Is.EqualTo("hello"));
    }

    [Test]
    public void TranslateWord_NonExistingWord_ReturnsNull()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("hello", new List<string>() { "привет" });
        _dictionary.SetDictionary(dictionary);

        // Act
        var translation = _dictionary.TranslateWord("goodbye");

        // Assert
        Assert.That(translation, Is.Null);
    }

    [Test]
    public void AddWord_NewWordAndTranslation_AddedToDictionary()
    {
        // Act
        _dictionary.AddWord("hello", "привет");

        // Assert
        Assert.That(_dictionary.GetDictionary().ContainsKey("hello"), Is.True);
        Assert.That(_dictionary.GetDictionary()["hello"].Count, Is.EqualTo(1));
        Assert.That(_dictionary.GetDictionary()["hello"][0], Is.EqualTo("привет"));
    }

    [Test]
    public void AddWord_ExistingWordAndTranslation_NotAddedToDictionary()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("hello", new List<string>() { "привет" });
        _dictionary.SetDictionary(dictionary);
        var initialDictionary = _dictionary.GetDictionary();

        // Assert
        Assert.Throws<ArgumentException>(() => _dictionary.AddWord("hello", "здравствуйте"));
    }

    [Test]
    public void TranslateWord_Miltiply()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        dictionary.Add("cat", new List<string>() { "кошка", "ефим", "барсик" });
        dictionary.Add("kitty", new List<string>() { "кошка", "ефим", "барсик", "стеша" });
        dictionary.Add("bestcat", new List<string>() { "стеша" });
        _dictionary.SetDictionary(dictionary);
        var initialDictionary = _dictionary.GetDictionary();
        
        var result = _dictionary.TranslateWord("стеша");

        // Assert
        Assert.That(result![0], Is.EqualTo("kitty"));
        Assert.That(result![1], Is.EqualTo("bestcat"));
    }
}