using Lab1_5.Data;

namespace Lab1_5;

public class Fill
{
    private const int
        WIDTH = 100,
        HEIGHT = 100;

    private char[,] _canvas = new char[HEIGHT, WIDTH];
    private Queue<Point> _pointQueue = new ();

    private const char
        space = ' ',
        border = '#',
        start = '0',
        fillPoint = '.';

    public Fill() {
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
            for (var j =0; j < currentString.Length && j < WIDTH; ++j)
            {
                if (currentString[j] == start)
                {
                    _pointQueue.Enqueue(new Point{x = i, y = j});
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
}