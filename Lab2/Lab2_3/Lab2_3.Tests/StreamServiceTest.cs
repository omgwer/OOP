using Lab2_3.Services;

namespace Lab2_3.Tests;

public class StreamServiceTest
{
    [TestFixture]
    public class StreamServiceTests
    {
        [Test]
        public void OpenFile_FileNotFound_ThrowsException()
        {
            var streamService = new StreamService(new StringReader(""), new StringWriter());
            Assert.Throws<FileNotFoundException>(() => streamService.OpenFile("nonexistentfile.txt"));
        }

        [Test]
        public void OpenFile_FileFound_ReturnsDictionary()
        {
            // Arrange
            var path = Path.GetFullPath("testfile.txt");
            File.WriteAllText(path, "word1 translation1 translation2\nword2 translation3");
            var streamService = new StreamService(new StreamReader(path), new StringWriter());

            // Act
            var dictionary = streamService.OpenFile(path);

            // Assert
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual(new List<string> { "translation1", "translation2" }, dictionary["word1"]);
            Assert.AreEqual(new List<string> { "translation3" }, dictionary["word2"]);
        }

        [Test]
        public void OpenFile_InvalidFileContent_ThrowsException()
        {
            var path = Path.GetFullPath("testfile1.txt");
            File.WriteAllText(path, "word1\nword2");
            var streamService = new StreamService(new StreamReader(path), new StringWriter());

            Assert.Throws<Exception>(() => streamService.OpenFile(path));

           // File.Delete(path);
        }

        [Test]
        public void SaveToFile_WritesToFile()
        {
            var path = Path.GetFullPath("testfile2.txt");
            var streamService = new StreamService(new StringReader(""), Console.Out);

            var dictionary = new Dictionary<string, List<string>> {
                { "word1", new List<string> { "translation1", "translation2" } },
                { "word2", new List<string> { "translation3" } }
            };

            streamService.SaveToFile(dictionary, path);

            var lines = File.ReadAllLines(path);
            Assert.AreEqual(2, lines.Length);
            Assert.IsTrue(lines[0].StartsWith("word1"));
            Assert.IsTrue(lines[1].StartsWith("word2"));

            //File.Delete(path);
        }

        [Test]
        public void Write_WritesToStream()
        {
            var stringWriter = new StringWriter();
            var streamService = new StreamService(new StringReader(""), stringWriter);

            streamService.Write("hello");

            Assert.AreEqual("hello", stringWriter.ToString());
        }

        [Test]
        public void Read_ReadsFromStream()
        {
            var stringReader = new StringReader("hello");
            var streamService = new StreamService(stringReader, new StringWriter());

            var result = streamService.Read();

            Assert.AreEqual("hello", result);
        }

        [Test]
        public void Read_EndOfStream_ThrowsException()
        {
            var stringReader = new StringReader("");
            var streamService = new StreamService(stringReader, new StringWriter());

            Assert.Throws<Exception>(() => streamService.Read());
        }
    }
}