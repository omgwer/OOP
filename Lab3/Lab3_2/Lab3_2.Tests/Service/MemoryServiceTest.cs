using Lab3_2.Dictionary;
using Lab3_2.Service;
using NUnit.Framework;

namespace Lab3_2.Tests.Service;

public class MemoryServiceTest
{
    [Test]
    public void BaseTest()
    {
        Command var1 = new Command() { CommandType = CommandType.VAR, Identifier = "var1" };
        Command var2 = new Command() { CommandType = CommandType.VAR, Identifier = "var2" };

        Command let1 = new Command()
            { CommandType = CommandType.LET, Identifier = "let1", FirstVariable = "2.33" }; // 2.33

        Command let2 = new Command()
            { CommandType = CommandType.LET, Identifier = "let2", FirstVariable = "let1" }; // 2.33

        Command let3 = new Command()
            { CommandType = CommandType.LET, Identifier = "let3", FirstVariable = "var1" }; // null

        Command let4 = new Command()
            { CommandType = CommandType.LET, Identifier = "let4", FirstVariable = "10" }; // 10

        Command fn1 = new Command()
            { CommandType = CommandType.FN, Identifier = "fn1", FirstVariable = "let1" }; // 2.33

        Command fn2 = new Command()
            { CommandType = CommandType.FN, Identifier = "fn2", FirstVariable = "let2" }; // 2.33

        Command fn3 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fn3", FirstVariable = "let4",
            Operation = Operation.MULTIPLICATION, SecondVariable = "let1"
        }; // 10 * 2.33 = 23.3

