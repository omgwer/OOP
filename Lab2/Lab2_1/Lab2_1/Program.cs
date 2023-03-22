// Разработайте программу, выполняющую считывание массива чисел с плавающей запятой, разделяемых
// пробелами, из стандартного потока ввода в vector, обрабатывающую его согласно заданию
// Вашего варианта и выводящую в стандартный поток полученный массив (разделенный пробелами).
// В программе должны быть выделены функции, выполняющие считывание массива, его обработку
// и вывод результата.
// Пустой массив, переданный программе – допустимые входные данные. При его обработке пустой массив должен оставаться пустым.
using System.Globalization;
using System.Text;

public class Program
{
    public static int Main()
    {
        try
        { // переименовать Parsecomand - check
            // нужно работать с текущим массивом, а не копией - check
            // добавить сортировку - check
            // добавить тесты через фрейворк
            var input = Console.In;
            var outputString = ReadNumbersAndModifyByPredicate(input);
            Console.WriteLine(outputString);
        }
        catch (Exception ex)
        {
            return 1;
        }

        return 0;
    }

    public static string ReadNumbersAndModifyByPredicate(TextReader input)
    {
        var numbersList = ReadInput(input);
        var modifiedNumbersList = ModifyNumbersListForPredicate(numbersList);
        modifiedNumbersList.Sort();
        return ConvertNumbersListToString(modifiedNumbersList);
    }

    private static List<double> ReadInput(TextReader inputStream)
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

    private static List<double> ModifyNumbersListForPredicate(List<double> elementList)
    {
        var elementsCount = elementList.Count;
        if (elementsCount== 0)
            return elementList;
        var minimalElementInList = elementList.Min();
        for (var i = 0; i < elementsCount; i++)
        {
            elementList[i] *= minimalElementInList;
        }
        return elementList;
    }

    private static string ConvertNumbersListToString(List<double> modifiedNumbersList)
    {
        var stringBuilder = new StringBuilder();
        modifiedNumbersList.ForEach(e =>
            stringBuilder.Append($"{Math.Round(e, 3)} "));
        return stringBuilder.ToString().Trim();
    }
}