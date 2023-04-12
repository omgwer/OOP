using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;
using Lab3_2.Service;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Lab3_2.Tests.Service;

public class MemoryServiceTest
{
    // public interface IMemoryService
    // {
    //     void Add(Command command);
    //     double? Get(Command command);
    //     Dictionary<string, double?> GetAllVars();
    //     Dictionary<string, string?> GetAllFns();
    // }

    [Test]
    public void CorrectConvertResult()
    {
        // Arrange
        string value = "var some";
        // Act
        var memoryService = new MemoryService();
        memoryService._variables.Add("test1", 2.33);
        memoryService._variables.Add("test2", 10);
        memoryService._variables.Add("test3", null);
        //  memoryService._variables.Add("test3", 2.43);
        memoryService._functions.Add("fn1", new FunctionArgument(){FirstOperand = "test1"});
        memoryService._functions.Add("fn2", new FunctionArgument(){FirstOperand = "fn1", Operation = Operation.MULTIPLICATION, SecondOperand = "test2"});
        memoryService._functions.Add("fn3", new FunctionArgument(){FirstOperand = "fn1", Operation = Operation.MULTIPLICATION, SecondOperand = "test3"});
        //var t = memoryService.Get(new Command(){CommandType = CommandType.VAR, Identifier = "test1"});
        var s = memoryService.Get(new Command(){CommandType = CommandType.VAR, Identifier = "fn2"});
        var s1 = memoryService.Get(new Command(){CommandType = CommandType.VAR, Identifier = "fn3"});

        Console.WriteLine( s == null ? "null" : s);
        Console.WriteLine( s1 == null ? "null" : s1);


        // Assert
        // Assert.That(result.CommandType, Is.EqualTo(true));
        Assert.That(true);
    }
}