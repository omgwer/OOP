// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using Lab5_1;
using Lab5_1.Service;


DateTimeOffset date = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix
DateTimeOffset epoch = new DateTimeOffset(1974, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix



TimeSpan timeSinceEpoch = epoch - date;

Console.WriteLine(timeSinceEpoch.Days);

//
// var t1 = date >> Console.Out;
//
// var t2 = date << Console.In;
//
// var ttt = t2 >> Console.Out;


