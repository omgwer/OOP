
using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class MonthService
{
    private static readonly uint LEAP_YEAR_FEBRUARY_INCREMENT = 1;
    private static readonly Dictionary<Month, uint> _dictionary = new ()
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

    public static uint GetDaysCountInMoth(Month month, uint year)
    {
        if (YearService.IsLeapYear(year) && month == Month.FEBRUARY)
        {
            return _dictionary[month] + LEAP_YEAR_FEBRUARY_INCREMENT;
        }
        return _dictionary[month];
    }
    
    public static uint GetDaysCountInMoth(uint index, uint year)
    {
        if (index is 0 or > 12)
            throw new ArgumentException($"{index} - this value is not valid for month index");
        if (YearService.IsLeapYear(year) && (Month)index == Month.FEBRUARY)
        {
            return _dictionary[(Month)index] + LEAP_YEAR_FEBRUARY_INCREMENT;
        }
        return _dictionary[(Month)index];
    }
}