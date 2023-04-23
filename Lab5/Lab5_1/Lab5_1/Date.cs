using Lab5_1.Dictionary;
using Lab5_1.Service;

namespace Lab5_1;

// Дата в формате день-месяц-год. Год в диапазоне от 1970 до 9999
public class Date
{
    private uint _timestamp;
    private const uint MAX_TIMESTAMP = 2932896; // 31.12.9999

    public uint Timestamp => _timestamp;

    // инициализируем дату заданными днем, месяцем и годом.
    // примечание: год >= 1970
    public Date(uint day, Month month, uint year)
    {
        _timestamp = DateService.ConvertDateToTimestamp(day, month, year);
    }

    // инициализируем дату количеством дней, прошедших после 1 января 1970 года
    // например, 2 = 3 января 1970, 32 = 2 февраля 1970 года и т.д.
    public Date(uint timestamp = 0)
    {
        if (timestamp > MAX_TIMESTAMP)
            throw new ArgumentException($"Timestap value = {timestamp} is not valid! ");
        _timestamp = timestamp;
    }

    // возвращает день месяца (от 1 до 31)
    public uint GetDay()
    {
        return DateService.ConvertTimestampToDay(_timestamp);
    }

    // возвращает месяц
    public Month GetMonth()
    {
        return DateService.ConvertTimestampToMonth(_timestamp);
    }

    // возвращает год
    public uint GetYear()
    {
        return DateService.ConvertTimestampToYear(_timestamp);
    }

    // возвращает день недели
    public WeekDay GetWeekDay()
    {
        return WeekDayService.GetWeekDay(_timestamp);
    }

    public override string ToString()
    {
        return
            $"Date object : day is - {GetDay()}, month is {GetMonth()}, year is {GetYear()}, day of the week is {GetWeekDay()}";
    }

    // ++, --, +, -, +=, -=, >>, <<, ==, !=, >, <, >=, <=
    // operator overloading 
    public static Date operator ++(Date date)
    {
        var timestamp = DateService.ConvertDateToTimestamp(date);
        timestamp++;
        var newDate = TryUpdateValue(timestamp);
        return newDate ?? date;
    }

    public static Date operator --(Date date)
    {
        var timestamp = DateService.ConvertDateToTimestamp(date);
        timestamp--;
        var newDate = TryUpdateValue(timestamp);
        return newDate ?? date;
    }

    private static Date? TryUpdateValue(uint newTimestamp)
    {
        try
        {
            return new Date(newTimestamp);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Cant update timestamp! {exception.Message}");
            return null;
        }
    }
}