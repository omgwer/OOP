using Lab5_1.Dictionary;

namespace Lab5_1.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1U, Month.JANUARY, 1970U)]
    [TestCase(31U, Month.JANUARY, 1970U)]
    [TestCase(1U, Month.FEBRUARY, 1970U)]
    [TestCase(28U, Month.FEBRUARY, 1970U)]
    [TestCase(1U, Month.MARCH, 1970U)]
    [TestCase(31U, Month.DECEMBER, 1970U)]
    [TestCase(1U, Month.DECEMBER, 1971U)]
    [TestCase(1U, Month.MARCH, 1971U)]
    [TestCase(31U, Month.DECEMBER, 9999U)]
    public void CreateANewDateObjectByDate_NotLeapYear(uint day, Month month, uint year)
    {
        var date = new Date(day, month, year);
        var resultDate = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(year), "Year is not valid");
        });
    }

    [TestCase(1U, Month.MARCH, 1972U)]
    [TestCase(29U, Month.FEBRUARY, 1972U)]
    [TestCase(1U, Month.MARCH, 1972U)]
    public void CreateANewDateObjectByDate_LeapYear(uint day, Month month, uint year)
    {
        var date = new Date(day, month, year);
        var resultDate = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(year), "Year is not valid");
        });
    }

    [TestCase(1U, Month.JANUARY, 10000U)]
    [TestCase(31U, Month.DECEMBER, 1969U)]
    [TestCase(29U, Month.FEBRUARY, 1970U)]
    [TestCase(30U, Month.FEBRUARY, 1972U)]
    public void Negative_CreateANewDateObjectByDate_NotLeapYear(uint day, Month month, uint year)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var date = new Date(day, month, year);
        });
    }

    [TestCase(1U, Month.JANUARY, 1970U)]
    [TestCase(28U, Month.FEBRUARY, 1972U)]
    [TestCase(29U, Month.FEBRUARY, 1972U)]
    [TestCase(1U, Month.MARCH, 1972U)]
    public void CreateANewDateObjectByDate_CycleRestoration(uint day, Month month, uint year)
    {
        var cycleDate = new Date(day, month, year);

        for (var i = 0; i < 10; i++)
        {
            var cycleDay = cycleDate.GetDay();
            var cycleMonth = cycleDate.GetMonth();
            var cycleYear = cycleDate.GetYear();
            cycleDate = new Date(cycleDay, cycleMonth, cycleYear);
        }

        var resultDate = cycleDate.GetDay();
        var resultMonth = cycleDate.GetMonth();
        var resultYear = cycleDate.GetYear();
        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(year), "Year is not valid");
        });
    }

    [TestCase(1U, Month.JANUARY, 1970U, 2U, Month.JANUARY, 1970U)]
    [TestCase(31U, Month.JANUARY, 1970U, 1U, Month.FEBRUARY, 1970U)]
    [TestCase(28U, Month.FEBRUARY, 1970U, 1U, Month.MARCH, 1970U)]
    [TestCase(31U, Month.DECEMBER, 1970U, 1U, Month.JANUARY, 1971U)]
    [TestCase(29U, Month.FEBRUARY, 1972U, 1U, Month.MARCH, 1972U)]
    [TestCase(30U, Month.DECEMBER, 9999U, 31U, Month.DECEMBER, 9999U)]
    public void CreateANewDateObjectByDate_OperationPlusPlusPostfix(uint day, Month month, uint year, uint expectedDay,
        Month expectedMonth, uint expectedYear)
    {
        var date = new Date(day, month, year);
        var oldDate = date++;
        var resultDate = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        var oldResultDate = oldDate.GetDay();
        var oldResultMonth = oldDate.GetMonth();
        var oldResultYear = oldDate.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(expectedDay), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(expectedMonth), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(expectedYear), "Year is not valid");
            Assert.That(oldResultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(oldResultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(oldResultYear, Is.EqualTo(year), "Year is not valid");
        });
    }

    [TestCase(1U, Month.JANUARY, 1970U, 2U, Month.JANUARY, 1970U)]
    [TestCase(31U, Month.JANUARY, 1970U, 1U, Month.FEBRUARY, 1970U)]
    [TestCase(28U, Month.FEBRUARY, 1970U, 1U, Month.MARCH, 1970U)]
    [TestCase(31U, Month.DECEMBER, 1970U, 1U, Month.JANUARY, 1971U)]
    [TestCase(29U, Month.FEBRUARY, 1972U, 1U, Month.MARCH, 1972U)]
    [TestCase(30U, Month.DECEMBER, 9999U, 31U, Month.DECEMBER, 9999U)]
    public void CreateANewDateObjectByDate_OperationPlusPlusPrefix(uint day, Month month, uint year, uint expectedDay,
        Month expectedMonth, uint expectedYear)
    {
        var date = new Date(day, month, year);
        var oldDate = ++date;
        var resultDate = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        var oldResultDate = oldDate.GetDay();
        var oldResultMonth = oldDate.GetMonth();
        var oldResultYear = oldDate.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(expectedDay), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(expectedMonth), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(expectedYear), "Year is not valid");
            Assert.That(oldResultDate, Is.EqualTo(expectedDay), "Day is not valid");
            Assert.That(oldResultMonth, Is.EqualTo(expectedMonth), "Month is not valid");
            Assert.That(oldResultYear, Is.EqualTo(expectedYear), "Year is not valid");
        });
    }

    [TestCase(31U, Month.DECEMBER, 9999U)]
    public void CreateANewDateObjectByDate_OperationPlusPlusPrefix_OverflowError(uint day, Month month, uint year)
    {
        var date = new Date(day, month, year);
        var oldDatePostfix = date++;
        var oldDatePrefix = ++date;
        var resultDate = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        var oldResultDatePostfix = oldDatePostfix.GetDay();
        var oldResultMonthPostfix = oldDatePostfix.GetMonth();
        var oldResultYearPostfix = oldDatePostfix.GetYear();
        
        var oldResultDatePrefix = oldDatePrefix.GetDay();
        var oldResultMonthPrefix = oldDatePrefix.GetMonth();
        var oldResultYearPrefix = oldDatePrefix.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(year), "Year is not valid");
            Assert.That(oldResultDatePostfix, Is.EqualTo(day), "Day is not valid");
            Assert.That(oldResultMonthPostfix, Is.EqualTo(month), "Month is not valid");
            Assert.That(oldResultYearPostfix, Is.EqualTo(year), "Year is not valid");
            Assert.That(oldResultDatePrefix, Is.EqualTo(day), "Day is not valid");
            Assert.That(oldResultMonthPrefix, Is.EqualTo(month), "Month is not valid");
            Assert.That(oldResultYearPrefix, Is.EqualTo(year), "Year is not valid");
        });
    }
}