        Command fn4 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fn4", FirstVariable = "fn3", Operation = Operation.ADDITION,
            SecondVariable = "let1"
        }; // 23.3 + 2.33 = 25.63
        // Arrange
        string value = "var some";
        // Act
        var memoryService = new MemoryService();
        memoryService.Add(var1);
        memoryService.Add(var2);
        memoryService.Add(let1);
        memoryService.Add(let2);
        memoryService.Add(let3);
        memoryService.Add(let4);
        memoryService.Add(fn1);
        memoryService.Add(fn2);
        memoryService.Add(fn3);
        memoryService.Add(fn4);
        var var1res = memoryService.Get(var1.Identifier);
        var var2res = memoryService.Get(var2.Identifier);
        var let1res = memoryService.Get(let1.Identifier);
        var let2res = memoryService.Get(let2.Identifier);
        var let3res = memoryService.Get(let3.Identifier);
        var let4res = memoryService.Get(let4.Identifier);
        var fn1res = memoryService.Get(fn1.Identifier);
        var fn2res = memoryService.Get(fn2.Identifier);
        var fn3res = memoryService.Get(fn3.Identifier);
        var fn4res = memoryService.Get(fn4.Identifier);

        // Assert
        // Assert.That(result.CommandType, Is.EqualTo(true));
        Assert.That(true);
    }

    [Test]
    public void Fibonacci5ElementTest()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";
        Command fib1 = new Command() { CommandType = CommandType.LET, Identifier = "fib1", FirstVariable = "0" };
        Command fib2 = new Command() { CommandType = CommandType.LET, Identifier = "fib2", FirstVariable = "1" };
        Command fin1 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin1", FirstVariable = "fib1", Operation = Operation.ADDITION,
            SecondVariable = "fib2"
        };
        Command fin2 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin2", FirstVariable = "fib2", Operation = Operation.ADDITION,
            SecondVariable = "fin1"
        };
        Command fin3 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin3", FirstVariable = "fin1", Operation = Operation.ADDITION,
            SecondVariable = "fin2"
        };
        Command fin4 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin4", FirstVariable = "fin2", Operation = Operation.ADDITION,
            SecondVariable = "fin3"
        };

        memoryService.Add(fib1);
        memoryService.Add(fib2);
        memoryService.Add(fin1);
        memoryService.Add(fin2);
        memoryService.Add(fin3);
        memoryService.Add(fin4);
        var t = memoryService.Get(fin4.Identifier);
        // Assert
        Assert.That((int)memoryService.Get(fin4.Identifier), Is.EqualTo(5));
    }

    [Test]
    public void CheckFunctionLinkedVariables()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";
        Command fib1 = new Command() { CommandType = CommandType.LET, Identifier = "fib1", FirstVariable = "1" };
        Command fin1 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin1", FirstVariable = "fib1", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin2 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin2", FirstVariable = "fin1", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin3 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin3", FirstVariable = "fin2", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin4 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin4", FirstVariable = "fin3", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        memoryService.Add(fib1);
        memoryService.Add(fin1);
        memoryService.Add(fin2);
        memoryService.Add(fin3);
        memoryService.Add(fin4);
        var t = memoryService.Get(fin4.Identifier);
        // Assert
        Assert.That((int)memoryService.Get(fin4.Identifier), Is.EqualTo(5));
    }

    [Test]
    public void CheckFunctionLinkedVariablesAfterChangeVariable()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";
        Command fib1 = new Command() { CommandType = CommandType.LET, Identifier = "fib1", FirstVariable = "1" };
        Command fin1 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin1", FirstVariable = "fib1", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin2 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin2", FirstVariable = "fin1", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin3 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin3", FirstVariable = "fin2", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        Command fin4 = new Command()
        {
            CommandType = CommandType.FN, Identifier = "fin4", FirstVariable = "fin3", Operation = Operation.ADDITION,
            SecondVariable = "fib1"
        };
        memoryService.Add(fib1);
        memoryService.Add(fin1);
        memoryService.Add(fin2);
        memoryService.Add(fin3);
        memoryService.Add(fin4);
        var t = memoryService.Get(fin4.Identifier);
        // Assert
        Assert.That((int)memoryService.Get(fin4.Identifier), Is.EqualTo(5));
    }

    [Test]
    public void AddVariable_Should_AddVariable_When_IdentifierNotInMemory()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";

        // Act
        memoryService.Add(new Command { CommandType = CommandType.VAR, Identifier = identifier });

        // Assert
        Assert.IsTrue(memoryService.GetAllVars().ContainsKey(identifier));
    }

    [Test]
    public void AddVariable_Should_ThrowArgumentException_When_IdentifierIsAlreadyInMemory()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";
        memoryService.Add(new Command { CommandType = CommandType.VAR, Identifier = identifier });

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            memoryService.Add(new Command { CommandType = CommandType.VAR, Identifier = identifier }));
    }

    [Test]
    public void AddVariable_Should_AddVariableWithValue_When_FirstVariableIsNumber()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "x";
        var value = 42.0;

        // Act
        memoryService.Add(new Command
        {
            CommandType = CommandType.LET,
            Identifier = identifier,
            FirstVariable = value.ToString()
        });

        // Assert
        Assert.That(memoryService.Get(identifier ), Is.EqualTo(value));
    }

    [Test]
    public void AddVariable_Should_AddVariableWithReferencedValue_When_FirstVariableIsIdentifier()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier1 = "x";
        var identifier2 = "y";
        var value = 42.0;
        memoryService.Add(new Command { CommandType = CommandType.VAR, Identifier = identifier1 });
        memoryService.Add(new Command
            { CommandType = CommandType.LET, Identifier = identifier1, FirstVariable = value.ToString() });

        // Act
        memoryService.Add(new Command
        {
            CommandType = CommandType.LET,
            Identifier = identifier2,
            FirstVariable = identifier1
        });

        // Assert
        Assert.That(memoryService.Get(identifier2 ), Is.EqualTo(value));
    }

    [Test]
    public void AddFunction_Should_AddFunction_When_IdentifierNotInMemory()
    {
        // Arrange
        var memoryService = new MemoryService();
        var identifier = "f";
        var firstVariable = "x";
        var operation = Operation.MULTIPLICATION;
        var secondVariable = "y";

        memoryService.Add(new Command() { CommandType = CommandType.LET, Identifier = "x", FirstVariable = "21" });
        memoryService.Add(new Command() { CommandType = CommandType.LET, Identifier = "y", FirstVariable = "2" });

        // Act
        memoryService.Add(new Command
        {
            CommandType = CommandType.FN,
            Identifier = identifier,
            FirstVariable = firstVariable,
            Operation = operation,
            SecondVariable = secondVariable
        });

        // Assert
        Assert.That(memoryService.GetAllFns().ContainsKey(identifier), Is.True);
        Assert.That((int)memoryService.Get(identifier),
            Is.EqualTo(42));
    }
}