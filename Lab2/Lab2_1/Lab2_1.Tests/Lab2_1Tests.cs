using System.Diagnostics;

namespace Lab2_1.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        if (!File.Exists("TestFile.txt"))
            File.Create("TestFile.txt");
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptyString()
    {
       //  var inputValues = new StringReader("");
       //  var expectedResult = "";
       //  using var t = File.OpenText("TestFile.txt");
       //  var res = t.ReadLine();
       // // var writerTraceListener = new TextWriterTraceListener("TestFile.txt");
       //  Program.ReadStreamAndPrintResult(inputValues, writerTraceListener.Writer!);
       //  var actualResult = File.ReadAllText("TestFile.txt");
       //  t.Close();
       //  Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_OneInputString()
    {
        var inputValues = new StringReader("1.2 1.4 0.1");
        var expectedResult = "0,01 0,12 0,14";
        var writerTraceListener = new TextWriterTraceListener("TestFile.txt");
        Program.ReadStreamAndPrintResult(inputValues, writerTraceListener.Writer!);
        var actualResult = File.ReadAllText("TestFile.txt");
        writerTraceListener.Close();
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_MoreInputStrings()
    {
        // передавать массивы, не имитируем ввод с консоли
        var inputValues = new StringReader(
            @"1.2 1.3 4.3
                                2.2
                                22
                                3
                                -0.5");
        var expectedResult = "-11 -2,15 -1,5 -1,1 -0,65 -0,6 0,25";
        var result = Program.ReadNumbersAndModifyByPredicate(inputValues);
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_NegativeTest_InvalidValue()
    {
        var inputValues = new StringReader("1.2 3.x");
        var expectedResult = "";
        var isError = false;
        try
        {
            Program.ReadNumbersAndModifyByPredicate(inputValues);
        }
        catch (Exception ex)
        {
            isError = true;
        }

        Assert.True(isError);
    }
}