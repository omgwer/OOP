

namespace Lab2_4.Tests;

public class Tests
{

    [Test]
    public void Positive_UpperBoundIsZero()
    {
        var sortedSet = Program.GeneratePrimeNumberSet(0);
        Assert.That(sortedSet, Is.Empty);
    }
    
    [Test]
    public void Positive_UpperBoundDontHaveAPrimeNumbers()
    {
        var sortedSet = Program.GeneratePrimeNumberSet(1);
        Assert.That(sortedSet, Is.Empty);
    }
    
    [Test]
    public void Positive_UpperBoundIs6()
    {
        var sortedSet = Program.GeneratePrimeNumberSet(6);
        Assert.That(sortedSet.First() == 2);
        Assert.That(sortedSet.Last() == 5);
        Assert.That(sortedSet.Count == 3);
    }
    
    [Test]
    public void Positive_UpperBoundIs7_LimitValueAfter6()
    {
        var sortedSet = Program.GeneratePrimeNumberSet(7);
        Assert.That(sortedSet.First() == 2);
        Assert.That(sortedSet.Last() == 7);
        Assert.That(sortedSet.Count == 4);
    }
}