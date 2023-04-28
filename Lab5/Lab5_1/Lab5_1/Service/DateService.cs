using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class DateService
{
    public static Date ConvertTimestampToDate(uint timestamp)
    {
        var year = YearService.ConvertTimestampToYear(ref timestamp);
        var month = MonthService.ConvertMonthBegginingOfThisTimestamp(ref timestamp, year);
        var day = timestamp;

        return new Date(day, month, year);
    }

    public static uint ConvertDateToTimestamp(uint day, Month month, uint year)
    {
        uint timestamp = 0;
        timestamp += YearService.GetDaysCountBeginningOfThisYear(year);
        timestamp += MonthService.GetDaysCountBeginningOfTheYear(month, year);
        uint daysInMonthCount = MonthService.GetDaysCountInMonth(month, year);
        timestamp += DayService.GetDaysCount(day, daysInMonthCount);
        return timestamp;
    }

    public static uint ConvertDateToTimestamp(Date date)
    {
        uint year = date.GetYear();
        Month month = date.GetMonth();
        uint day = date.GetDay();

        uint timestamp = 0;
        timestamp += YearService.GetDaysCountBeginningOfThisYear(year);
        timestamp += MonthService.GetDaysCountBeginningOfTheYear(month, year);
        uint daysInMonthCount = MonthService.GetDaysCountInMonth(month, year);
        timestamp += DayService.GetDaysCount(day, daysInMonthCount);
        return timestamp;
    }

    public static uint ConvertTimestampToYear(uint timestamp)
    {
        return YearService.ConvertTimestampToYear(ref timestamp);
    }

    public static Month ConvertTimestampToMonth(uint timestamp)
    {
        var year = YearService.ConvertTimestampToYear(ref timestamp);
        return MonthService.ConvertMonthBegginingOfThisTimestamp(ref timestamp, year);
    }

    // Тут получается стрейф от начала месяца если 0 то это первый день месяца
    public static uint ConvertTimestampToDay(uint timestamp)
    {
        var year = YearService.ConvertTimestampToYear(ref timestamp); 
        MonthService.ConvertMonthBegginingOfThisTimestamp(ref timestamp, year);
        return timestamp + 1;
    }
}