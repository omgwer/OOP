// std::string FindAndReplace(std::string const& subject, std::string const& search, std::string  const& replace),
// возвращающую результат замены всех вхождений подстроки search в строке subject на строку replace.
// Если искомая строка пустая, замены строк производиться не должно.
//     Вычислительная сложность алгоритма, лежащего в основе FindAndReplace, должно линейно зависеть от длины строки Subject
// Разработайте на ее основе программу, заменяющую все вхождения искомой строки в стандартном потоке ввода на
// строку-заменитель и выводящую результат в стандартный поток вывода.
using System.IO;


//Console.WriteLine(System.Text.Encoding.GetEncoding(1251).GetString((new byte[] { 195 })));
class Program
{
    public struct Command
    {
        public string subject;
        public string search;
        public string replace;
    }

    public static int Main(string[] args)
    {
        //Command command = ParseCommandLine(args);

        var command = new Command()
        {
            subject = "test.txt",
            replace = "",
            search = ""

        };
        var result = FindAndReplace(command);

        return 0;
    }

    private static Command ParseCommandLine(string[] args)
    {
        if (args.Length != 3)
            throw new Exception("Invalid arguments count");
        if (!args[0].Contains('.'))
            throw new Exception("Invalid first argument");
        return new Command()
        {
            subject = args[0],
            search = args[1],
            replace = args[2]
        };
    }

    private static string FindAndReplace(Command command)
    {
        var streamReader = File.OpenText(command.subject);
        var readMaskSize = command.search.Length;
        char[] charBuffer = new char[readMaskSize];
        
        
        char charInFileStream = (char)streamReader.Read();
        while (charInFileStream != char.MaxValue)
        {
            for (var i = 0; i < readMaskSize; i++)
            {
                
            }
        }

        // List<char> some = new List<char>();
        // char s = (char)streamReader.Read();
        // while (s != char.MaxValue)
        // {
        //     some.Add(s);
        //     s = (char) streamReader.Read();
        // }

        return "some";
    }
    
    
}