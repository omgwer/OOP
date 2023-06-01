using System.Text;
using System.Text.RegularExpressions;

namespace Lab2_6;

public class Program
{
    private const string FILE_NAME_REGEXP = @"^[A-Za-z1-9]{1,50}\.[A-Za-z]{1,3}$";

    private struct Command
    {
        public string inputFileName;
        public string outputFileName;
        public Dictionary<string, string> dictionary;
    }

    private struct ReplaceContainer
    {
        public int startIndex = 0;
        public string key = string.Empty;
        public string value = string.Empty;

        public ReplaceContainer(int startIndex, string key, string value)
        {
            this.startIndex = startIndex;
            this.key = key;
            this.value = value;
        }
    }
    
    public static int Main(string[] args)
    {
        var command = ParseCommandLine(args);
        using var streamReader = new StreamReader(command.inputFileName);
        using var streamWriter = new StreamWriter(command.outputFileName);
        
        if (command.dictionary.Count == 0)
            streamWriter.Write(streamReader.ReadToEnd());
        else
            ReplaceStreamWithADictionary(streamReader, streamWriter, command.dictionary);
        return 0;
    }

    public static void ReplaceStreamWithADictionary(StreamReader stringReader, StreamWriter streamWriter, Dictionary<string, string> dictionary)
    {
        while (stringReader.ReadLine() is { } currentString)
        {
            if (currentString == string.Empty)
            {
                streamWriter.WriteLine();
                continue;
            }

            var replacedString = ExpandTemplate(currentString, dictionary);
            streamWriter.WriteLine(replacedString);
        }
    }

    public static string ExpandTemplate(string tpl, Dictionary<string, string> dictionary)
    {
        StringBuilder stringBuilder = new();
        List<ReplaceContainer> replaceContainers = new();

        foreach (var keyValuePair in dictionary)
            replaceContainers.AddRange(GetAllIndexesOf(tpl, keyValuePair));

        var curerntIndex = 0;
        // Алгоритм - находим первое место которое можно заменить, ищем наиболее длинный вариант замены.
        while (replaceContainers.Count != 0)
        {
            // Находим минимальный индекс, куда можно подставить значение
            int minStartIndex = replaceContainers.Min(r => r.startIndex);
            // Ищем список контейнеров которые начинаются с этого индекса
            List<ReplaceContainer> selectedElements =
                replaceContainers.Where(r => r.startIndex == minStartIndex).ToList();
            // Ищем максимальное значение, которое можно поместить
            ReplaceContainer elementWithMaxLength = selectedElements.MaxBy(r => r.value.Length);

            // добавляем элементы строки, которые не изменились
            stringBuilder.Append(tpl.Substring(curerntIndex, minStartIndex - curerntIndex));
            // подставляем значение из словаря
            stringBuilder.Append(elementWithMaxLength.value);

            curerntIndex += minStartIndex - curerntIndex;
            curerntIndex += elementWithMaxLength.key.Length;

            // удаляем использованные элементы из коллекции
            replaceContainers.RemoveAll(e => e.startIndex < curerntIndex);
        }

        if (curerntIndex < tpl.Length)
            stringBuilder.Append(tpl.Substring(curerntIndex, tpl.Length - curerntIndex));

        return stringBuilder.ToString();
    }

    private static List<ReplaceContainer> GetAllIndexesOf(string str, KeyValuePair<string, string> keyValuePair)
    {
        List<ReplaceContainer> replaceContainers = new();
        for (int index = 0;; index += keyValuePair.Key.Length)
        {
            index = str.IndexOf(keyValuePair.Key, index);
            if (index == -1)
                return replaceContainers;
            replaceContainers.Add(new ReplaceContainer(index, keyValuePair.Key, keyValuePair.Value));
        }
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