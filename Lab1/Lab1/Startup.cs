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
namespace Lab1;

class Startup
{
    private const int VALID_PARAMETERS_COUNT = 2;
    private const int MINIMAL_FILE_NAME_SIZE = 3;

    public static int Main(string[] args)
    {
        
        if (!IsValidParametersList(ref args))
        {
            Console.WriteLine("Error! Arguments list is not valid");
            return 1;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("Error! File with name '" + args[0] + "' not found ");
            return 1;
        }

        FileStream inputFileStream;
        try
        {
            inputFileStream = File.OpenRead(args[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error! Cant open file stream with file " + args[0]);
            return 1;
        }
       
        
        var searchResultIndexes = new FilesHandler().FindSubstringsIndexesInStream(ref inputFileStream, ref args[1]);

        if (searchResultIndexes.Count == 0)
        {
            Console.WriteLine("Text not found");
            return 1;
        }
        
        searchResultIndexes.ForEach(Console.WriteLine);

        return 0;
    }

    private static bool IsValidParametersList(ref string[] args)
    {
        if (args.Length != VALID_PARAMETERS_COUNT)
            return false;
        if (!args.First().Contains('.'))
            return false;
        if (args.First().Length <= MINIMAL_FILE_NAME_SIZE)
            return false;
        if (args.Last().Length == 0)
            return false;
        return true;
    }


}