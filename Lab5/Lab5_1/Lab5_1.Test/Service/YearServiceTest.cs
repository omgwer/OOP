using Lab5_1.Service;

namespace Lab5_1.Test.Service;

public class YearServiceTests
{
    [TestCase(2000U, true)]
    [TestCase(1900U, false)]
    [TestCase(2001U, false)]
    [TestCase(2004U, true)]
    public void IsLeapYear_ReturnsCorrectResult(uint year, bool expected)
    {
        // Arrange

        // Act
        var result = YearService.IsLeapYear(year);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1970U, 365U)]
    [TestCase(2000U, 366U)]
    [TestCase(2022U, 365U)]
    [TestCase(9999U, 365U)]
    public void GetDaysCountInThisYear_ReturnsCorrectResult(uint year, uint expected)
    {
        // Arrange

        // Act
        var result = YearService.GetDaysCountInThisYear(year);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1970U, 0U)]
    [TestCase(1971U, 365U)]
    [TestCase(1975U, 1826U)]
    [TestCase(1980U, 3652U)]
    [TestCase(1990U, 7305U)]
    [TestCase(2000U, 10957U)]
    [TestCase(2022U, 18993U)]
    [TestCase(9999U, 2932532U)]
    public void GetDaysCountBeginningOfThisYear_ReturnsCorrectResult(uint year, uint expected)
    {
        // Act
        var result = YearService.GetDaysCountBeginningOfThisYear(year);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1969U)]
    [TestCase(10000U)]
    public void AssertIsValidPeriod_ThrowsArgumentException(uint year)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => YearService.GetDaysCountBeginningOfThisYear(year));
    }

   [TestCase(0U, 1970U, 0U)]
   [TestCase(364U, 1970U, 364U)]
   [TestCase(365U, 1971U, 0U)]
   [TestCase(730U, 1972U, 0U)]
   [TestCase(731U, 1972U, 1U)]
   [TestCase(365U + 365U + 366U, 1973U, 0U)]
   [TestCase(2932532U, 9999U, 0U)]
    public void GetYearsCountBeginningOfThisTimestamp_timestamp_zero(uint timestamp, uint expectedYear, uint expectedTimestampRemainder)
    {
        // Act
        var copyOfTimeStamp = timestamp;
        var years = YearService.ConvertTimestampToYear(ref copyOfTimeStamp);

        // Assert
        Assert.That(years, Is.EqualTo(expectedYear));
        Assert.That(copyOfTimeStamp, Is.EqualTo(expectedTimestampRemainder));
    }
}