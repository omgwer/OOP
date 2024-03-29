﻿// Разработайте функцию std::set<int> GeneratePrimeNumbersSet(int upperBound), возвращающую множество всех простых чисел, не превышающих значения upperBound.
// С ее использованием разработайте программу, выводящую в стандартный поток вывода элементы множества простых чисел, не превышающие значения,
// переданного приложению через обязательный параметр командной строки.
// Максимальное значение верхней границы множества принять равным 100 миллионам.
// Время построения множества простых чисел в указанном диапазоне на компьютере с 2GHz-процессором не должно превышать 10-12 секунд (программа будет запускаться в Release-конфигурации). 
// Примечание: наивный поиск простых чисел не позволит добиться указанной производительности. Используйте «Решето Эратосфена».
// Для предварительного просеивания воспользуйтесь vector<bool> (для хранения каждого элемента он использует 1 бит информации,
// т.к. на хранение признака простоты 100 миллионов чисел потребуется всего 12,5 мегабайт памяти)
// Для проверки программы используйте тот факт, что в диапазоне от 1 до 100000000 содержится 5761455 простых чисел.

using System.Diagnostics.CodeAnalysis;

namespace Lab2_4;

public class Program
{
    public static void Main(string[] args)
    {
        var inputStream = Console.In;
        var outputStream = Console.Out;
        Console.WriteLine("Insert max number value:");
        var upperBound = Int32.Parse(inputStream.ReadLine());
        ISet<int> primeNumbersSet = new SortedSet<int>();
        try
        {
            var startDateTime = DateTime.Now;
            primeNumbersSet = GeneratePrimeNumberSet(upperBound);
            var endDateTime = DateTime.Now;
            Console.WriteLine($"{(endDateTime - startDateTime).TotalMilliseconds} ms.");
            Console.WriteLine(primeNumbersSet.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        PrintSet(primeNumbersSet, outputStream);
    }

    public static ISet<int> GeneratePrimeNumberSet(int upperBound)
    {
        var sieve = new List<bool>(Enumerable.Repeat(true, upperBound + 1));
        var sortedSet = new HashSet<int>();
        if (upperBound < 2)
        {
            return sortedSet;
        }
        sieve[1] = false;
        sieve[0] = false;
        var screeningLimit = Math.Sqrt(upperBound);
        for (var i = 2; i <= screeningLimit; i++)
            if (sieve[i])
                for (var j = i * i; j <= upperBound; j += i)
                    if (sieve[j])
                        sieve[j] = false;
        
        for (var i = 2; i <= upperBound; i++)
            if (sieve[i])
                sortedSet.Add(i);
        return sortedSet;
    }

    private static void PrintSet(ISet<int> sortedSet, TextWriter textWriter)
    {
        foreach (var elem in sortedSet)
        {
            textWriter.Write(elem);
            if (elem != sortedSet.Last())
            {
                textWriter.Write(",");
            }
        }
    }
}