class Program
{
    enum Operation
    {
        ADDICTION, // +
        MULTIPLICATION // *
    };

    class Element
    {
        public Operation? operation = null;
        public List<int>? numbers = new();
    }

    public static int Main(string[] args)
    {
        TextReader textReader = Console.In;
        int result = EvaluateExpression(textReader);
        Console.WriteLine(result);
        return 0;
    }

    private static int EvaluateExpression(TextReader textReader)
    {
        Stack<Element> elementsStack = new();
        char lastIndexedCharWithoutSpace;
        Element? currentElement = null;
        while (textReader.Peek() is var currentChar)
        {
            switch (currentChar)
            {
                case -1:
                     var stackElement = elementsStack.Pop();
                    var res = CalculateValue((Operation)stackElement!.operation!, stackElement!.numbers!);
                    return res;
                case ' ':
                    textReader.Read();
                    break;
                case '(':
                    textReader.Read();
                    if (currentElement != null)
                        elementsStack.Push(currentElement);
                    currentElement = new Element();
                    break;
                case ')':
                    textReader.Read();
                    // Высчитываем текущий элемент стека После, вытаскиваем еще один элемент и добавляем в список результат вычислений.
                    var result = CalculateValue((Operation)currentElement!.operation!, currentElement!.numbers!);
                    if (elementsStack.Count == 0)
                        return result;
                    var previewsElement = elementsStack.Pop();
                    previewsElement.numbers!.Add(result);
                    elementsStack.Push(previewsElement);
                    currentElement = null;
                    break;
                case '*':
                    textReader.Read();
                    // Добавить валидацию на то что операция уже задана
                    currentElement!.operation = Operation.MULTIPLICATION;
                    break;
                case '+':
                    textReader.Read();
                    // Добавить валидацию на то что операция уже задана
                    currentElement!.operation = Operation.ADDICTION;
                    break;
                default:
                    // Пытаемся распарсить число, если не смогли, то все, писос.
                    int convertedNumber = ReadNumber(textReader);
                    currentElement!.numbers!.Add(convertedNumber);
                    break;
            }
        }

        return 0;
    }

    private static int CalculateValue(Operation operation, List<int> numbers)
    {
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

    public static int ReadNumber(TextReader reader)
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
                else
                {
                    throw new FormatException($"{(char)nextChar}Invalid input: expected a number");
                }
            }

            reader.Read();
            hasDigit = true;
            number = number * 10 + (nextChar - '0');
        }
    }
}