namespace Lab5_1.Service;

public class DayService
{
    public static uint GetDaysCount(uint timestamp, uint dayInMonth)
    {
        if (timestamp == 0 || timestamp > dayInMonth)
        {
            throw new ArgumentException($"Days count = {timestamp} is not valid for this data!");
        }
        return timestamp - 1;
    }
}