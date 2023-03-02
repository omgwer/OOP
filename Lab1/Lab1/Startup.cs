/*
Вариант #3 – findtext – 50 баллов
Разработайте программу findtext.exe, выполняющую поиск указанной строки в файле. Формат командной строки:
    findtext.exe < file name > < text to search>
Например:
findtext.exe “Евгений Онегин.txt” “Я к Вам пишу”
В случае, когда искомая строка в файле найдена, приложение возвращает нулевое значение и выводит в стандартный выводной поток
номера всех строк (по одному номеру в каждой строке), содержащих искомую строку. В противном случае программа возвращает 1 
и выводит в стандартный поток вывода «Text not found».
При осуществлении поиска регистр символов имеет значение (это упрощает поиск). Слова «Онегин» и «онегин» являются разными.
Программа должна корректно обрабатывать ошибки, связанные с файловыми операциями.
В комплекте с программой должны обязательно поставляться файлы, позволяющие проверить корректность её работы в автоматическом режиме.
*/

using System.Data;

namespace Lab1;

class Startup
{
    private struct Command
    {
        public string FileName;
        public string StringToSeacrch;
    }

    public static int Main(string[] args)
    {
        try
        {
            var command = ParseCommandLine(args);
            var substringsIndexesInFile = FindSubstringsIndexesInFile(command); // лучше возвращать результат
            if (substringsIndexesInFile.Count == 0)
            {
                Console.WriteLine("Error"); // 
                return 1;
            }
            substringsIndexesInFile.ForEach(Console.WriteLine);
        }
        catch
            (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        return 0;
    }

    private static Command ParseCommandLine(string[] args)
    {
        const int VALID_PARAMETERS_COUNT = 2;
        const int MINIMAL_FILE_NAME_SIZE = 3;
        if ((args.Length != VALID_PARAMETERS_COUNT) ||
            (!args.First().Contains('.')) ||
            (args.First().Length <= MINIMAL_FILE_NAME_SIZE) ||
            (args.Last().Length == 0))
        {
            throw new ArgumentException("Error! Arguments list is not valid");
        }

        return new Command()
        {
            FileName = args.First(),
            StringToSeacrch = args.Last()
        };
    }

    private static List<int> FindSubstringsIndexesInFile(Command command)
    {
        using var fileStream = File.OpenRead(command.FileName);
        using var streamReader = new StreamReader(fileStream); // почитать насчет using
        var searchResultIndexes = new List<int>();
        var textLineIndex = 0;
        while (streamReader.ReadLine() is { } readString)
        {
            var index = readString.IndexOf(command.StringToSeacrch, StringComparison.Ordinal);
            if (index > -1)
                searchResultIndexes.Add(textLineIndex);
            textLineIndex++;
        }
        return searchResultIndexes;
    }
}