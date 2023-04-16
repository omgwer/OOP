namespace Lab4_1.Service;

public class CommandHandler
{
    private static readonly string SPACE = " ";
    private ValidateService _validateService;
    private List<IShape> _shapes;

    public CommandHandler(List<IShape> shapes, ValidateService validateService)
    {
        _validateService = validateService;
        _shapes = shapes;
    }

    public void HandleStringCommand(string value)
    {
        var stringList = value.Split(SPACE);
    }
}