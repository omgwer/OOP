// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

DateTimeOffset date1 = new DateTimeOffset(2023, 4, 22, 0, 0, 0, TimeSpan.Zero); // Ваша дата
DateTimeOffset date = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix
DateTimeOffset epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); // Эпоха Unix

TimeSpan timeSinceEpoch = date - epoch;
double totalSeconds = timeSinceEpoch.TotalSeconds;
double totalDays = totalSeconds / 86400; // 86400 секунд в дне

Console.WriteLine(timeSinceEpoch.TotalDays);
Console.WriteLine(timeSinceEpoch.Days);
Console.WriteLine(totalDays); // Выводит количество дней от 1 января 1970 года до вашей даты