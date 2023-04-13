using System.Diagnostics;
using System.Globalization;
using System.Text;
using NUnit.Framework;

namespace Lab3_2.Tests;

public class CasheCalculatorTest
{
    [Test]
    public void FibonnachiTest50_CacheOn()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        StringBuilder stringBuilder = new StringBuilder();
        int first = 2;
        int second = 1;
        int third = 0;

        stringBuilder.Append("let v0=0\r\nlet v1=1\r\nfn fib0=v0\r\nfn fib1=v1\r\n");

        for (var i = 0; i < 50; i++, first++, second++, third++)
        {
            stringBuilder.Append($"fn fib{first}=fib{second}+fib{third}\r\n");
        }

        stringBuilder.Append($"let v0=1\r\n");
        stringBuilder.Append($"print fib{second}\r\n");


        var reader = new StringReader(stringBuilder.ToString());
        var sw = new Stopwatch();
        sw.Start();

        new Calculator(reader, Console.Out, true).Run();
        
        

        sw.Stop();
        Console.WriteLine($"'time' : {sw.Elapsed}"); 
    }
}
//30 значений без кэша - 5.58
// c кэшем 0.01 