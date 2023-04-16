


using Lab4_1;

var figureHandler = new FigureHandler(Console.In, Console.Out, 800, 600);

figureHandler.LoadFiguresForMemory();

while (figureHandler.IsRun())
{
    figureHandler.HandleInput();
}
    