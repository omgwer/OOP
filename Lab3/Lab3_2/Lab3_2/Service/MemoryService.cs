﻿using System.Globalization;
using Lab3_2.Dictionary;

namespace Lab3_2.Service;

public interface IMemoryService
{
    void Add(Command command);
    double? Get(Command command);
    Dictionary<string, double?> GetAllVars();
    Dictionary<string, double?> GetAllFns();
}

public struct FunctionArgument
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
            return GetFunctionResultRecursive(command.Identifier);
        }

        throw new ArgumentException($"{command.Identifier} not found in memory!");
    }

    public Dictionary<string, double?> GetAllVars()
    {
        return _variables;
    }

    public Dictionary<string, double?> GetAllFns()
    {
        Dictionary<string, double?> result = new ();
        foreach (var (key, value) in _functions)
        {
            result.Add(key, GetFunctionResultRecursive(key));
        }

        return result;
    }

    private void Save()
    {
        
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
        return GetFunctionResultRecursive(identifier);
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

    private double? GetFunctionResultRecursive(string identifier)
    {
        if (!HasIdentifierInMemory(identifier))
        {
            throw new ArgumentException($"Identifier - {identifier} is not found ");
        }

        if (IsVariable(identifier))
            return _variables[identifier];
        if (IsFunction(identifier))
        {
            var functionArgument = _functions[identifier];
            var first = GetFunctionResultRecursive(functionArgument.FirstOperand);
            if (functionArgument.Operation != null & functionArgument.SecondOperand != null)
            {
                var operation = functionArgument.Operation;
                var second = GetFunctionResultRecursive(functionArgument.SecondOperand);
                return CalculateValue(first, operation, second);
            }
            return first;
        }

        throw new Exception("Someone error");
        // TODO: нужно добавить расчет значения функции
    }

    private void AssertIdentifierInMemory(string identifier)
    {
        if (!HasIdentifierInMemory(identifier))
            throw new Exception($"Identifier - {identifier} is not found");
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
        if (firstVariable == null)
            return null;
        if (operation == null)
            return firstVariable;
        if (secondVariable == null)
            return null;
        switch (operation)
        {
            case Operation.ADDITION:
                return firstVariable + secondVariable;
            case Operation.SUBTRACTION:
                return firstVariable - secondVariable;
            case Operation.MULTIPLICATION:
                return firstVariable * secondVariable;
            case Operation.DIVISION:
                if (secondVariable == 0)
                    throw new ArgumentException("Error, division by zero!!!");
                return firstVariable / secondVariable;
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), operation, "Error operation in calculate value!");
        }
    }
}