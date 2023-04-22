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
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => YearService.GetDaysCountBeginningOfThisYear(year));
    }
}