namespace Lab5_1.Service;

public static class YearService
{
    private static uint DAYS_IN_STANDART_YEAR = 365;
    private static uint DAYS_IN_LEAP_YEAR = 366;

    public static bool IsLeapYear(uint year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }
}