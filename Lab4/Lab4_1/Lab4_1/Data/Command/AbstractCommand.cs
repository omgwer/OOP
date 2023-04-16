namespace Lab4_1.Data.Command;

public abstract class AbstractCommand
{
    protected FigureType FigureType { get; set; }
    protected Point StartPoint { get; set; } = new Point();
    protected uint OutlineColor { get; set; }
}