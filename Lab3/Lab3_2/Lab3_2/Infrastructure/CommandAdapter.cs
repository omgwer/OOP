using System.Globalization;
using System.Text;
using Lab3_2.Dictionary;

namespace Lab3_2.Infrastructure;

public static class CommandAdapter
{
    private static readonly int ONE_ARGUMENT = 1;
    private static readonly int TWO_ARGUMENTS = 2;

    private static readonly char[] AvailableIdentifierChars =
    {
        '_',
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z'
    };

    public static Command ConvertToCommand(string value)
    {
        var command = new Command();
        var commandString = value.Split(" ");
        if (commandString.Length == 0 | commandString.Length > 2)
            throw new Exception($"Cant convert {value} to Command.");

        command.CommandType = ConvertToCommandType(commandString[0]);

        if (commandString.Length == ONE_ARGUMENT)
            return command;
        var commandWithoutCommandType = commandString[1].Split("=");
        if (commandString.Length == 0 | commandString.Length > 2)
            throw new Exception($"Cant convert {value} to Command.");
        command.Identifier = ConvertToIdentifier(commandWithoutCommandType.First());

        if (commandWithoutCommandType.Length != TWO_ARGUMENTS)
            return command;
        var result = ParseCommandStringAfterEqualsChar(commandWithoutCommandType.Last());
        switch (result.Count)
        {
            case 1:
                command.FirstVariable = result.First();
                break;
            case 3:
                command.FirstVariable = result.First();
                command.Operation = ConvertToOperation(result[1]);
                command.SecondVariable = result.Last();
                break;
        }
        
        //TODO: добавить валидацию объекта ( нельзя для PRINTFNS передавать аргументы и тд.)
        // TODO: циклическая ссылка на саму себя для FN
        return command;
    }

    public static List<string> ParseCommandStringAfterEqualsChar(string value)
    {
        var result = new List<string>();
        var stringBuilder = new StringBuilder();
        foreach (var ch in value)
        {
            if (IsOperation(ch))
            {
                result.Add(stringBuilder.ToString());
                stringBuilder.Clear();
                result.Add(ch.ToString());
            }
            else
                stringBuilder.Append(ch);
        }
        if (stringBuilder.ToString() != string.Empty)
            result.Add(stringBuilder.ToString());
        ValidateCommandArguments(result, value);
        return result;
    }
    
    public static void ValidateCommandArguments(List<string> arguments, string value)
    {
        switch (arguments.Count)
        {
            case 0 :
                throw new ArgumentException($"Argument counts in command {value} is not valid!");
            case > 3:
                throw new ArgumentException($"Argument counts in command {value} is not valid!");
            case > 1 when IsDouble(arguments[0]):
                throw new ArgumentException($"If variable is double argument counts is 1");
            case 1 when (!(IsIdentifier(arguments.First()) | IsDouble(arguments.First()))):
                throw new ArgumentException($"First variable is not valid!");
            case 2 : 
                throw new ArgumentException($"Second variable is not valid!");
            case 3:
                ConvertToIdentifier(arguments.First());
                ConvertToOperation(arguments[1]);
                ConvertToIdentifier(arguments.Last());
                break;
        }
    }

    public static bool IsIdentifier(string value)
    {
        if (value == string.Empty | value == " ")
            return false;
        if (char.IsDigit(value.First()))
            return false;
        for (var i = 1; i < value.Length; i++)
        {
            if (!IsValidCharForIdentifier(value[i]))
                return false;
        }

        return true;
    }

    public static bool IsDouble(string value)
    {
        try
        {
            double.Parse(value, CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public static string ConvertToIdentifier(string value)
    {
        if (IsIdentifier(value))
            return value;
        throw new Exception($"Identifier = {value} is not valid. Error");
    }

    public static CommandType ConvertToCommandType(string value)
    {
        return value switch
        {
            "var" => CommandType.VAR,
            "let" => CommandType.LET,
            "fn" => CommandType.FN,
            "print" => CommandType.PRINT,
            "printvars" => CommandType.PRINTVARS,
            "printfns" => CommandType.PRINTFNS,
            _ => throw new ArgumentException($"Command type argument = {value} is not valid. Error")
        };
    }

    public static Operation ConvertToOperation(string value)
    {
        return value switch
        {
            "+" => Operation.ADDITION,
            "-" => Operation.SUBTRACTION,
            "*" => Operation.MULTIPLICATION,
            "/" => Operation.DIVISION,
            _ => throw new ArgumentException($"Operation argument = {value} is not valid. Error")
        };
    }

    public static bool IsOperation(char ch)
    {
        return ch == '+' | ch == '-' | ch == '*' | ch == '/';
    }

    private static bool IsValidCharForIdentifier(char ch)
    {
        return AvailableIdentifierChars.Any(availableIdentifierChar => ch == availableIdentifierChar);
    }
}