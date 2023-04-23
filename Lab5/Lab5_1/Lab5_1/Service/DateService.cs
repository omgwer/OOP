using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class DateService
{
    public static Date ConvertTimestampToDate(uint timestamp)
    {
        var year = YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
        var month = MonthService.GetMonthBeginningOfThisTimestamp(ref timestamp, year);
        var day = timestamp;

        return new Date(day, month, year);
    }

    public static uint ConvertDateToTimestamp(uint day, Month month, uint year)
    {
        uint timestamp = 0;
        timestamp += YearService.GetDaysCountBeginningOfThisYear(year);
        timestamp += MonthService.GetDaysCountBeginningOfTheYear(month, year);
        if (day == 0 || day > MonthService.GetDaysCountInMonth(month, year))
        {
            throw new ArgumentException($"Days count = {day} is not valid for this data!");
        }

        timestamp += day - 1;
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
        if (day == 0 || day > MonthService.GetDaysCountInMonth(month, year))
        {
            throw new ArgumentException($"Days count = {day} is not valid for this data!");
        }

        timestamp += day - 1;
        return timestamp;
    }

    public static uint ConvertTimestampToYear(uint timestamp)
    {
        return YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
    }

    public static Month ConvertTimestampToMonth(uint timestamp)
    {
        var year = YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
        return MonthService.GetMonthBeginningOfThisTimestamp(ref timestamp, year);
    }

    // Тут получается стрейф от начала месяца если 0 то это первый день месяца
    public static uint ConvertTimestampToDay(uint timestamp)
    {
        var year = YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
        MonthService.GetMonthBeginningOfThisTimestamp(ref timestamp, year);
        return timestamp + 1;
    }
}