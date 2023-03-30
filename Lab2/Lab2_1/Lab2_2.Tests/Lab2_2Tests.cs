
using Lab_2_2;

namespace Lab2_2.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_PositiveTest_EmptyString()
    {
        var inputValues = new Program.Command(){ subject = "someone", search = "me", replace = ""};
        var expectedResult = "soone";
        var result = Program.FindAndReplace(inputValues);
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void ReadNumbersAndModifyByPredicate_NegativeTest_InvalidValue()
    {
        // var inputValues = new StringReader("1.2 3.x");
        // var expectedResult = "";
        // var isError = false;
        // try
        // {
        //     Program.ReadNumbersAndModifyByPredicate(inputValues);
        // }
        // catch (Exception ex)
        // {
        //     isError = true;
        // }
        //
        // Assert.True(isError);
    }
}