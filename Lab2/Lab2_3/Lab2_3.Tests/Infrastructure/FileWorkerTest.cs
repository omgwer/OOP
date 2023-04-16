using Lab2_3.Infrastructure;

namespace Lab2_3.Tests.Infrastructure;

[TestFixture]
public class FileWorkerTests
{
    private const string TEST_FILE_PATH = "test_file.txt";

    [SetUp]
    public void SetUp()
    {
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
    public void OpenFile_FileNotFound_ThrowsException()
    {
        // Arrange
        var fileWorker = new FileWorker("nonexistent_file.txt");

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => fileWorker.OpenFile());
    }

    [Test]
    public void OpenFile_ValidFile_ReturnsExpectedDictionary()
    {
        // Arrange
        var fileWorker = new FileWorker(TEST_FILE_PATH);

        // Act
        var result = fileWorker.OpenFile();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(6));
            Assert.That(result.ContainsKey("apple"), Is.True);
            Assert.That(result["apple"], Is.EqualTo(new List<string> { "яблоко", "яблочко" }));
            Assert.IsTrue(result.ContainsKey("banana"));
            Assert.That(result["banana"], Is.EqualTo(new List<string> { "банан" }));
            Assert.IsTrue(result.ContainsKey("cherry"));
            Assert.That(result["cherry"], Is.EqualTo(new List<string> { "вишня" }));
            Assert.IsTrue(result.ContainsKey("dog"));
            Assert.That(result["dog"], Is.EqualTo(new List<string> { "собака", "псина" }));
            Assert.IsTrue(result.ContainsKey("puppy"));
            Assert.That(result["puppy"], Is.EqualTo(new List<string> { "собака", "щенок" }));
            Assert.IsTrue(result.ContainsKey("elephant"));
            Assert.That(result["elephant"], Is.EqualTo(new List<string> { "слон" }));
        });
    }

    [Test]
    public void SaveToFile_ValidDictionary_WritesToFile()
    {
        // Arrange
        var fileWorker = new FileWorker(TEST_FILE_PATH);
        var dictionary = new Dictionary<string, List<string>>
        {
            { "fish", new List<string> { "рыба", "рыбка" } },
            { "bird", new List<string> { "птица", "птичка", "птичонка" } }
        };

        // Act
        fileWorker.SaveToFile(dictionary);
        var result = File.ReadAllLines(TEST_FILE_PATH);

        // Assert
        Assert.That(result.Length, Is.EqualTo(2));
        Assert.IsTrue(result[0].StartsWith("fish "));
        Assert.IsTrue(result[0].Contains("рыба"));
        Assert.IsTrue(result[0].Contains("рыбка"));
        Assert.IsTrue(result[1].StartsWith("bird "));
        Assert.IsTrue(result[1].Contains("птица"));
        Assert.IsTrue(result[1].Contains("птичка"));
        Assert.IsTrue(result[1].Contains("птичонка"));
    }
}