public class ProgramSome
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

    public static int EvaluateExpression(TextReader textReader)
    {
        Stack<Element> elementsStack = new();
        Element? currentElement = null;    //зачем вне цикла обьявлять
        while (textReader.Peek() is var currentChar) // currentChar какой тип данных
        {
            switch (currentChar)
            {
                case -1://
                    var stackElement = elementsStack.Pop();
                        // TODO: добавить обработку null для operation
                    var res = CalculateValue((Operation) stackElement!.operation!, stackElement!.numbers!);
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
                case ')'://use map
                    textReader.Read();
                    int result = 0;
                    if (currentElement == null)
                        currentElement = elementsStack.Pop();

                    result = CalculateValue((Operation) currentElement!.operation!, currentElement!.numbers!);

                    if (elementsStack.Count == 0)
                    {
                        if (textReader.Peek() == -1)
                            return result;
                        throw new ArgumentException("Исходная строка содержит ошибки!");
                    }

                    currentElement = elementsStack.Pop();
                    currentElement.numbers!.Add(result);
                    elementsStack.Push(currentElement);
                    currentElement = null;
                    break;
                case '*':// * и + можно обьединить
                    textReader.Read();
                    if (currentElement!.operation != null)
                        throw new ArgumentException("Операция над текущим элементом уже была определена!");
                    currentElement!.operation = Operation.MULTIPLICATION;
                    break;
                case '+':
                    textReader.Read();
                    if (currentElement!.operation != null)
                        throw new ArgumentException("Операция над текущим элементом уже была определена!");
                    currentElement!.operation = Operation.ADDICTION;
                    break;
                default:
                    int convertedNumber = ReadNumber(textReader);
                    currentElement!.numbers!.Add(convertedNumber);
                    break;
            }
        }

        throw new ArgumentException("Some error");
    }

    private static int CalculateValue(Operation operation, List<int> numbers)
    {// сделать цикл и лямбду в коорой будет либо умножение, либо деление. Которую получаем из метода
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

            if ((char) nextChar == '-' && !hasDigit)
            {
                reader.Read();
                isNegative = true;
                continue;
            }

            if ((char) nextChar == ' ' && !hasDigit && !isNegative) // для кейса  "- 123"
            {
                reader.Read();
                continue;
            }

            if (nextChar == -1 || !char.IsDigit((char) nextChar))
            {
                if (hasDigit)
                {
                    if (isNegative)
                        number = -number;
                    return number;
                }

                throw new FormatException($"{(char) nextChar}Invalid input: expected a number");
            }

            reader.Read();
            hasDigit = true;
            number = number * 10 + (nextChar - '0');
        }
    }
}