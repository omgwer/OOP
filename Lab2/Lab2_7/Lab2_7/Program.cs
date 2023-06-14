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
 
        while (textReader.Peek() is var currentChar)
        {
            if (currentChar == -1 || (char)currentChar == '\r')
            {
                var stackElement = elementsStack.Pop();  // TODO: добавить обработку null для operation
                if (stackElement.Operation == null)
                    throw new ArgumentException("Исходная строка содержит ошибки!");
                var res = CalculateValue((Operation)stackElement.Operation, stackElement.Numbers);
                return res;
            }

            switch ((char)currentChar)
            {
                case ' ':
                    textReader.Read();
                    break;
                case '(':
                    HandleOpeningParenthesis(textReader, ref currentElement, elementsStack);
                //     textReader.Read();
                //     if (currentElement != null)
                //         elementsStack.Push(currentElement);
                //     currentElement = new Element();
                     break;
                case ')':
                    textReader.Read();
                    int result = 0;
                    if (currentElement == null)
                        currentElement = elementsStack.Pop();

                    result = CalculateValue((Operation)currentElement!.Operation!, currentElement!.Numbers!);

                    if (elementsStack.Count == 0)
                    {
                        var nextChar = textReader.Peek();
                        if (nextChar == -1 || (char)nextChar == '\r')
                        {
                            currentElement.Operation = Operation.ADDICTION;
                            currentElement.Numbers.Clear();
                            currentElement.Numbers.Add(result);
                            elementsStack.Push(currentElement);
                            continue;
                        }
                        throw new ArgumentException("Исходная строка содержит ошибки!");
                    }

                    currentElement = elementsStack.Pop();
                    currentElement.Numbers!.Add(result);
                    elementsStack.Push(currentElement);
                    currentElement = null;
                    break;
                case '*':
                    AssignOperation(textReader, ref currentElement, Operation.MULTIPLICATION);
                    break;
                case '+':
                    AssignOperation(textReader, ref currentElement, Operation.ADDICTION);
                    break;
                default:
                    ParseNumber(textReader, currentElement);
                    // int convertedNumber = ReadNumber(textReader);
                    // currentElement!.Numbers!.Add(convertedNumber);
                    break;
            }
        }

        throw new ArgumentException("Some error");
    }
    
    private static void HandleOpeningParenthesis(TextReader textReader,ref Element? currentElement, Stack<Element> elementsStack)
    {
        textReader.Read();
        if (currentElement != null)
            elementsStack.Push(currentElement);
        currentElement = new Element();
    }
    
    private static void AssignOperation(TextReader textReader,ref Element? currentElement, Operation operation)
    {
        textReader.Read();
        if (currentElement!.Operation != null)
            throw new ArgumentException("Операция над текущим элементом уже была определена!");
        currentElement.Operation = operation;
    }

    private static void ParseNumber(TextReader textReader, Element? currentElement)
    {
        int convertedNumber = ReadNumber(textReader);
        if (currentElement != null)
        {
            currentElement.Numbers.Add(convertedNumber);
        }
        else
        {
            throw new ArgumentException("Someone fail");
        }

    }

    // private static void HandleClosingParenthesis(TextReader textReader, ref Element? currentElement, Stack<Element> elementsStack)
    // {
    //     textReader.Read();
    //     int result = 0;
    //     if (currentElement == null)
    //         currentElement = elementsStack.Pop();
    //     result = CalculateValue((Operation)currentElement!.Operation!, currentElement!.Numbers!);
    //
    //     if (elementsStack.Count == 0)
    //     {
    //         var nextChar = textReader.Peek();
    //         if (nextChar == -1 || (char)nextChar == '\r')
    //             return result;
    //         throw new ArgumentException("Исходная строка содержит ошибки!");
    //     }
    //
    //     currentElement = elementsStack.Pop();
    //     currentElement.Numbers!.Add(result);
    //     elementsStack.Push(currentElement);
    //     currentElement = null;
    // }





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