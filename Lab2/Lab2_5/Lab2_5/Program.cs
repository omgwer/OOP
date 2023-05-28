
using Lab2_5;
using Lab2_5.Infrastructure;

var handler = new HttpUrlHandler(Console.In, Console.Out);

while (handler.IsRun)
{
    handler.HandleInput();
}


string test = "someone";


var t = new HttpUrl(test);

Console.WriteLine("t");