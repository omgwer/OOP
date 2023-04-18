using Lab4_1.Core;

var figureHandler = new FigureHandler(Console.In, Console.Out, 800, 600);

figureHandler.LoadFiguresForMemory();
figureHandler.PrintFigureWithMaxArea();
figureHandler.PrintFigureWithMinPerimeter();

while (figureHandler.IsRun())
{
    figureHandler.HandleInput();
}