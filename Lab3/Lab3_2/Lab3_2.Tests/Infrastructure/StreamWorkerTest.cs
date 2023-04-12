using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;
using NUnit.Framework;

namespace Lab3_2.Tests.Infrastructure;

public class StreamWorkerTest
{
   [Test]
    public void ReadCommand_WhenCalledWithNullStream_ThrowsIOException()
    {
        var worker = new StreamWorker(null, null);
        Assert.Throws<NullReferenceException>(() => worker.ReadCommand());
    }

    [Test]
    public void ReadCommand_WhenCalledWithCloseCommand_ReturnsCloseCommand()
    {
        var reader = new StringReader("close");
        var writer = new StringWriter();
        var worker = new StreamWorker(reader, writer);

        var result = worker.ReadCommand();

        Assert.AreEqual(CommandType.CLOSE, result.CommandType);
    }

    [Test]
    public void ReadCommand_WhenCalledWithHelpCommand_ReturnsHelpCommand()
    {
        var reader = new StringReader("help");
        var writer = new StringWriter();
        var worker = new StreamWorker(reader, writer);

        var result = worker.ReadCommand();

        Assert.AreEqual(CommandType.HELP, result.CommandType);
    }


    [Test]
    public void Write_WhenCalledWithAValue_WritesValueToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.Write("hello");

        Assert.AreEqual("hello", writer.ToString());
    }

    [Test]
    public void WriteLine_WhenCalledWithAValue_WritesValueToOutputWithNewLine()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteLine("hello");

        Assert.AreEqual("hello\r\n", writer.ToString());
    }

    [Test]
    public void WriteResult_WhenCalledWithNullValue_WritesNaNToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteResult(null);

        Assert.AreEqual("nan\r\n", writer.ToString());
    }

    [Test]
    public void WriteResult_WhenCalledWithValue_WritesRoundedValueToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteResult(3.14159);

        Assert.AreEqual("3,14\r\n", writer.ToString());
    }
}