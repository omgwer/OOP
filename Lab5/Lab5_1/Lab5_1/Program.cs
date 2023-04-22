// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

DateTimeOffset date = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix
DateTimeOffset epoch = new DateTimeOffset(1970, 2, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix


TimeSpan timeSinceEpoch = epoch - date;

Console.WriteLine(timeSinceEpoch.Days);