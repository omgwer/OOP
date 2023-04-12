using Lab3_2.Dictionary;

namespace Lab3_2.Service;

interface ICalculatorService
{
    void VariableDeclaration(Command command);
    void VariableAssigment(Command command); 
    void FunctionDeclaration(Command command);
    double?  GetVariable(Command command);
    Dictionary<string, double?> GetAllVariables();
    Dictionary<string, double?> GetAllFunctions();
}

public class CalculatorService : ICalculatorService
{
    private IMemoryService _memoryService;

    public CalculatorService(IMemoryService memoryService)
    {
        _memoryService = memoryService;
    }

    public void VariableDeclaration(Command command)
    {
        throw new NotImplementedException();
    }

    public void VariableAssigment(Command command)
    {
        throw new NotImplementedException();
    }

    public void FunctionDeclaration(Command command)
    {
        throw new NotImplementedException();
    }

    public double? GetVariable(Command command)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, double?> GetAllVariables()
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, double?> GetAllFunctions()
    {
        throw new NotImplementedException();
    }
}