
using Lab2_5.Infrastructure;
using Lab6_1;

var handler = new HttpUrlHandler(Console.In, Console.Out);

while (handler.IsRun)
{
    handler.HandleInput();
}


string test = "someone";


var t = new HttpUrl(test);

Console.WriteLine("t");