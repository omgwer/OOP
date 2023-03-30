// Разработайте программу, выполняющую считывание массива чисел с плавающей запятой, разделяемых
// пробелами, из стандартного потока ввода в vector, обрабатывающую его согласно заданию
// Вашего варианта и выводящую в стандартный поток полученный массив (разделенный пробелами).
// В программе должны быть выделены функции, выполняющие считывание массива, его обработку
// и вывод результата.
// Пустой массив, переданный программе – допустимые входные данные. При его обработке пустой массив должен оставаться пустым.

using System.Globalization;

public class Program
{
    public static int Main()
    {
        try
        {
            // переименовать Parsecomand - check
            // нужно работать с текущим массивом, а не копией - check
            // добавить сортировку - check
            // добавить тесты через фрейворк
            TextReader textReader = Console.In;
            TextWriter textWriter = Console.Out;
            ReadStreamAndPrintResult(textReader, textWriter);
        }
        catch (Exception ex)
        {
            return 1;
        }

        return 0;
    }

    public static void ReadStreamAndPrintResult(TextReader textReader, TextWriter textWriter)
    {
        var modifiedNumbersList = ReadNumbersAndModifyByPredicate(textReader);
        modifiedNumbersList.Sort();
        modifiedNumbersList.ForEach(e => textWriter.Write($"{Math.Round(e, 3)} "));
    }

    public static List<double> ReadNumbersAndModifyByPredicate(TextReader input)
    {
        var numbersList = ReadInputStream(input);
        ModifyNumbersListForPredicate(numbersList);
        return numbersList;
    }

    private static List<double> ReadInputStream(TextReader inputStream)
    {
        var numbersList = new List<double>();
        var readLine = inputStream.ReadLine();

        while (!string.IsNullOrEmpty(readLine))
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

    //void
    private static void ModifyNumbersListForPredicate(List<double> elementList)
    {
        var elementsCount = elementList.Count;
        if (elementsCount == 0)
            return;
        var minimalElementInList = elementList.Min();
        for (var i = 0; i < elementsCount; i++)
        {
            elementList[i] *= minimalElementInList;
        }
    }
}