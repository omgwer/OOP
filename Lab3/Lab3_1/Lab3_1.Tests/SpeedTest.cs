namespace Lab3_1.Tests;

public class SpeedTest
{
    [Test]
    public void Positive_SpeedTest_NeutralGear_SetSpeedIs0()
    {
        var newSpeed = 0;
        var car = new Car();
        car.TurnOnEngine();
        Assert.That(TrySetSpeed(car, newSpeed), Is.True);
    }

    [Test]
    public void Negative_SpeedTest_NeutralGear_SetSpeedIs1()
    {
        var newSpeed = 1;
        var car = new Car();
        car.TurnOnEngine();
        Assert.That(TrySetSpeed(car, newSpeed), Is.False);
    }
    
    [Test]
    public void Negative_SpeedTest_NeutralGear_SetSpeedIsMinus1()
    {
        var newSpeed = -1;
        var car = new Car();
        car.TurnOnEngine();
        Assert.That(TrySetSpeed(car, newSpeed), Is.False);
    }
    
    [Test]
    public void Positive_SpeedTest_ReverseGear_SetSpeedIs0()
    {
        var newSpeed = 0;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        Assert.That(TrySetSpeed(car, newSpeed), Is.True);
    }
    
    [Test]
    public void Positive_SpeedTest_ReverseGear_SetSpeedIs20()
    {
        var newSpeed = 20;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        Assert.That(TrySetSpeed(car, newSpeed), Is.True);
    }
    
    [Test]
    public void Positive_SpeedTest_ReverseGear_SetSpeedIs21()
    {
        var newSpeed = 21;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        Assert.That(TrySetSpeed(car, newSpeed), Is.False);
    }


    private static bool TrySetSpeed(ICar car, int newSpeed)
    {
        try
        {
            car.SetSpeed(newSpeed);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}