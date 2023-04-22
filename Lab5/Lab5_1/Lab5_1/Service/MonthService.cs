using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class MonthService
{
    private static readonly uint LEAP_YEAR_FEBRUARY_INCREMENT = 1;

    private static readonly Dictionary<Month, uint> _dictionary = new()
    {
        { Month.JANUARY, 31 },
        { Month.FEBRUARY, 28 },
        { Month.MARCH, 31 },
        { Month.APRIL, 30 },
        { Month.MAY, 31 },
        { Month.JUNE, 30 },
        { Month.JULY, 31 },
        { Month.AUGUST, 31 },
        { Month.SEPTEMBER, 30 },
        { Month.OCTOBER, 31 },
        { Month.NOVEMBER, 30 },
        { Month.DECEMBER, 31 }
    };

    public static uint GetDaysCountInMonth(Month month, uint year)
    {
        if (YearService.IsLeapYear(year) && month == Month.FEBRUARY)
        {
            return _dictionary[month] + LEAP_YEAR_FEBRUARY_INCREMENT;
        }

        return _dictionary[month];
    }

    public static uint GetDaysCountInMonth(uint index, uint year)
    {
        AssertMonthIndex(index);
        return GetDaysCountInMonth((Month)index, year);
    }


    /** Возвращает количество дней во всех месяцах, до введенного */
    public static uint GetDaysCountBeginningOfTheYear(uint index, uint year)
    {
        AssertMonthIndex(index);
        return GetDaysCountBeginningOfTheYear((Month)index, year);
    }

    public static uint GetDaysCountBeginningOfTheYear(Month month, uint year)
    {
        uint daysCount = 0;
        for (var i = 1; i < (int)month; i++)
        {
            daysCount += _dictionary[(Month) i];
        }
        
        if (month > Month.FEBRUARY && YearService.IsLeapYear(year))
            daysCount++;


        return daysCount;
    }

    private static void AssertMonthIndex(uint index)
    {
        if (index is 0 or > 12)
            throw new ArgumentException($"{index} - this value is not valid for month index");
    }
}