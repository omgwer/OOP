namespace Lab4_1.Data;

public class Point
{
    private double _x;
    private double _y;
    public double X {
        get => _x;
        set
        {
            if (value < 0)
                throw new ArgumentException("Point coordinates can`t be < 0");
            _x = value;
        }
    }
    public double Y
    {
        get => _y;
        set
        {
            if (value < 0)
                throw new ArgumentException("Point coordinates can`t be < 0");
            _y = value;
        }
    }
}