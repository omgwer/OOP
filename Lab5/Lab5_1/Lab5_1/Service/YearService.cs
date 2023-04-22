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

    public static uint GetDaysCountInThisYear(uint year)
    {
        AssertIsValidPeriod(year);
        return IsLeapYear(year) ? DAYS_IN_LEAP_YEAR : DAYS_IN_STANDART_YEAR;
    }

    /** Возвращает количество дней во всех годах, до введенного */
    public static uint GetDaysCountBeginningOfThisYear(uint year)
    {
        AssertIsValidPeriod(year);
        uint daysCount = 0;
        for (uint i = 1970; i < year; i++)
        {
            if (IsLeapYear(i))
                daysCount += DAYS_IN_LEAP_YEAR;
            else
                daysCount += DAYS_IN_STANDART_YEAR;
        }

        return daysCount;
    }

    /**
     * Возвращает количество лет, и остаток от timestamp
     */
    public static uint GetYearsCountBeginningOfThisTimestamp(ref uint timestamp)
    {
        var years = MIN_YEAR;
        var endOfYears = false;
        while (!endOfYears && timestamp >= DAYS_IN_STANDART_YEAR)
        {
            var decrement = IsLeapYear(years + 1) ? DAYS_IN_LEAP_YEAR : DAYS_IN_STANDART_YEAR;
            if (timestamp >= decrement)
            {
                years++;
                timestamp -= decrement;
            }
            else  
            {
                return years;
            }
        }

        return years;
    }

    private static bool IsValidPeriod(uint year)
    {
        return year is >= MIN_YEAR and <= MAX_YEAR;
    }

    private static void AssertIsValidPeriod(uint year)
    {
        if (!IsValidPeriod(year))
            throw new ArgumentException($"Year - {year} is not valid");
    }
}