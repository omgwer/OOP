// See https://aka.ms/new-console-template for more information

namespace Lab1_2;

// Вариант №6 – radix – 100 баллов
// Разработайте программу radix.exe, выполняющую перевод чисел из одной произвольной системы счисления в другую произвольную и запись результата в стандартный поток вывода.
// Под произвольной системой счисления понимается система с основанием от 2 до 36.
// Системы счисления с 11-ричной до 36-ричной должны использовать заглавные буквы латинского алфавита от A до Z для представления разрядов с 1010 до 3510.
// Формат командной строки приложения:
//      radix.exe <source notation> <destination notation> <value>
// Например, следующим способом программа должна осуществлять перевод шестнадцатеричного числа 1F в его десятичное представление:
//      radix.exe 16 10 1F
class Program
{
    struct Command
    {
        public int SourceNotation; // Исходная система счисления
        public int DestinationNotation; // Новая система счисления
        public string Value; // Число для преобразования
    }

    private static readonly char[] ValuesArray =
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    public static int Main(string[] args)
    {
        try
        {
            Command command = ParseCommandLine(args);
            string convertedValue = ConvertValueToDestinationNotation(command);
            Console.WriteLine(convertedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Someone failed");
            return 1;
        }

        return 0;
    }

    private static Command ParseCommandLine(string[] args)
    {
        const byte VALID_ARGUMENTS_COUNT = 3;
        const byte MIN_NOTATION_NUMBER = 2;
        const byte MAX_NOTATION_NUMBER = 36;
        var isParseError = false;
        var sourceNotation = 0;
        var destinationNotation = 0;
        if (args.Length != VALID_ARGUMENTS_COUNT)
            isParseError = true;
        else if (int.TryParse(args[0], out sourceNotation) ||
                 sourceNotation is < MIN_NOTATION_NUMBER or > MAX_NOTATION_NUMBER)
            isParseError = true;
        else if (int.TryParse(args[1], out destinationNotation) ||
                 destinationNotation is < MIN_NOTATION_NUMBER or > MAX_NOTATION_NUMBER)
            isParseError = true;
        var value = args[2].ToCharArray();
        var valuesArrayByNotationLimit = ValuesArray[..sourceNotation];
        for (var i = 0; i < value.Length && !isParseError; i++)
        {
            if (!valuesArrayByNotationLimit.Contains(value[i]))
                isParseError = true;
        }

        if (isParseError)
            throw new Exception("Error with parse command line");

        return new Command()
        {
            SourceNotation = sourceNotation,
            DestinationNotation = destinationNotation,
            Value = args[2]
        };
    }

    private static string ConvertValueToDestinationNotation(Command command)
    {
        return "";
    }
}