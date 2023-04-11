using Lab3_2.Infrastructure;
using Lab3_2.Service;
using NUnit.Framework;

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
    public void ConvertToCommand_Should_Return_Command_With_CommandType_VAR()
    {
        // Arrange
        string value = "var some";

        // Act
        var result = new MemoryService();

        // Assert
        Assert.That(result.CommandType, Is.EqualTo(true));
    }
}