using Lab5_1.Dictionary;
using Lab5_1.Service;

namespace Lab5_1;

// Дата в формате день-месяц-год. Год в диапазоне от 1970 до 9999
public class Date
{
    private uint _timestamp;

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
        _timestamp = timestamp;
    }

    // возвращает день месяца (от 1 до 31)
    uint GetDay()
    {
        throw new NotImplementedException();
    }

    // возвращает месяц
    Month GetMonth()
    {
        throw new NotImplementedException();
    }

    // возвращает год
    uint GetYear()
    {
        throw new NotImplementedException();
    }

    // возвращает день недели
    WeekDay GetWeekDay()
    {
        throw new NotImplementedException();
    }

    // private uint ConvertDateToTimestamp(uint day, Month month, uint year)
    // {
    //     uint timestamp = 0;
    //     timestamp += YearService.GetDaysCountBeginningOfThisYear(year);
    //     timestamp += MonthService.GetDaysCountBeginningOfTheYear(month, year);
    //     if (day == 0 || day > MonthService.GetDaysCountInMonth(month, year))
    //     {
    //         throw new ArgumentException($"Days count = {day} is not valid for this data!");
    //     }
    //
    //     timestamp += day;
    //     return timestamp;
    // }
    //
    // private Date ConvertTimestampToDate(uint timestamp)
    // {
    //     var year = YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
    //     var month = MonthService.GetMonthBeginningOfThisTimestamp(ref timestamp, year);
    //     var day = timestamp;
    //
    //     return new Date(day, month, year);
    // }
}