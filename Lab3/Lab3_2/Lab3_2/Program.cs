using System.Diagnostics;
using System.Text;
using Lab3_2;

Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

// var startStream =
//     @"let v0=0
// let v1=1
// fn fib0=v0
// fn fib1=v1
// fn fib2=fib1+fib0
// fn fib3=fib2+fib1
// fn fib4=fib3+fib2
// fn fib5=fib4+fib3
// fn fib6=fib5+fib4
// printfns
// ";

StringBuilder stringBuilder = new StringBuilder();
int first = 2;
int second = 1;
int third = 0;

stringBuilder.Append(@"let v0=0
let v1=1
fn fib0=v0
fn fib1=v1
");

for (var i = 0; i < 50; i++, first++, second++, third++)
{
    stringBuilder.Append($"fn fib{first}=fib{second}+fib{third}\r\n");
}

stringBuilder.Append("print fib51\r\n");

var reader = new StringReader(stringBuilder.ToString());
var sw = new Stopwatch();
sw.Start();

new Calculator(reader, Console.Out).Run();

sw.Stop();
Console.WriteLine($"'time' : {sw.Elapsed}"); // Здесь логируем

