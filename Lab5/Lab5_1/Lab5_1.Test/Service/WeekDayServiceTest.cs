using Lab5_1.Dictionary;
using Lab5_1.Service;

namespace Lab5_1.Test.Service;

public class WeekDayServiceTest
{
    // [TestCase(1U, Month.JANUARY, 1970U, WeekDay.THURSDAY)]  // thursday
    // [TestCase(23U, Month.APRIL, 2023U, WeekDay.SUNDAY)]  // sunday
    // [TestCase(27U, Month.MAY, 2021U, WeekDay.THURSDAY)]  // thursday
    // [TestCase(1U, Month.JANUARY, 2023U, WeekDay.SUNDAY)]  // sunday
    // [TestCase(2U, Month.JANUARY, 2023U, WeekDay.MONDAY)]  // sunday
    [TestCase(27U, Month.APRIL, 2923U, WeekDay.TUESDAY)]  // sunday
    public void ConvertByZellerAlgorithm_ValidValues(uint day, Month month, uint year, WeekDay expectedDay)
    {
        // Act
        var weekDay = WeekDayService.GetWeekDay(day, month, year);

        // Assert
        Assert.That(weekDay, Is.EqualTo(expectedDay));
    }
    
    [TestCase(0U, WeekDay.THURSDAY)]
    [TestCase(30U, WeekDay.SATURDAY)]
    public void ConvertByZellerAlgorithm_ValidValues1(uint timestamp, WeekDay expectedDay)
    {
        // Act
        var weekDay = WeekDayService.GetWeekDay(timestamp);
    
        // Assert
        Assert.That(weekDay, Is.EqualTo(expectedDay));
    }
}