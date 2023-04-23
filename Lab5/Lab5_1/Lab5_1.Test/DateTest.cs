using Lab5_1.Dictionary;

namespace Lab5_1.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    // [TestCase(1U, Month.JANUARY, 1970U)]
    // [TestCase(31U, Month.JANUARY, 1970U)]
    // [TestCase(1U, Month.FEBRUARY, 1970U)]
    // [TestCase(28U, Month.FEBRUARY, 1970U)]
    [TestCase(29U, Month.FEBRUARY, 1972U)]
    //[TestCase(1U, Month.MARCH, 1972U)]
    public void CreateANewDateObjectByDate(uint day, Month month, uint year)
    {
        var date = new Date(day, month, year);
        var resultDate = date.GetDay();
        var resultDate1 = date.GetDay();
        var resultDate2 = date.GetDay();
        var resultMonth = date.GetMonth();
        var resultYear = date.GetYear();

        Assert.Multiple(() =>
        {
            Assert.That(resultDate, Is.EqualTo(day), "Day is not valid");
            Assert.That(resultMonth, Is.EqualTo(month), "Month is not valid");
            Assert.That(resultYear, Is.EqualTo(year), "Year is not valid");
        });
    }
}