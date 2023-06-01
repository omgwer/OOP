namespace Lab2_6.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        string inputFileName = "in.txt";
        string outputFileName = "out.txt";
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
        var kek = testArr.ToArray();
        var t = Program.Main(testArr.ToArray());
    }
}