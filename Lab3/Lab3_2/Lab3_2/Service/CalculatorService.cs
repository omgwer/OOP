using Lab3_2.Dictionary;

namespace Lab3_2.Service;

interface ICalculatorService
{
    void VariableDeclaration(Command variableName);  
    void VariableAssigment(Command variableName); 
    void FunctionDeclaration(Command variableName);
    string GetVariable(Command variableName);
    List<string> GetAllVariables();
    List<string> GetAllFunctions();
}

//TODO: можно однозначно определить идентефикатор или переменная, прочитав нулевой символ (у значения это цифра)
//TODO: Любая let\var переменная ВСЕГДА хранит либо double, либо null
//TODO: PRINT ВСЕГДА возращает число\null
public class CalculatorService : ICalculatorService
{
    private IMemoryService _memory;

    public CalculatorService(IMemoryService memory)
    {
        _memory = memory;
    }

    public void VariableDeclaration(Command variableName)
    {
        throw new NotImplementedException();
    }

    public void VariableAssigment(Command variableName)
    {
        throw new NotImplementedException();
    }

    public void FunctionDeclaration(Command variableName)
    {
        throw new NotImplementedException();
    }

    public string GetVariable(Command variableName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllVariables()
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllFunctions()
    {
        throw new NotImplementedException();
    }
}