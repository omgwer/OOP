namespace Lab2_7;

public static class Program
{
    private enum Operation
    {
        ADDICTION,
        MULTIPLICATION
    };

    private class Element
    {
        public Operation? Operation;
        public readonly List<int> Numbers = new();
    }

    public static int Main(string[] args)
    {
        TextReader textReader = Console.In;
        int result = EvaluateExpression(textReader);
        Console.WriteLine(result);
        return 0;
    }

    public static int EvaluateExpression(TextReader textReader)
    {
        Stack<Element> elementsStack = new();
        Element? currentElement = null;
        int? result;

        var operations = new Dictionary<char, Action>
        {
            { ' ', () => textReader.Read() },
            { '(', () => HandleOpeningParenthesis(textReader, ref currentElement, elementsStack) },
            { ')', () => HandleClosingParenthesis(textReader, ref currentElement, elementsStack) },
            { '*', () => AssignOperation(textReader, ref currentElement, Operation.MULTIPLICATION) },
            { '+', () => AssignOperation(textReader, ref currentElement, Operation.ADDICTION) },
        };

        while (textReader.Peek() is var currentChar)
        {
            if (currentChar == -1 || (char)currentChar == '\r')
            {
                var stackElement = elementsStack.Pop();
                if (stackElement.Operation == null)
                    throw new ArgumentException("Исходная строка содержит ошибки!");
                result = CalculateValue((Operation)stackElement.Operation, stackElement.Numbers);
                break;
            }
            
            char charValue = (char)currentChar;

            if (operations.ContainsKey(charValue))
                operations[charValue]();
            else
                ParseNumber(textReader, currentElement);
        }

        if (result == null)
            throw new ArgumentException("Выражение не высчитано!");
        return (int)result;
    }

    private static void HandleOpeningParenthesis(TextReader textReader, ref Element? currentElement,
        Stack<Element> elementsStack)
    {
        textReader.Read();
        if (currentElement != null)
            elementsStack.Push(currentElement);
        currentElement = new Element();
    }

    private static void AssignOperation(TextReader textReader, ref Element? currentElement, Operation operation)
    {
        textReader.Read();
        if (currentElement!.Operation != null)
            throw new ArgumentException("Операция над текущим элементом уже была определена!");
        currentElement.Operation = operation;
    }

    private static void ParseNumber(TextReader textReader, Element? currentElement)
    {
        if (currentElement == null)
            throw new ArgumentException("Someone fail");
        int convertedNumber = ReadNumber(textReader);
        currentElement.Numbers.Add(convertedNumber);
    }

    private static void HandleClosingParenthesis(TextReader textReader, ref Element? currentElement,
        Stack<Element> elementsStack)
    {
        textReader.Read();
        currentElement ??= elementsStack.Pop();   // if currentElement == null забираем из стека
        
        var result = CalculateValue((Operation)currentElement!.Operation!, currentElement.Numbers);

        if (elementsStack.Count == 0 && !(textReader.Peek() == -1 || textReader.Peek() == '\r'))
            throw new ArgumentException("Исходная строка содержит ошибки!");

        if (elementsStack.Count != 0)
            currentElement = elementsStack.Pop();
        else
            currentElement.Numbers.Clear();
        currentElement.Numbers.Add(result);
        elementsStack.Push(currentElement);
        currentElement = null;
    }


    private static int CalculateValue(Operation operation, List<int> numbers)
    {
        return operation == Operation.ADDICTION
            ? numbers.Sum()
            : numbers.Aggregate(1, (result, number) => result * number);
    }

    private static int ReadNumber(TextReader reader)
    {
        var number = 0;
        var isNegative = false;
        var hasDigit = false;

        while (true)
        {
            int nextChar = reader.Peek();
            if ((char)nextChar == '-' && !hasDigit)
            {
                reader.Read();
                isNegative = true;
                continue;
            }

            if ((char)nextChar == ' ' && !hasDigit && !isNegative) // для кейса  "- 123"
            {
                reader.Read();
                continue;
            }

            if (nextChar == -1 || !char.IsDigit((char)nextChar))
            {
                if (hasDigit)
                {
                    if (isNegative)
                        number = -number;
                    return number;
                }

                throw new FormatException($"{(char)nextChar} - невалидный символ для преобразования в число");
            }

            reader.Read();
            hasDigit = true;
            number = number * 10 + (nextChar - '0');
        }
    }
}