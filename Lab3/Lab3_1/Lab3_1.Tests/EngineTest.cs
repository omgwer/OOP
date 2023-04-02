namespace Lab3_1.Tests;

public class EngineTest
{
    [Test]
    public void Positive_TurnOnDefaultCar()
    {
        var car = new Car();
        Assert.That(TryTurnOnEngine(car), Is.True);
    }
    
    [Test]
    public void Positive_TurnOffDefaultCar()
    {
        var car = new Car();
        Assert.That(TryTurnOffEngine(car), Is.True);
    }
    
    [Test]
    public void Positive_TurnOffCar_AfterSetGear()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetGear(0);
        Assert.That(TryTurnOffEngine(car), Is.True);
    }
    
    [Test]
    public void Positive_TurnOffCar_AfterSetSpeed()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(15);
        car.SetGear(0);
        car.SetSpeed(0);
        Assert.That(TryTurnOffEngine(car), Is.True);
    }
    
    [Test]
    public void Negative_TurnOffCar_IfRunForward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(15);
        Assert.That(TryTurnOffEngine(car), Is.False);
    }
    
    [Test]
    public void Negative_TurnOffCar_IfRunBackward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(15);
        Assert.That(TryTurnOffEngine(car), Is.False);
    }
    
    [Test]
    public void Negative_TurnOffCar_IfSetGearBackward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        Assert.That(TryTurnOffEngine(car), Is.False);
    }
    
    [Test]
    public void Negative_TurnOffCar_IfSetGearForward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        Assert.That(TryTurnOffEngine(car), Is.False);
    }
    
    private static bool TryTurnOnEngine(ICar car)
    {
        try
        {
            car.TurnOnEngine();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
    
    private static bool TryTurnOffEngine(ICar car)
    {
        try
        {
            car.TurnOffEngine();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}