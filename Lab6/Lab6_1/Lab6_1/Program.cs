using Lab6_1;
using Lab6_1.Infrastructure;

var handler = new HttpUrlHandler(Console.In, Console.Out);

while (handler.IsRun)
{
    handler.HandleInput();
}


string test = "someone";


var t = new HttpUrl(test);

Console.WriteLine("t");