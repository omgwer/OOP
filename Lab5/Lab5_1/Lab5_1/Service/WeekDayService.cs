using Lab5_1.Dictionary;

namespace Lab5_1.Service;

public static class WeekDayService
{
    private const uint MIN_DAY = 1;
    private const uint MAX_DAY = 7;
    
    
    
    public static bool IsValidPeriod(uint index)
    {
        return index is >= MIN_DAY and <= MAX_DAY;
    }

    public static void AssertIsValidPeriod(uint index)
    {
        if (!IsValidPeriod(index))
            throw new ArgumentException($"{index} - this value is not valid for month index");
    }
}