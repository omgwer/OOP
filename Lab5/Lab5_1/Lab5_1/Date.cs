using Lab5_1.Dictionary;
using static Lab5_1.Service.DateService;
using static Lab5_1.Service.WeekDayService;

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
        _timestamp = ConvertDateToTimestamp(day, month, year);
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
        return ConvertTimestampToDay(_timestamp);
    }

    // возвращает месяц
    public Month GetMonth()
    {
        return ConvertTimestampToMonth(_timestamp);
    }

    // возвращает год
    public uint GetYear()
    {
        return ConvertTimestampToYear(_timestamp);
    }

    // возвращает день недели
    public WeekDay GetWeekDays()
    {
        return GetWeekDay(_timestamp);
    }

    public override string ToString()
    {
        return
            $"Date object : day is - {GetDay()}, month is {GetMonth()}, year is {GetYear()}, day of the week is {GetWeekDays()}";
    }

    // ++, --, +, -, +=, -=, >>, <<, ==, !=, >, <, >=, <=
    // operator overloading 
    public static Date operator ++(Date date)
    {
        var timestamp = ConvertDateToTimestamp(date);
        timestamp++;
        var newDate = TryUpdateValue(timestamp);
        return newDate ?? date;
    }

    public static Date operator --(Date date)
    {
        var timestamp = ConvertDateToTimestamp(date);
        timestamp--;
        var newDate = TryUpdateValue(timestamp);
        return newDate ?? date;
    }
    
    /** return null if error in operation */
    public static Date? operator +(Date date, uint days)
    {
        if (days == 0)
            return date;
        var timestamp = ConvertDateToTimestamp(date);
        timestamp += days;
        var newDate = TryUpdateValue(timestamp);
        // if (newDate == null)
        //     throw new ArgumentException($"Addiction operation is not available! value error");
        return newDate;
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