
// Разработайте программу, выполняющую считывание массива чисел с плавающей запятой, разделяемых
// пробелами, из стандартного потока ввода в vector, обрабатывающую его согласно заданию
// Вашего варианта и выводящую в стандартный поток полученный массив (разделенный пробелами).
// В программе должны быть выделены функции, выполняющие считывание массива, его обработку
// и вывод результата.
// Пустой массив, переданный программе – допустимые входные данные. При его обработке пустой массив должен оставаться пустым.

using System.Numerics;

class Program
{
    public static void Main()
    {
        var inputStream = Console.In;
        var outputStream = Console.Out;
        var numbersList = ParseCommandLine(inputStream);


        
       
    }



    private static  List<float> ParseCommandLine(TextReader inputStream)
    {
        var numbersList = new List<float>();
        var t = inputStream.ReadToEnd();
        Console.WriteLine(t);


        

        return numbersList;
    }
}