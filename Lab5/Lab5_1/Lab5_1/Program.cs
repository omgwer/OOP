// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using Lab5_1;


// DateTimeOffset date = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix
// DateTimeOffset epoch = new DateTimeOffset(9999, 12, 31, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix
//
//
// TimeSpan timeSinceEpoch = epoch - date;
//
// Console.WriteLine(timeSinceEpoch.Days);


var date = new Date(1);

var t1 = date >> Console.Out;

var t2 = date << Console.In;

var ttt = t2 >> Console.Out;

