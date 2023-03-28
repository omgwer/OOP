// std::string FindAndReplace(std::string const& subject, std::string const& search, std::string  const& replace),
// возвращающую результат замены всех вхождений подстроки search в строке subject на строку replace.
// Если искомая строка пустая, замены строк производиться не должно.
//     Вычислительная сложность алгоритма, лежащего в основе FindAndReplace, должно линейно зависеть от длины строки Subject
// Разработайте на ее основе программу, заменяющую все вхождения искомой строки в стандартном потоке ввода на
// строку-заменитель и выводящую результат в стандартный поток вывода.
using System.IO;
using System.Text;


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
            subject = "someonetest",
            replace = "some",
            search = "lolkek"

        };
        var result = FindAndReplace(command);

        return 0;
    }

    private static Command ParseCommandLine(string[] args)
    {
        if (args.Length != 3)
            throw new Exception("Invalid arguments count");
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
        StringBuilder stringBuilder = new StringBuilder();
        List<char> charBufferList = new List<char>();
        var charBuffer = (char)streamReader.Read();
        while (charBuffer != char.MaxValue)
        {
            charBufferList.Add(charBuffer);
            charBuffer = (char)streamReader.Read();
            
            if (charBufferList.Count == command.search.Length)
            {
                if (command.search.Equals(charBufferList.ToString()))
                {
                    stringBuilder.Append(command.replace); // если совпало, данные буфера больше не нужны
                    charBufferList.Clear();
                }
                else  // результат в буфере не совпадает с искомой строкой
                {
                    stringBuilder.Append(charBufferList.First());
                    charBufferList.Remove(charBufferList.First());
                }
            }
        }

        stringBuilder.Append(charBufferList);
        return stringBuilder.ToString();
    }
}