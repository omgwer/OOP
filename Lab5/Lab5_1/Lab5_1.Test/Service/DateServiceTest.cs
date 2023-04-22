using Lab5_1.Dictionary;
using Lab5_1.Service;

namespace Lab5_1.Test.Service;

public class DateServiceTest
{
    // [Test]
    // public void ConvertTimestampToDate_ShouldReturnDate_WhenTimestampIsValid()
    // {
    //     // Arrange
    //     uint timestamp = 0;
    //     uint expectedDay = 1;
    //     Month expectedMonth = Month.JANUARY;
    //     uint expectedYear = 1970;
    //
    //     // Act
    //     var result = DateService.ConvertTimestampToDate(timestamp);
    //
    //     // Assert
    //     Assert.AreEqual(expectedDay, result.Day);
    //     Assert.AreEqual(expectedMonth, result.Month);
    //     Assert.AreEqual(expectedYear, result.Year);
    // }

    [TestCase(1U, Month.JANUARY, 1970U, 0U)]
    [TestCase(31U, Month.JANUARY, 1970U, 30U)]
    [TestCase(1U, Month.JANUARY, 1971U, 365U)]
    [TestCase(29U, Month.FEBRUARY, 1972U, 365U + 365U + 31U + 28U)]
    public void ConvertDateToTimestamp_ValidValues(uint day, Month month, uint year, uint expectedTimestamp)
    {
        // Act
        var timestamp = DateService.ConvertDateToTimestamp(day, month, year);

        // Assert
        Assert.That(timestamp, Is.EqualTo(expectedTimestamp), $"Expected  - {expectedTimestamp}, result - {timestamp}");
    }


    [TestCase(0U, Month.JANUARY, 1970U)]
    [TestCase(29U, Month.FEBRUARY, 1970U)]
    [TestCase(30U, Month.FEBRUARY, 1972U)]
    [TestCase(32U, Month.JANUARY, 1972U)]
    public void ConvertDateToTimestamp_InvalidValues(uint day, Month month, uint year)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => DateService.ConvertDateToTimestamp(day, month, year));
    }

    [Test]
    public void ConvertDateToTimestamp_ShouldThrowException_WhenDaysCountIsInvalid()
    {
        // Arrange
        uint day = 32;
        Month month = Month.JANUARY;
        uint year = 1970;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => DateService.ConvertDateToTimestamp(day, month, year));
    }

    [TestCase(0U, 1970U)]
    [TestCase(365U, 1971U)]
    public void ConvertTimestampToYear_ShouldReturnYear_WhenTimestampIsValid(uint timestamp, uint expectedYear)
    {
        // Act
        var result = DateService.ConvertTimestampToYear(timestamp);

        // Assert
        Assert.That(result, Is.EqualTo(expectedYear));
    }

    [TestCase(0U, Month.JANUARY)]
    [TestCase(30U, Month.JANUARY)]
    [TestCase(31U, Month.FEBRUARY)]
    public void ConvertTimestampToMonth_ShouldReturnMonth_WhenTimestampIsValid(uint timestamp, Month expectedMonth)
    {
        // Act
        var result = DateService.ConvertTimestampToMonth(timestamp);

        // Assert
        Assert.That(result, Is.EqualTo(expectedMonth));
    }

    [TestCase(0U, 0U)]
    [TestCase(30U, 30U)]
    [TestCase(31U, 0U)]
    [TestCase(31U + 28U, 0U)]
    [TestCase(31U + 27U, 27U)]
    [TestCase(365U, 0U)]
    [TestCase(364U, 30U)]
    [TestCase(364U, 30U)]
    [TestCase(365U + 365U, 0U)]
    public void ConvertTimestampToDay_ShouldReturnDay_WhenTimestampIsValid(uint timestamp, uint expectedDay)
    {
        // Act
        var result = DateService.ConvertTimestampToDay(timestamp);

        // Assert
        Assert.That(result, Is.EqualTo(expectedDay));
    }
}