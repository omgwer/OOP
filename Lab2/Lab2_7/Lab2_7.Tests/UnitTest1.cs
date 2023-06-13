namespace Lab2_7.Tests;

public class Tests
{
    [TestCase("(+ 5)", 5)]
    [TestCase("(* 5)", 5)]
    [TestCase("(* 5 2)", 10)]
    [TestCase("(* 0 2)", 0)]
    [TestCase("(* -1 2)", -2)]
    [TestCase("(+ -5 5)", 0)]
    [TestCase("(+ -5 -5)", -10)]
    [TestCase("(* -5 -5)", 25)]
    [TestCase("(+ 2 3 4)", 9)]
    [TestCase("(* 2 3 4)", 24)]
    [TestCase("(+ 5 (* 2 3 2) (+ 5 (+ 2 5) (* 2 2) ))", 33)]
    public void Test1(string value, int expectedResult)
    {
        // Arrange
        using TextReader textReader = new StringReader(value);

        // Act
        int result = Program.EvaluateExpression(textReader);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [TestCase("(+ + 5 2)")]
    [TestCase("(+ 5 2))")]
    public void NegativeTests(string value)
    {
        // Arrange
        using TextReader textReader = new StringReader(value);


        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            Program.EvaluateExpression(textReader);
        });
    }
    
    [TestCase("(+ 5.2)")]
    public void NegativeTests_ConvertNumberError(string value)
    {
        // Arrange
        using TextReader textReader = new StringReader(value);


        // Act & Assert
        Assert.Throws<FormatException>(() =>
        {
            Program.EvaluateExpression(textReader);
        });
    }
}