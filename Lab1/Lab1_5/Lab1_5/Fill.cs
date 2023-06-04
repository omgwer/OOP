using Lab1_5.Data;

namespace Lab1_5;

public class Fill
{
    private const int
        WIDTH = 100,
        HEIGHT = 100;

    private char[,] _canvas = new char[HEIGHT, WIDTH];
    private Queue<Point> _pointQueue = new();

    private const char
        space = ' ',
        border = '#',
        start = '0',
        fillPoint = '.';

    public Fill()
    {
        for (var i = 0; i < HEIGHT; i++)
        {
            for (var j = 0; j < WIDTH; j++)
            {
                _canvas[i, j] = space;
            }
        }
    }

    public CanvasInfo ReadCanvasFromStream(TextReader textReader)
    {
        var i = 0;
        while (textReader.ReadLine() is { } currentString)
        {
            for (var j = 0; j < currentString.Length && j < WIDTH; ++j)
            {
                if (currentString[j] == start)
                {
                    _pointQueue.Enqueue(new Point { x = i, y = j });
                    continue;
                }

                _canvas[i, j] = currentString[j];
            }

            if (i == HEIGHT)
                break;

            ++i;
        }

        var canvasInfo = new CanvasInfo
        {
            canvas = _canvas,
            pointQueue = _pointQueue
        };
        return canvasInfo;
    }

    public bool IsCellEmpty(Point coords)
    {
        return _canvas[coords.x, coords.y] == space;
    }

    public char[,] FillCanvas(CanvasInfo canvasInfo)
    {
        var filledCanvas = canvasInfo.canvas;
        var coordsQueue = canvasInfo.pointQueue;

        if (coordsQueue.Count == 0)
            return filledCanvas;

        while (coordsQueue.Count != 0)
        {
            Point coords = coordsQueue.Dequeue();
            CheckNeighboursWithFillingAndPushingToQueue(coordsQueue, filledCanvas, coords);
        }
        return filledCanvas;
    }
    
    void CheckNeighboursWithFillingAndPushingToQueue(Queue<Point> queue, char[,] canvas, Point coords)
    {
        var i = coords.x;
        var j = coords.y;

        int _j = j - 1;
        if (_j >= 0 && IsCellEmpty( new Point {x = i, y = _j} ))
        {
            queue.Enqueue(new Point {x = i, y = _j});
            canvas[i][_j] = '.';
        }

        _j = j + 1;
        if (_j < canvas_width && IsCellEmpty(canvas, { i, _j }))
        {
            queue.push(std::pair(i, _j));
            canvas[i][_j] = '.';
        }

        int _i = i - 1;
        if (_i >= 0 && IsCellEmpty(canvas, { _i, j }))
        {
            queue.push(std::pair(_i, j));
            canvas[_i][j] = '.';
        }

        _i = i + 1;
        if (_i < canvas_height && IsCellEmpty(canvas, { _i, j }))
        {
            queue.push(std::pair(_i, j));
            canvas[_i][j] = '.';
        }
    }
    
    public void WriteToStream(TextWriter textWriter)
    {
        for (var i = 0; i < HEIGHT; i++)
        {
            for (var j = 0; j < WIDTH; j++)
            {
                textWriter.Write(_canvas[i,j]);
            }
            textWriter.WriteLine();
        }
        textWriter.Flush();
    }
}