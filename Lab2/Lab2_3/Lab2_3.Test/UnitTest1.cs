namespace Lab2_3.Tests
{
    [TestFixture]
    public class MiniDictionaryTests
    {
        private IMini _miniDictionary;

        [SetUp]
        public void Setup()
        {
            _miniDictionary = new MiniDictionary();
        }

        [Test]
        public void SetDictionary_SetsDictionary()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "hello", new List<string>() { "hola", "bonjour" } },
                { "goodbye", new List<string>() { "adios", "au revoir" } }
            };

            // Act
            _miniDictionary.SetDictionary(dictionary);

            // Assert
            Assert.AreEqual(dictionary, _miniDictionary.GetDictionary());
        }

        [Test]
        public void GetDictionary_ReturnsDictionary()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "hello", new List<string>() { "hola", "bonjour" } },
                { "goodbye", new List<string>() { "adios", "au revoir" } }
            };

            _miniDictionary.SetDictionary(dictionary);

            // Act
            Dictionary<string, List<string>> result = _miniDictionary.GetDictionary();

            // Assert
            Assert.AreEqual(dictionary, result);
        }

        [Test]
        public void TranslateWord_ReturnsTranslation()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "hello", new List<string>() { "hola", "bonjour" } },
                { "goodbye", new List<string>() { "adios", "au revoir" } }
            };

            _miniDictionary.SetDictionary(dictionary);

            // Act
            List<string>? result = _miniDictionary.TranslateWord("hello");

            // Assert
            Assert.AreEqual(new List<string>() { "hola", "bonjour" }, result);
        }

        [Test]
        public void TranslateWord_ReturnsNullWhenWordNotInDictionary()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "hello", new List<string>() { "hola", "bonjour" } },
                { "goodbye", new List<string>() { "adios", "au revoir" } }
            };

            _miniDictionary.SetDictionary(dictionary);

            // Act
            List<string>? result = _miniDictionary.TranslateWord("world");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddWord_AddsNewWord()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "hello", new List<string>() { "hola", "bonjour" } },
                { "goodbye", new List<string>() { "adios", "au revoir" } }
            };

            _miniDictionary.SetDictionary(dictionary);

            // Act
            _miniDictionary.AddWord("thanks", "gracias");

            // Assert
            Assert.IsTrue(_miniDictionary.GetDictionary().ContainsKey("thanks"));
            Assert.AreEqual(new List<string>() { "gracias" }, _miniDictionary.TranslateWord("thanks"));
        }

        [Test]
        public void AddWord_AddsTranslationToExistingWord()
        {
            // Arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
                {
                    { "hello", new List<string>() { "hola", "bonjour" } },
                    { "goodbye", new List<string>() { "adios", "au revoir" } }

                    _miniDictionary.SetDictionary(dictionary);

                    // Act
                    _miniDictionary.AddWord("hello", "salut");

                    // Assert
                    Assert.AreEqual(new List<string>() {"hola", "bonjour", "salut"
                },
                _miniDictionary.TranslateWord("hello"));
            }
        }
    }
}