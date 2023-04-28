namespace Lab5_1.Service;

public static class YearService
{
    private const uint DAYS_IN_STANDART_YEAR = 365;
    private const uint DAYS_IN_LEAP_YEAR = 366;
    private const uint MIN_YEAR = 1970;
    private const uint MAX_YEAR = 9999;
    private const uint YEARS_400_IN_DAYSTAMP = 146097;
    private const uint YEARS_100_IN_DAYSTAMP = 36525;
    private const uint YEARS_4_IN_DAYSTAMP = 1461;
    private const uint YEARS_400 = 400;
    private const uint YEARS_100 = 100;
    private const uint YEARS_4 = 4;

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
        for (uint i = MIN_YEAR; i < year; i++)
        {
            daysCount += GetDaysCountInThisYear(i);
        }

        return daysCount;
    }

    /**
     * Возвращает количество лет, и остаток от timestamp
     */
    public static uint ConvertTimestampToYear(ref uint timestamp)
    {
        var years = MIN_YEAR;

        var years400CycleCount = timestamp / YEARS_400_IN_DAYSTAMP;
        if (years400CycleCount > 0)
        {
            years += YEARS_400 * years400CycleCount;
            timestamp -= YEARS_400_IN_DAYSTAMP * years400CycleCount;
        }
        
        var years100CycleCount = timestamp / YEARS_100_IN_DAYSTAMP;
        if (years100CycleCount > 0)
        {
            years += YEARS_100 * years100CycleCount;
            timestamp -= YEARS_100_IN_DAYSTAMP * years100CycleCount;
        }
        
        var years4CycleCount = timestamp / YEARS_4_IN_DAYSTAMP;
        if (years100CycleCount > 0)
        {
            years += YEARS_4 * years4CycleCount;
            timestamp -= YEARS_4_IN_DAYSTAMP * years4CycleCount;
        }
        
        while (timestamp >= DAYS_IN_STANDART_YEAR)
        {
            var decrement = IsLeapYear(years) ? DAYS_IN_LEAP_YEAR : DAYS_IN_STANDART_YEAR;
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