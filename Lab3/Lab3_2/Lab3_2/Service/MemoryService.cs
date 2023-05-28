using Lab3_2.Dictionary;
using Lab3_2.Service.Caches;

namespace Lab3_2.Service;

interface ICache
{
    void Invalidate(SortedDictionary<string, FunctionArgument> functions);
    void CacheValue(FunctionArgument functionArgument, double? value);
}

public class MemoryService
{
    private SortedDictionary<string, double?> _variables = new();
    private SortedDictionary<string, FunctionArgument> _functions = new();
    private ICache _cashe;

    // TODO: объявить интерфейс cache 
    public MemoryService(bool needCache)
    {
        if (needCache)
            _cashe = new Cache();
        else
            _cashe = new LazyCache();
    }

    public void AddVariable(string identifier)
    {
        AssertIdentifierIsBusy(identifier);
        AddVariable(identifier, null);
    }

    //TODO: вынести преобразование и проверку парса числа double на слой калькулятора
    public void SetVariable(string identifier, string firstVariable)
    {
        AddVariable(identifier, GetVariable(firstVariable));
    }

    public void SetVariable(string identifier, double? value)
    {
        AddVariable(identifier, value);
    }

    public void AddFunction(string identifier, string firstVariable, Operation? operation, string? secondVariable)
    {
        AssertIdentifierIsBusy(identifier);
        _functions.Add(identifier, new FunctionArgument()
            { FirstOperand = firstVariable, Operation = operation, SecondOperand = secondVariable });
    }

    public double? Get(string identifier)
    {
        if (IsVariable(identifier))
        {
            return GetVariable(identifier);
        }

        if (IsFunction(identifier))
        {
            return GetFunctionResultRecursive(identifier);
        }

        throw new ArgumentException($"{identifier} not found in memory!");
    }

    public SortedDictionary<string, double?> GetAllVars()
    {
        return _variables;
    }

    public SortedDictionary<string, double?> GetAllFns()
    {
        SortedDictionary<string, double?> result = new();
        foreach (var (key, value) in _functions)
        {
            result.Add(key, GetFunctionResultRecursive(key));
        }

        return result;
    }

    private void AddVariable(string identifier, double? value)
    {
        if (_variables.ContainsKey(identifier))
        {
            _cashe.Invalidate(_functions);
            _variables[identifier] = value;
        }
        else
            _variables.Add(identifier, value);
    }

    private double? GetVariable(string identifier)
    {
        return GetFunctionResultRecursive(identifier);
    }

    private double? GetFunctionResultRecursive1(string identifier)
    {
        if (!HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is not found ");
        }

        if (IsVariable(identifier))
            return _variables[identifier];
        if (IsFunction(identifier))
        {
            double? result;
            var functionArgument = _functions[identifier];
            if (functionArgument.cacheResult != null)
                return functionArgument.cacheResult;

            var first = GetFunctionResultRecursive(functionArgument.FirstOperand);
            if (functionArgument.Operation != null & functionArgument.SecondOperand != null)
            {
                var operation = functionArgument.Operation;
                var second = GetFunctionResultRecursive(functionArgument.SecondOperand);
                result = CalculateValue(first, operation, second);
            }
            else
            {
                result = first;
            }

            _cashe.CacheValue(functionArgument, result);
            return result;
        }

        throw new Exception("Someone error");
    }

    // private double? GetFunctionResultRecursive(string identifier)
    private double? GetFunctionResultRecursive(string identifier)
    {
        double? result = null;
        int stackDeep = 0;
        // var переменные для вычисленных значений
        double? varFirstValue = null, varSecondValue = null;
        Operation? varOperation = null;
        var stack = new Stack<string>();
        stack.Push(identifier);
        ++stackDeep;
        while (stack.Count > 0)
        {
            var variableIdentifier = stack.Pop();
            --stackDeep;
            if (!HasIdentifierInMemory(variableIdentifier))
                throw new ArgumentException($"Identifier - {variableIdentifier} is not found");
            if (IsVariable(variableIdentifier))
            {
                if (varFirstValue == null)
                    varFirstValue = _variables[variableIdentifier];
                else
                    varSecondValue = _variables[variableIdentifier];
                // TODO: выглядит будто тут хорошо бы вытащить элемент из стека
                continue;
            }
    
            var functionArgument = _functions[variableIdentifier]; // переменная точно функция
            if (functionArgument.cacheResult != null)
            {
                if (varFirstValue == null)
                    varFirstValue = _variables[variableIdentifier];
                else
                    varSecondValue = _variables[variableIdentifier];
                continue;
            }
        }
    
        if (stack.Count == 0)
            return result;
    
        throw new Exception("Stack is empty! Logic error");
    }
    
    private void AssertIdentifierIsBusy(string identifier)
    {
        if (HasIdentifierInMemory(identifier))
            throw new ArgumentException($"Identifier - {identifier} is busy");
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

    private double? CalculateValue(double? firstVariable, Operation? operation, double? secondVariable)
    {
        double? result;
        if (firstVariable == null)
            result = null;
        if (operation == null)
            result = firstVariable;
        if (secondVariable == null)
            result = null;
        switch (operation)
        {
            case Operation.ADDITION:
                result = firstVariable + secondVariable;
                break;
            case Operation.SUBTRACTION:
                result = firstVariable - secondVariable;
                break;
            case Operation.MULTIPLICATION:
                result = firstVariable * secondVariable;
                break;
            case Operation.DIVISION:
                if (secondVariable == 0)
                    throw new ArgumentException("Error, division by zero!!!");
                result = firstVariable / secondVariable;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), operation,
                    "Error operation in calculate value!");
        }

        return result;
    }
}