using Lab6_1.Infrastructure;

var handler = new HttpUrlHandler(Console.In, Console.Out);

while (handler.IsRun)
{
    handler.HandleInput();
}