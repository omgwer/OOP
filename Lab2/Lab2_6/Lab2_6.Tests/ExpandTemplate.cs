namespace Lab2_6.Tests;

public class Tests
{
    // Файлы лежат в \OOP\Lab2\Lab2_6\Lab2_6.Tests\bin\Debug\net7.0
    
    [SetUp]
    public void Setup()
    {
        if (!File.Exists("inTest1.txt"))
        {
            File.Create("inTest1.txt");
            using var sr = new StreamWriter("inTest1.txt");
            sr.WriteLine("-AABBCCCCCABC+");
        }
        
        if (!File.Exists("inTestEmptyParamsList.txt"))
        {
            File.Create("inTestEmptyParamsList.txt");
            using var sr = new StreamWriter("inTestEmptyParamsList.txt");
            sr.WriteLine("someone");
        }
        
            
        if (!File.Exists("inEmptyFile.txt"))
        {
            File.Create("inEmptyFile.txt");
            using var sr = new StreamWriter("inEmptyFile.txt");
            sr.WriteLine();
        }

        if (!File.Exists("inReadyToTest.txt"))
        {
            File.Create("inReadyToTest.txt");
            using var sr = new StreamWriter("inReadyToTest.txt");
            sr.WriteLine();
        }
    }
    
    [Test]
    public void FullProgramTest()
    {
        string inputFileName = "inTest1.txt";
        string outputFileName = "outTest1.txt";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        testArr.Add("A");
        testArr.Add("[a]");
        testArr.Add("AA");
        testArr.Add("[aa]");
        testArr.Add("B");
        testArr.Add("[b]");
        testArr.Add("BB");
        testArr.Add("[bb]");
        testArr.Add("C");
        testArr.Add("[c]");
        testArr.Add("CC");
        testArr.Add("[cc]");
        Program.Main(testArr.ToArray());
        using StreamReader streamReader = new StreamReader(outputFileName);
        Assert.That(streamReader.ReadLine(), Is.EqualTo("-[aa][bb][cc][cc][c][a][b][c]+"));
    }
    
    [Test]
    public void EmptyParamsList()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Program.Main(Array.Empty<string>());
        });
    }
    
    [Test]
    public void InvalidInputFile()
    {
        string inputFileName = "inTestEmptyParamsList";
        string outputFileName = "outTestEmptyParamsList.txt";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        Assert.Throws<ArgumentException>(() =>
        {
            Program.Main(testArr.ToArray());
        });
    }
    
    [Test]
    public void InvalidOutputFile()
    {
        string inputFileName = "inTestEmptyParamsList.txt";
        string outputFileName = "outTestEmptyParamsList";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        Assert.Throws<ArgumentException>(() =>
        {
            Program.Main(testArr.ToArray());
        });
    }
    
    [Test]
    public void EmptyInputFile()
    {
        string inputFileName = "inEmptyFile.txt";
        string outputFileName = "outEmptyFile.txt";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        Program.Main(testArr.ToArray());
        using StreamReader streamReaderOut = new StreamReader(outputFileName);
        using StreamReader streamReaderIn = new StreamReader(inputFileName);
        Assert.That(streamReaderOut.ReadLine(), Is.EqualTo(streamReaderIn.ReadLine()));
    }

    
    [Test]
    public void EmptyDictionaryParamsList()
    {
        string inputFileName = "inTestEmptyParamsList.txt";
        string outputFileName = "outTestEmptyParamsList.txt";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        Program.Main(testArr.ToArray());
        using StreamReader streamReaderOut = new StreamReader(outputFileName);
        using StreamReader streamReaderIn = new StreamReader(inputFileName);
        Assert.That(streamReaderOut.ReadLine(), Is.EqualTo(streamReaderIn.ReadLine()));
    }
    
    [Test]
    public void ReadyToTestValue()
    {
        string inputFileName = "inReadyToTest.txt";
        string outputFileName = "outReadyToTest.txt";
        List<string> testArr = new();
        testArr.Add(inputFileName);
        testArr.Add(outputFileName);
        testArr.Add("%USER_NAME%");
        testArr.Add("Super %USER_NAME% {WEEK_DAY}");
        testArr.Add("{WEEK_DAY}");
        testArr.Add("Friday. {WEEK_DAY}");

        Program.Main(testArr.ToArray());
        string expectedValue = "Hello, Super %USER_NAME% {WEEK_DAY}. Today is Friday. {WEEK_DAY}.";
        using StreamReader streamReaderOut = new StreamReader(outputFileName);
        Assert.That(streamReaderOut.ReadLine(), Is.EqualTo(expectedValue));
    }
}