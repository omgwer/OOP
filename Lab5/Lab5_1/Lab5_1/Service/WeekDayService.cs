using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class WeekDayService
{
    public static WeekDay GetWeekDay(uint timestamp)
    {
        var year = YearService.GetYearsCountBeginningOfThisTimestamp(ref timestamp);
        var month = MonthService.GetMonthBeginningOfThisTimestamp(ref timestamp, year);
        var day = timestamp + 1;
        return GetWeekDay(day, month, year);
    }

    public static WeekDay GetWeekDay(uint day, Month month, uint year)
    {
        var result = ConvertByZellerAlgorithm(day, (uint)month, year);
        return (WeekDay)result;
    }

    private static byte ConvertByZellerAlgorithm(uint day, uint month, uint year)
    {
        if (month < 3u)
        {
            --year;
            month += 10u;
        }
        else
            month -= 2u;

        return (byte)(((ushort)day + 31u * (ushort)month / 12u + year + year / 4u - year / 100u + year / 400u) % 7u);
    }

    // private static uint ConvertByZellerAlgorithm(uint day, uint month, uint year)
    // {
    //     var q = day;
    //     var m = month;
    //     var y = m < 3 ? year - 1 : year;
    //     var K = y % 100;
    //     var J = y / 100;
    //     var h = (q + (13 * (m + 1) / 5) + K + (K / 4) + (J / 4) - 2 * J) % 7;
    //     return h;
    // }
}