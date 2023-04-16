namespace Lab4_1.Service;

public class ValidateService
{
    private readonly uint _canvasWidth;
    private readonly uint _canvasHeight;

    public ValidateService(uint canvasWidth, uint canvasHeight)
    {
        _canvasWidth = canvasWidth;
        _canvasHeight = canvasHeight;
    }

}