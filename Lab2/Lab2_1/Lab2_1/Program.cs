// Разработайте программу, выполняющую считывание массива чисел с плавающей запятой, разделяемых
// пробелами, из стандартного потока ввода в vector, обрабатывающую его согласно заданию
// Вашего варианта и выводящую в стандартный поток полученный массив (разделенный пробелами).
// В программе должны быть выделены функции, выполняющие считывание массива, его обработку
// и вывод результата.
// Пустой массив, переданный программе – допустимые входные данные. При его обработке пустой массив должен оставаться пустым.
using System.Globalization;

class Program
{
    public static int Main()
    {
        try
        {
            var numbersList = ParseCommandLine();
            var minimalElementInList = numbersList.Min();
            var modifiedNumbersList = ModifyElementsByPredicate(numbersList, minimalElementInList);
            PrintListToOutput(modifiedNumbersList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        return 0;
    }

    private static List<double> ParseCommandLine()
    {
        using var inputStream = Console.In;
        var numbersList = new List<double>();
        var readLine = Console.ReadLine();
        while (readLine != null)
        {
            var elementsList = ParseStringToDoubleList(readLine);
            numbersList.AddRange(elementsList);
            readLine = inputStream.ReadLine();
        }
        inputStream.Close();
        return numbersList;
    }

    private static List<double> ParseStringToDoubleList(string inputString)
    {
        var stringElementList = inputString.Split(' ').ToList();
        var numbersList = new List<double>();
        stringElementList.ForEach(e =>
        {
            if (e != "")
                numbersList.Add(double.Parse(e, CultureInfo.InvariantCulture.NumberFormat));
        });
        return numbersList;
    }

    private static List<double> ModifyElementsByPredicate(List<double> elementList, double minimalElement)
    {
        var modifiedElementList = new List<double>();
        elementList.ForEach(e => modifiedElementList.Add(e * minimalElement));
        return modifiedElementList;
    }

    private static void PrintListToOutput(List<double> modifiedNumbersList)
    {
        if (modifiedNumbersList.Count == 0)
            Console.Out.Write("empty list");
        modifiedNumbersList.ForEach(e => 
            Console.Out.Write($"{Math.Round(e, 3)} "));
    }
}