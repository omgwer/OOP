using System.Text;
using System.Text.RegularExpressions;

namespace Lab2_6;

class Program
{
    private const string FILE_NAME_REGEXP = @"^[A-Za-z]{1,8}\.[A-Za-z]{1,3}$";

    struct Command
    {
        public string inputFileName;
        public string outputFileName;
        public Dictionary<string, string> dictionary;
    }

    public static int Main(string[] args)
    {
        //Command command = ParseCommandLine(args);
        string testTpl = "Hello, %USER_NAME%. Today is {WEEK_DAY}.";
        Dictionary<string, string> dictionary = new();
        dictionary.Add("%USER_NAME%", "Ivan Petrov");
        dictionary.Add("{WEEK_DAY}", "Friday");
        var t = ExpandTemplate(testTpl, dictionary);
        
        return 0;
    }

    public static string ExpandTemplate(string tpl, Dictionary<string, string> dictionary)
    {
        StringBuilder stringBuilder = new();
        var bufferSize = dictionary.Keys.Max(key => key.Length);  // ищем самый длинный ключ
        var varIndex = 0;
        while (varIndex < tpl.Length)
        {
            string varKey = string.Empty;
            string varValue = string.Empty;
            var currentSubstring = tpl.Substring(varIndex, varIndex + bufferSize);
            foreach (var (key, value) in dictionary)
            {
                if (currentSubstring.Contains(key) && (String.CompareOrdinal(value, varValue) > 0))
                {
                    varKey = key;
                    varValue = value;
                }
            }

            if (varKey == string.Empty)
            {
                stringBuilder.Append(tpl[varIndex]);
                varIndex += 1;
                continue;
            }
            // Нужно заменить в исходной подстроке  значение, и сдвинуть индекс РОВНО до конца индекса
            int indexOfStartKey = currentSubstring.IndexOf(varKey, StringComparison.Ordinal);
            var test = currentSubstring.Remove(indexOfStartKey, varKey.Length).Insert(indexOfStartKey, varValue);
            stringBuilder.Append(test);
            varIndex += indexOfStartKey;
        }
        return stringBuilder.ToString();
    }

    private static Command ParseCommandLine(string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("Not valid arguments count");
        }
        
        if (args.Length % 2 != 0)
        {
            throw new ArgumentException("Not valid arguments count");
        }

        Command command = new Command();
        command.inputFileName = ParseFileName(args[0]);
        command.outputFileName = ParseFileName(args[1]);
        command.dictionary = ConvertCommandArgsToDictionary(args);
        return command;
    }

    private static string ParseFileName(string value)
    {
        if (!Regex.IsMatch(value, FILE_NAME_REGEXP))
            throw new ArgumentException($"{value} - is not valid value for file name!");
        return value;
    }

    private static Dictionary<string, string> ConvertCommandArgsToDictionary(string[] args)
    {
        Dictionary<string, string> dictionary = new();
        var startIndex = 1;
        string key = string.Empty;
        string value = string.Empty;

        while (startIndex + 1 < args.Length)
        {
            key = args[++startIndex];
            value = args[++startIndex];
            if (key == string.Empty)
                continue;

            if (dictionary.ContainsKey(key))
            {
                // Если значение в словаре меньше, чем значение в value , переопределяем значением из value
                if (String.CompareOrdinal(dictionary[key], value) < 0)
                    dictionary[key] = value;
                continue;
            }

            dictionary.Add(key, value);
        }

        return dictionary;
    }
}