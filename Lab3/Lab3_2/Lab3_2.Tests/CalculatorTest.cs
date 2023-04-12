using System.Globalization;
using NUnit.Framework;

namespace Lab3_2.Tests;

public class CalculatorTest
{
    [SetUp]
    public void SetUp()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    }

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

        var expectedResult =
            @"Calculator is start
nan
42.00
1.23
x:99.00
y:1.23
Calculator is closed
";

        var reader = new StringReader(startStream);
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_FirstExample2()
    {
        var startStream =
            @"var x
var y
fn XPlusY=x+y
print XPlusY
let x=3
let y=4
print XPlusY
let x=10
print XPlusY
let z=3.5
fn XPlusYDivZ=XPlusY/z
printfns
";

        var expectedResult =
            @"Calculator is start
nan
7.00
14.00
XPlusY:14.00
XPlusYDivZ:4.00
Calculator is closed
";

        var reader = new StringReader(startStream);
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();

        var t = writer.ToString();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_FirstExample3() // Еще раз про различие между fn и let
    {
        var startStream =
            @"let v=42
let variable=v
fn function=v
let v=43
print variable
print function
";

        var expectedResult =
            @"Calculator is start
42.00
43.00
Calculator is closed
";

        var reader = new StringReader(startStream);
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();

        var t = writer.ToString();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }


    [Test]
    public void Calculator_FirstExample4() //Вычисление площади круга
    {
        var startStream =
            @"var radius
let pi=3.14159265
fn radiusSquared=radius*radius
fn circleArea=pi*radiusSquared
let radius=10
print circleArea
let circle10Area=circleArea
let radius=20
let circle20Area=circleArea
printfns
printvars
";

        var expectedResult =
            @"Calculator is start
314.16
circleArea:1256.64
radiusSquared:400.00
circle10Area:314.16
circle20Area:1256.64
pi:3.14
radius:20.00
Calculator is closed
";

        var reader = new StringReader(startStream);
        var writer = new StringWriter();
        new Calculator(reader, writer).Run();

        var t = writer.ToString();
        Assert.That(writer.ToString(), Is.EqualTo(expectedResult));
    }
}