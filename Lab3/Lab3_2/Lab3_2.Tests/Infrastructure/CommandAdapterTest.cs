using System.Globalization;
using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;

namespace Lab3_2.Tests.Infrastructure;

[TestFixture]
public class CommandAdapterTests
{
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_VAR()
    {
        // Arrange
        string value = "var";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.VAR));
    }

    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_PRINT()
    {
        // Arrange
        string value = "print";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.PRINT));
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_LET()
    {
        // Arrange
        string value = "let";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.LET));
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_FN()
    {
        // Arrange
        string value = "fn";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.FN));
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_PRINTVARS()
    {
        // Arrange
        string value = "printvars";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.PRINTVARS));
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_CommandType_PRINTFNS()
    {
        // Arrange
        string value = "printfns";

        // Act
        var result = CommandAdapter.ConvertToCommand(value);

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(CommandType.PRINTFNS));
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_TwoArgumentsAndOperation()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "test";
        var equals = "=";
        var firstVariable = "some";
        var operation = "*";
        var secondVariable = "one";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        var result = CommandAdapter.ConvertToCommand(value);
  
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.CommandType, Is.EqualTo(CommandType.VAR));
            Assert.That(result.Identifier, Is.EqualTo(identifier));
            Assert.That(result.FirstVariable, Is.EqualTo(firstVariable));
            Assert.That(result.Operation, Is.EqualTo(Operation.MULTIPLICATION));
            Assert.That(result.SecondVariable, Is.EqualTo(secondVariable));
        });
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_OnlyIdentifier()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "";
        var firstVariable = "";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        var result = CommandAdapter.ConvertToCommand(value);
  
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.CommandType, Is.EqualTo(CommandType.VAR));
            Assert.That(result.Identifier, Is.EqualTo(identifier));
            Assert.That(result.FirstVariable, Is.EqualTo(null));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.SecondVariable, Is.EqualTo(null));
        });
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_IndentifierAndDouble()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "=";
        var firstVariable = "2.33";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        var result = CommandAdapter.ConvertToCommand(value);
  
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.CommandType, Is.EqualTo(CommandType.VAR));
            Assert.That(result.Identifier, Is.EqualTo(identifier));
            Assert.That(result.FirstVariable, Is.EqualTo(firstVariable));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.SecondVariable, Is.EqualTo(null));
        });
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_IndentifierAndDouble1()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "=";
        var firstVariable = "2.33";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        var result = CommandAdapter.ConvertToCommand(value);
  
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.CommandType, Is.EqualTo(CommandType.FN));
            Assert.That(result.Identifier, Is.EqualTo(identifier));
            Assert.That(result.FirstVariable, Is.EqualTo(firstVariable));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.SecondVariable, Is.EqualTo(null));
        });
    }
    
    [Test]
    public void ConvertToCommand_Should_Return_Command_With_PRINTFNS_WITH_IDENTIFIER()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "";
        var firstVariable = "";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        var result = CommandAdapter.ConvertToCommand(value);
  
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.CommandType, Is.EqualTo(CommandType.PRINTFNS));
            Assert.That(result.Identifier, Is.EqualTo(identifier));
            Assert.That(result.FirstVariable, Is.EqualTo(null));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.SecondVariable, Is.EqualTo(null));
        });
    }
    
    [Test]
    public void Negative_ConvertToCommand_Should_Return_Command_With_Call_Function_In_Double()
    {
        // Arrange
        var command = "fn";
        var delemiter = " ";
        var identifier = "some";
        var equals = "=";
        var firstVariable = "2.33";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToCommand(value));
    }
    
    [Test]
    public void Negative_ConvertToCommand_Should_Return_Command_With_MoreAgrumentsInVar()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "=";
        var firstVariable = "2.33";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToCommand(value));
    }
    
    [Test]
    public void Negative_ConvertToCommand_Should_Return_Command_With_MoreAgrumentsInVar()
    {
        // Arrange
        var command = "var";
        var delemiter = " ";
        var identifier = "some";
        var equals = "=";
        var firstVariable = "2.33";
        var operation = "";
        var secondVariable = "";
        var value = command + delemiter + identifier + equals + firstVariable + operation + secondVariable;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToCommand(value));
    }

    [Test]
    public void ConvertToCommand_Should_Throw_Exception_For_Invalid_Command()
    {
        // Arrange
        string value = "unknown_command";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToCommand(value));
    }
    
    [Test]
    public void ConvertToCommand_Should_Throw_Exception_For_Invalid_Command_empty()
    {
        // Arrange
        string value = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToCommand(value));
    }

    [Test]
    public void IsIdentifier_Should_Return_True_For_Valid_Identifier()
    {
        // Arrange
        string value = "my_variable";

        // Act
        var result = CommandAdapter.IsIdentifier(value);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsIdentifier_Should_Return_False_For_Invalid_Identifier()
    {
        // Arrange
        string value = "123_my_variable";

        // Act
        var result = CommandAdapter.IsIdentifier(value);

        // Assert
        Assert.IsFalse(result);
    }
    
    [Test]
    public void IsIdentifier_Should_Return_False_For_Invalid_Identifier_EmptyString()
    {
        // Arrange
        string value = "";

        // Act
        var result = CommandAdapter.IsIdentifier(value);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ConvertToOperation_Should_Return_Operation_ADDITION()
    {
        // Arrange
        string value = "+";

        // Act
        var result = CommandAdapter.ConvertToOperation(value);

        // Assert
        Assert.That(result, Is.EqualTo(Operation.ADDITION));
    }
    
    [Test]
    public void ConvertToOperation_Should_Return_Operation_SUBTRACTION()
    {
        // Arrange
        string value = "-";

        // Act
        var result = CommandAdapter.ConvertToOperation(value);

        // Assert
        Assert.That(result, Is.EqualTo(Operation.SUBTRACTION));
    }
    
    [Test]
    public void ConvertToOperation_Should_Return_Operation_MULTIPLICATION()
    {
        // Arrange
        string value = "*";

        // Act
        var result = CommandAdapter.ConvertToOperation(value);

        // Assert
        Assert.That(result, Is.EqualTo(Operation.MULTIPLICATION));
    }
    
    [Test]
    public void ConvertToOperation_Should_Return_Operation_DIVISION()
    {
        // Arrange
        string value = "/";

        // Act
        var result = CommandAdapter.ConvertToOperation(value);

        // Assert
        Assert.That(result, Is.EqualTo(Operation.DIVISION));
    }

    [Test]
    public void ConvertToOperation_Should_Return_Null_For_Invalid_Operation()
    {
        // Arrange
        string value = "**";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ConvertToOperation(value));
    }
    
    [Test]
    public void ParseCommandStringAfterEqualsChar_Should_Return_Operation_ValidValueOneArgument_identifier()
    {
        // Arrange
        string value = "random_identifier";

        // Act
        var result = CommandAdapter.ParseCommandStringAfterEqualsChar(value);

        // Assert
        Assert.That(result.First(), Is.EqualTo(value));
        Assert.That(result.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void ParseCommandStringAfterEqualsChar_Should_Return_Operation_ValidValueOneArgument_double()
    {
        // Arrange
        var value = "2.3345";
        // Act
        var result = CommandAdapter.ParseCommandStringAfterEqualsChar(value);
        Assert.Multiple(() =>
        {
            Assert.That(result.First(), Is.EqualTo(value));
            Assert.That(result, Has.Count.EqualTo(1));
        });
    }
    
    [Test]
    public void ParseCommandStringAfterEqualsChar_Should_Return_Operation_ValidValueOneArgument_intValue()
    {
        // Arrange
        var value = "2";
        // Act
        var result = CommandAdapter.ParseCommandStringAfterEqualsChar(value);
        Assert.Multiple(() =>
        {
            Assert.That(result.First(), Is.EqualTo(value));
            Assert.That(result, Has.Count.EqualTo(1));
        });
    }
    
    [Test]
    public void ParseCommandStringAfterEqualsChar_Should_Return_Operation_ValidValueOneArgument_IdentifierOperationIdentifier()
    {
        // Arrange
        var firstArgument = "test";
        var secondArgument = "*";
        var thirdArgument = "some";
        var value = firstArgument + secondArgument + thirdArgument;
        // Act
        var result = CommandAdapter.ParseCommandStringAfterEqualsChar(value);
        Assert.That(result, Has.Count.EqualTo(3));
        Assert.Multiple(() =>
        {
            Assert.That(result.First(), Is.EqualTo(firstArgument));
            Assert.That(result[1], Is.EqualTo(secondArgument));
            Assert.That(result.Last(), Is.EqualTo(thirdArgument));
        });
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument()
    {
        // Arrange
        string value = "1random_identifier";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument_Float_And_Variable()
    {
        // Arrange
        string value = "2.33*indentifier";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument_Float_And_Operation()
    {
        // Arrange
        string value = "2.33*";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument_Variable_And_Operation()
    {
        // Arrange
        string value = "Abs1*";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument_OperationOnly()
    {
        // Arrange
        string value = "*";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    [Test]
    public void Negative_ParseCommandStringAfterEqualsChar_InvalidArgument_FourthArguments()
    {
        // Arrange
        string value = "some*one*";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CommandAdapter.ParseCommandStringAfterEqualsChar(value));
    }
    
    
}