using System.Data.SqlTypes;
using System.Diagnostics;

namespace Lab1_3;

/*
 Вариант №2 – invert – 80 баллов
Разработайте приложение invert.exe, выполняющее инвертирование матрицы 3*3, 
т.е. нахождение обратной матрицы  и выводящее коэффициенты результирующей матрицы в стандартный поток вывода. Формат командной строки приложения:
invert.exe <matrix file>
Коэффициенты входной матрицы заданы во входном текстовом файле (смотрите файл matrix.txt в качестве иллюстрации)  в трех строках по 3 элемента.
Коэффициенты результирующей матрицы выводятся с точностью до 3 знаков после запятой.
Используйте двухмерные массивы для хранения коэффициентов матриц.
*/
class Program
{
    public static int Main(string[] args)
    {
        try
        {
            var pathToFile = ParseCommandLine(args);
            var inputMatrix = ReadMatrixFromFile(pathToFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        return 0;
    }

    private static string ParseCommandLine(string[] args)
    {
        if (args.Length != 1)
            throw new Exception("Error in parse command line");
        var pathToFile = args[0];
        return pathToFile;
    }

    private static float[][] ReadMatrixFromFile(string pathToFile)
    {
        string[] readStringArrayFromFile = File.ReadAllLines(pathToFile);
        Debug.Assert(readStringArrayFromFile.Length == 3, "Error, line in matrix file > 3");
        
        
    }
}