using Lab1_5.Data;

namespace Lab1_5;

public class Fill
{
    private const int
        WIDTH = 100,
        HEIGHT = 100;
 
    private const char
        space = ' ',
        border = '#',
        start = '0',
        fillPoint = '.';

    public static CanvasInfo ReadCanvasFromStream(TextReader textReader)
    {
        var canvas = InitCanvas();
        Queue<Point> pointQueue = new();

        var i = 0;
        while (textReader.ReadLine() is { } currentString)
        {
            if (i == HEIGHT)
                break;
            
            for (var j = 0; j < currentString.Length && j < WIDTH; ++j)
            {
                if (currentString[j] == start)
                {
                    pointQueue.Enqueue(new Point { x = i, y = j });
                }

                canvas[i, j] = currentString[j];
            }

            ++i;
        }

        return new CanvasInfo
        {
            canvas = canvas,
            pointQueue = pointQueue
        };
    }

    public static char[,] FillCanvas(CanvasInfo canvasInfo)
    {
        var filledCanvas = canvasInfo.canvas;
        var coordsQueue = canvasInfo.pointQueue;

        if (coordsQueue.Count == 0)
            return filledCanvas;

        // вначале в coordsQueue находятся только точки начала заливки 
        while (coordsQueue.Count != 0)
        {
            var coords = coordsQueue.Dequeue();
            TryFillPointAndPushToQueue(coordsQueue, filledCanvas, coords);
        }

        return filledCanvas;
    }

    public static void WriteToStream(TextWriter textWriter, char[,] canvas)
    {
        for (var i = 0; i < HEIGHT; i++)
        {
            for (var j = 0; j < WIDTH; j++)
            {
                textWriter.Write(canvas[i, j]);
            }

            textWriter.WriteLine();
        }

        textWriter.Flush();
    }

    private static void TryFillPointAndPushToQueue(Queue<Point> queue, char[,] canvas, Point coords)
    {
        var i = coords.x;
        var j = coords.y;

        var _j = j - 1;
        if (_j >= 0 && IsCellEmpty(canvas, new Point { x = i, y = _j }))
        {
            queue.Enqueue(new Point { x = i, y = _j });
            canvas[i, _j] = '.';
        }

        _j = j + 1;
        if (_j < WIDTH && IsCellEmpty(canvas, new Point { x = i, y = _j }))
        {
            queue.Enqueue(new Point { x = i, y = _j });
            canvas[i, _j] = '.';
        }

        var _i = i - 1;
        if (_i >= 0 && IsCellEmpty(canvas, new Point { x = _i, y = j }))
        {
            queue.Enqueue(new Point { x = _i, y = j });
            canvas[_i, j] = '.';
        }

        _i = i + 1;
        if (_i < HEIGHT && IsCellEmpty(canvas, new Point() { x = _i, y = j }))
        {
            queue.Enqueue(new Point { x = _i, y = j });
            canvas[_i, j] = '.';
        }
    }

    private static bool IsCellEmpty(char[,] canvas, Point coords)
    {
        return canvas[coords.x, coords.y] == space;
    }

    private static char[,] InitCanvas()
    {
        var canvas = new char[HEIGHT, WIDTH];
        for (var i = 0; i < HEIGHT; i++)
        {
            for (var j = 0; j < WIDTH; j++)
            {
                canvas[i, j] = space;
            }
        }
        return canvas;
    }
}