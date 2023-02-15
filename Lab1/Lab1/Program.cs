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



using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace ReplaceProgram;
class Program
{
    private const int VALID_PARAMETERS_COUNT = 2;
    private const int MINIMAL_FILE_NAME_SIZE = 3;
    public static int Main(string[] args)
    {
        if (!IsValidParametersList(ref args)) {
            Console.WriteLine("Arguments list is not valid");
            return 1;
        }

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
    }
}

