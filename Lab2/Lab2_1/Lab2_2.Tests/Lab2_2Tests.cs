using Lab_2_2;

namespace Lab2_2.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest()
    {
        var inputValues = new Program.Command() {subject = "test", search = "tes", replace = "someone"};
        var expectedResult = "someonet";
        var result = Program.FindAndReplace(inputValues);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptyReplaceString()
    {
        var inputValues = new Program.Command() {subject = "someone", search = "me", replace = ""};
        var expectedResult = "soone";
        var result = Program.FindAndReplace(inputValues);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptyReplaceString_1()
    {
        var inputValues = new Program.Command() {subject = "a a", search = "a", replace = "a a"};
        var expectedResult = "a a a a";
        var result = Program.FindAndReplace(inputValues);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptySearchString()
    {
        var inputValues = new Program.Command() {subject = "someone", search = "", replace = "some"};
        var expectedResult = "someone";
        var result = Program.FindAndReplace(inputValues);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptySubjectString()
    {
        var inputValues = new Program.Command() {subject = "", search = "test", replace = "some"};
        var expectedResult = "";
        var result = Program.FindAndReplace(inputValues);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_NegativeTest_InvalidValue()
    {
        var inputValues = new string[] {"me"};
        var errorCode = 1;
        int result = Program.Main(inputValues);
        Assert.That(errorCode, Is.EqualTo(result));
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_NegativeTest_InvalidValue_Four_Elements()
    {
        var inputValues = new string[] {"me", "test", "some"};
        var errorCode = 1;
        int result = Program.Main(inputValues);
        Assert.That(errorCode, Is.EqualTo(result));
    }
}