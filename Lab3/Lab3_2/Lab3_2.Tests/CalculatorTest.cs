using NUnit.Framework;

namespace Lab3_2.Tests;

public class CalculatorTest
{
    [Test]
    public void CalculatorPrintHelp()
    {
        var expectedResult =
            @"Calculator is start
Commands list: 
   var {identifier} 
   let {identifier} = {float} 
   let {identifier} = {identifier} 
   fn {identifier} = {identifier}
   fn {identifier} = {identifier}{operation}{identifier}
   print {identifier}
   printvars
   printfns
Calculator is closed
";
        var reader = new StringReader("help");
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void CalculatorStartAndClose()
    {
        var expectedResult =
            @"Calculator is start
Calculator is closed
";
        var reader = new StringReader("close");
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void Calculator_FirstExample()
    {
        var expectedResult =
            @"Calculator is start
nan
42
1,23
x:99
y:1,23
Calculator is closed
";
        var startStream =
            @"var x
print x
let x=42
print x
let x=1.234
print x
let y=x
let x=99
printvars
";
        var reader = new StringReader(startStream);
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();

        var t = writer.ToString();

        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }
}