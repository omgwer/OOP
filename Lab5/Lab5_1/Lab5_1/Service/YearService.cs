namespace Lab5_1.Service;

public static class YearService
{
    private const uint DAYS_IN_STANDART_YEAR = 365;
    private const uint DAYS_IN_LEAP_YEAR = 366;
    private const uint MIN_YEAR = 1970;
    private const uint MAX_YEAR = 9999;

    public static bool IsLeapYear(uint year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    public static uint GetDaysCountInPeri(uint year)
    {
        return IsLeapYear(year) ? DAYS_IN_LEAP_YEAR : DAYS_IN_STANDART_YEAR;
    }
    
    private static bool IsValidPeriod(uint year)
    {
        return year is >= MIN_YEAR and < MAX_YEAR;
    }

    private static void AssertIsValidPeriod(uint year)
    {
        if (!IsValidPeriod(year))
            throw new ArgumentException($"Year - {year} is not valid");
    }
}