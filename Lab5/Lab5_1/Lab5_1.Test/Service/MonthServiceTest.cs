using Lab5_1.Dictionary;
using Lab5_1.Service;

namespace Lab5_1.Test.Service;

[TestFixture]
public class DaysInMonthTests
{
    private  static readonly uint _leapYear = 2024;
    private static readonly uint _standartYear = 2023;
    
    [TestCase(Month.JANUARY, 31U, 2023U)]
    [TestCase(Month.FEBRUARY, 28U, 2023U)]
    [TestCase(Month.MARCH, 31U, 2023U)]
    [TestCase(Month.APRIL, 30U, 2023U)]
    [TestCase(Month.MAY, 31U, 2023U)]
    [TestCase(Month.JUNE, 30U, 2023U)]
    [TestCase(Month.JULY, 31U, 2023U)]
    [TestCase(Month.AUGUST, 31U, 2023U)]
    [TestCase(Month.SEPTEMBER, 30U, 2023U)]
    [TestCase(Month.OCTOBER, 31U, 2023U)]
    [TestCase(Month.NOVEMBER, 30U, 2023U)]
    [TestCase(Month.DECEMBER, 31U, 2023U)]
    [TestCase(Month.FEBRUARY, 29U, 2024U)]
    public void GetDaysCountInMoth_ShouldReturnCorrectDaysCount(Month month, uint expectedDaysCount, uint year)
    {
        // Arrange

        // Act
        var actualDaysCount = MonthService.GetDaysCountInMoth(month, year);

        // Assert
        Assert.That(actualDaysCount, Is.EqualTo(expectedDaysCount));
    }
    [TestCase(1U, 31U, 2023U)]
    [TestCase(2U, 28U, 2023U)]
    [TestCase(3U, 31U, 2023U)]
    [TestCase(4U, 30U, 2023U)]
    [TestCase(5U, 31U, 2023U)]
    [TestCase(6U, 30U, 2023U)]
    [TestCase(7U, 31U, 2023U)]
    [TestCase(8U, 31U, 2023U)]
    [TestCase(9U, 30U, 2023U)]
    [TestCase(10U, 31U, 2023U)]
    [TestCase(11U, 30U, 2023U)]
    [TestCase(12U, 31U, 2023U)]
    [TestCase(2U, 29U, 2024U)]
    public void GetDaysCountInMoth_ByIndex_ShouldReturnCorrectDaysCount(uint monthIndex, uint expectedDaysCount, uint year)
    {
        // Arrange

        // Act
        var actualDaysCount = MonthService.GetDaysCountInMoth(monthIndex, year);

        // Assert
        Assert.That(actualDaysCount, Is.EqualTo(expectedDaysCount));
    }
    
    [Test]
    public void GetDaysCountInMoth_ByInvalidIndex_ShouldThrowArgumentException()
    {
        // Arrange
        uint invalidIndex = 13;
        uint year = 2022;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => MonthService.GetDaysCountInMoth(invalidIndex, year));
    }
    
    [Test]
    public void GetDaysCountInMoth_ByInvalidIndex_ShouldThrowArgumentException_IS_ZERO()
    {
        // Arrange
        uint invalidIndex = 0;
        uint year = 2022;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => MonthService.GetDaysCountInMoth(invalidIndex, year));
    }
}