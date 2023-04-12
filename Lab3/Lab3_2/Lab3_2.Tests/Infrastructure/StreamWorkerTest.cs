using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Lab3_2.Tests.Infrastructure;

public class StreamWorkerTest
{
    [SetUp]
    public void SetUp()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }

    
   [Test]
    public void ReadCommand_WhenCalledWithNullStream_ThrowsIOException()
    {
        var worker = new StreamWorker(null, null);
        Throws<NullReferenceException>(() => worker.ReadCommand());
    }

    [Test]
    public void ReadCommand_WhenCalledWithCloseCommand_ReturnsCloseCommand()
    {
        var reader = new StringReader("close");
        var writer = new StringWriter();
        var worker = new StreamWorker(reader, writer);

        var result = worker.ReadCommand();
        That(result.CommandType, Is.EqualTo(CommandType.CLOSE));
    }

    [Test]
    public void ReadCommand_WhenCalledWithHelpCommand_ReturnsHelpCommand()
    {
        var reader = new StringReader("help");
        var writer = new StringWriter();
        var worker = new StreamWorker(reader, writer);

        var result = worker.ReadCommand();

        That(result.CommandType, Is.EqualTo(CommandType.HELP));
    }


    [Test]
    public void Write_WhenCalledWithAValue_WritesValueToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.Write("hello");

        That(writer.ToString(), Is.EqualTo("hello"));
    }

    [Test]
    public void WriteLine_WhenCalledWithAValue_WritesValueToOutputWithNewLine()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteLine("hello");

        That(writer.ToString(), Is.EqualTo("hello\r\n"));
    }

    [Test]
    public void WriteResult_WhenCalledWithNullValue_WritesNaNToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteResult(null);

        That(writer.ToString(), Is.EqualTo("nan"));
    }

    [Test]
    public void WriteResult_WhenCalledWithValue_WritesRoundedValueToOutput()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteResult(3.14159);

        That(writer.ToString(), Is.EqualTo("3.14"));
    }
    
    [Test]
    public void WriteResult_WhenCalledWithValue_WritesRoundedValueToOutput_Int()
    {
        var writer = new StringWriter();
        var worker = new StreamWorker(null, writer);

        worker.WriteResult(99);

        That(writer.ToString(), Is.EqualTo("99.00"));
    }
}