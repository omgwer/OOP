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
        public readonly List<int>? Numbers = new();
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
        while (textReader.Peek() is var currentChar) // currentChar какой тип данных
        {
            if (currentChar == -1)
            {
                var stackElement = elementsStack.Pop();
                // TODO: добавить обработку null для operation
                var res = CalculateValue((Operation)stackElement!.Operation!, stackElement!.Numbers!);
                return res;
            }
            
            switch ((char)currentChar)
            {
                case ' ':
                    textReader.Read();
                    break;
                case '(':
                    textReader.Read();
                    if (currentElement != null)
                        elementsStack.Push(currentElement);
                    currentElement = new Element();
                    break;
                case ')': //use map
                    textReader.Read();
                    int result = 0;
                    if (currentElement == null)
                        currentElement = elementsStack.Pop();

                    result = CalculateValue((Operation)currentElement!.Operation!, currentElement!.Numbers!);

                    if (elementsStack.Count == 0)
                    {
                        var nextChar = textReader.Peek();
                        if (nextChar == -1 || (char)nextChar == '\r')
                            return result;
                        throw new ArgumentException("Исходная строка содержит ошибки!");
                    }

                    currentElement = elementsStack.Pop();
                    currentElement.Numbers!.Add(result);
                    elementsStack.Push(currentElement);
                    currentElement = null;
                    break;
                case '*':
                case '+':
                    textReader.Read();
                    if (currentElement!.Operation != null)
                        throw new ArgumentException("Операция над текущим элементом уже была определена!");
                    currentElement.Operation = currentChar == '*' ? Operation.MULTIPLICATION : Operation.ADDICTION;
                    break;
                default:
                    int convertedNumber = ReadNumber(textReader);
                    currentElement!.Numbers!.Add(convertedNumber);
                    break;
            }
        }

        throw new ArgumentException("Some error");
    }
    
    //
    // private static byte[] ConvertBytesWithCondition(byte[] buffer, int length, byte key, CryptType cryptType)
    // {
    //     Func<byte, byte, byte> cryptFunc = cryptType switch
    //     {
    //         CryptType.ENCRYPT => EncryptByte,
    //         CryptType.DECRYPT => DecryptByte,
    //         _ => throw new InvalidEnumArgumentException("CryptType not found!")
    //     };
    //     var bytes = new byte[length];
    //
    //     for (var i = 0; i < length; i++)
    //         bytes[i] = cryptFunc(buffer[i], key);
    //
    //     return bytes;
    // }

    
    private static int CalculateValue(Operation operation, List<int> numbers)
    {
        // сделать цикл и лямбду в коорой будет либо умножение, либо деление. Которую получаем из метода
        var calculateResult = 0;
        if (operation == Operation.ADDICTION)
            foreach (var number in numbers)
                calculateResult += number;
        else
        {
            calculateResult = 1;
            foreach (var number in numbers)
                calculateResult *= number;
        }

        return calculateResult;
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

                throw new FormatException($"{(char)nextChar}Invalid input: expected a number");
            }

            reader.Read();
            hasDigit = true;
            number = number * 10 + (nextChar - '0');
        }
    }
}