using Lab3_1.Dictionary;

namespace Lab3_1.Tests;

public class DirectionTest
{
    [Test]
    public void Positive_DirectionTest_DefaultCar()
    {
        var car = new Car();
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.STANDING_STILL));
    }
    
    [Test]
    public void Positive_DirectionTest_RunForward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(1);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.FORWARD));
    }
    
    [Test]
    public void Positive_DirectionTest_RunBackward()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(1);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.BACKWARD));
    }
    
    [Test]
    public void Positive_DirectionTest_RunBackwardAndStop()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(1);
        car.SetSpeed(0);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.STANDING_STILL));
    }
    
    [Test]
    public void Positive_DirectionTest_RunForwardAndStop()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(1);
        car.SetSpeed(0);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.STANDING_STILL));
    }
    
    [Test]
    public void Positive_DirectionTest_RunForwardSetNeutralAndSlowDown()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(15);
        car.SetGear(0);
        car.SetSpeed(5);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.FORWARD));
    }
    
    [Test]
    public void Positive_DirectionTest_RunBackwardSetNeutralAndSlowDown()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(-1);
        car.SetSpeed(15);
        car.SetGear(0);
        car.SetSpeed(5);
        Assert.That(car.GetDirection(), Is.EqualTo(Direction.BACKWARD));
    }
}