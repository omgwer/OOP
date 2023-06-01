namespace Lab2_7.Tests;

public class Tests
{
    [TestCase("(+ 5)", 5)]
    public void Test1(string value, int expectedResult)
    {
        // Arrange
        string expression = "5";
        using TextReader textReader = new StringReader(expression);

        // Act
        int result = ProgramSome.EvaluateExpression(textReader);

        // Assert
        //    Assert.That(result, Is.EqualTo(expectedResult));
    }
}
