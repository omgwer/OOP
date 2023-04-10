using System.Globalization;
using Lab3_2.Dictionary;

namespace Lab3_2.Service;

public interface IMemoryService
{
    void Add(Command command);
    double? Get(Command command);
    Dictionary<string, double?> GetAllVars();
    Dictionary<string, string?> GetAllFns();
}

struct FunctionArgument
{
    public string FirstOperand;
    public Operation? Operation;
    public string? SecondOperand;
}

// TODO: реализовать кэш для вычисленных функций(возможно)
public class MemoryService : IMemoryService
{
    private Dictionary<string, double?> _variables = new();
    private Dictionary<string, FunctionArgument> _functions = new();

    public void Add(Command command)
    {
        switch (command.CommandType)
        {
            case CommandType.VAR:
                AddVariable(command.Identifier, null);
                break;
            case CommandType.LET:
                if (char.IsDigit(command.FirstVariable.First()))
                    AddVariable(command.Identifier, double.Parse(command.FirstVariable, CultureInfo.InvariantCulture));
                else
                    AddVariable(command.Identifier, GetVariable(command.FirstVariable));
                break;
            case CommandType.FN:
                AddFunction(command.Identifier, command.FirstVariable, command.Operation, command.SecondVariable);
                break;
            default:
                throw new ArgumentException("Command is not valid for 'Add' in memoryService");
        }
    }

    public double? Get(Command command)
    {
        if (IsVariable(command.Identifier))
        {
            return GetVariable(command.Identifier);
        }
        if (IsFunction(command.Identifier))
        {
            return GetFunctionResult(command.Identifier);
        }

        throw new ArgumentException($"{command.Identifier} not found in memory!");
    }

    public Dictionary<string, double?> GetAllVars()
    {
        return _variables;
    }

    public Dictionary<string, string?> GetAllFns()
    {
        throw new NotImplementedException();
    }

    private void AddVariable(string identifier, double? value)
    {
        if (HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is busy ");
        }

        _variables.Add(identifier, value);
    }

    private double? GetVariable(string identifier)
    {
        if (!HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is not found ");
        }

        return _variables[identifier];
    }

    private void AddFunction(string identifier, string firstVariable, Operation? operation, string? secondVariable)
    {
        if (HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is busy ");
        }

        _functions.Add(identifier, new FunctionArgument()
            {FirstOperand = firstVariable, Operation = operation, SecondOperand = secondVariable});
    }

    private double? GetFunctionResult(string identifier)
    {
        if (!HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is not found ");
        }

        // Пока через рекурсию.
        if (IsVariable(identifier))
            return _variables[identifier];
        if (IsFunction(identifier))
        {
            
            
        }
        // TODO: нужно добавить расчет значения функции
    }

    private bool HasIdentifierInMemory(string identifier)
    {
        return IsVariable(identifier) | IsFunction(identifier);
    }

    private bool IsFunction(string identifier)
    {
        return _functions.ContainsKey(identifier);
    }

    private bool IsVariable(string identifier)
    {
        return _variables.ContainsKey(identifier);
    }
}