using Lab5_1.Dictionary;
using static Lab5_1.Service.DateService;
using static Lab5_1.Service.WeekDayService;

namespace Lab5_1;

// Дата в формате день-месяц-год. Год в диапазоне от 1970 до 9999
public class Date
{
    private uint _timestamp;
    private const uint MAX_TIMESTAMP = 2932896; // 31.12.9999  // сделать за константное время. кратное 400

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
            $"{GetDay():00}.{(int)GetMonth():00}.{GetYear()}";
    }

    // ++, --, +, -, +=, -=, >>, <<, ==, !=, >, <, >=, <=
    // operator overloading 
    public static Date operator ++(Date date)
    {
        var timestamp = ConvertDateToTimestamp(date);
        timestamp++;
        var newDate = TryConvertTimestampToDay(timestamp);
        return newDate ?? date;
    }

    public static Date operator --(Date date)
    {
        var timestamp = ConvertDateToTimestamp(date);
        timestamp--;
        var newDate = TryConvertTimestampToDay(timestamp);
        return newDate ?? date;
    }

    /** return null if error in operation */
    public static Date? operator +(Date date, uint days)
    {
        if (days == 0)
            return date;
        var timestamp = ConvertDateToTimestamp(date);
        timestamp += days;
        var newDate = TryConvertTimestampToDay(timestamp);
        return newDate;
    }

    public static Date? operator -(Date date, uint days)
    {
        if (days == 0)
            return date;
        var timestamp = ConvertDateToTimestamp(date);
        timestamp -= days;
        var newDate = TryConvertTimestampToDay(timestamp);
        return newDate;
    }

    public static int operator -(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        var difference = (int)fistTimestamp - (int)secondTimestamp;
        return difference;
    }

    public static bool operator ==(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp == secondTimestamp;
    }

    public static bool operator !=(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp != secondTimestamp;
    }

    public static bool operator >(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp > secondTimestamp;
    }

    public static bool operator <(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp < secondTimestamp;
    }

    public static bool operator >=(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp >= secondTimestamp;
    }

    public static bool operator <=(Date firstDate, Date secondDate)
    {
        var fistTimestamp = ConvertDateToTimestamp(firstDate);
        var secondTimestamp = ConvertDateToTimestamp(secondDate);
        return fistTimestamp <= secondTimestamp;
    }

    // write operator
    public static int operator >> (Date date, TextWriter textWriter)
    {
        textWriter.WriteLine(date.ToString());
        return 0;
    }

    // read operator
    public static Date operator <<(Date date, TextReader textReader)
    {
        var result = textReader.ReadLine();
        if (result == null)
            throw new IOException("Error IO");
        var dateArr = result.Trim().Split('.');
        if (dateArr.Length != 3)
            throw new ArgumentException("Argument count is not valid!");
        try
        {
            var isCanCreateData = true;
            uint day = 0;
            uint monthIndex = 0;
            uint year = 0;
            isCanCreateData = isCanCreateData && uint.TryParse(dateArr[0], out day);
            isCanCreateData = isCanCreateData && uint.TryParse(dateArr[1], out monthIndex);
            isCanCreateData = isCanCreateData && uint.TryParse(dateArr[2], out year);
            if (!isCanCreateData)
                throw new ArgumentException("Cant create argument for create Data");
            var newDate = new Date(day, (Month)monthIndex, year);
            return newDate;
        }
        catch (ArgumentException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private static Date? TryConvertTimestampToDay(uint newTimestamp)
    {
        try
        {
            return new Date(newTimestamp);
        }
        catch (ArgumentException exception)
        {
            return null;
        }
    }
}