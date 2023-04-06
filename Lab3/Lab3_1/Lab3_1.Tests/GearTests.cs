using Lab3_1.Dictionary;

namespace Lab3_1.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void Positive_GearTest_SetNeutralGear_InStopEngine()
    {
        var car = new Car();
        Assert.That(TrySwitchGear(car, Gear.NEUTRAL), Is.True);
    }

    [Test]
    public void Positive_GearTest_SetNeutralGear_NoSpeed()
    {
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear((int)Gear.NEUTRAL);
        var result = car.GetGear();
        Assert.That(result, Is.EqualTo(Gear.NEUTRAL));
    }
    
    [Test]
    public void Positive_GearTest_SetSelfGear_GearForward()
    {
        var selfGear = (int)Gear.FIRST;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(selfGear);
        car.SetSpeed(25);
        car.SetGear(selfGear);
        var result = car.GetGear();
        Assert.That(result, Is.EqualTo((Gear)selfGear));
    }
    
    [Test]
    public void Negative_GearTest_SetSelfGear_GearBackward()
    {
        const int selfGear = (int)Gear.REVERSE;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(selfGear);
        car.SetSpeed(15);
        Assert.That(TrySwitchGear(car, Gear.REVERSE), Is.False);
    }
    
    [Test]
    public void Positive_GearTest_ReverseGear_SpeedIs0()
    {
        const int carSpeed = 0;
        var car = new Car();
        car.TurnOnEngine();
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIRST), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FirstGear_SpeedIs0()
    {
        const int carSpeed = 0;
        var car = new Car();
        car.TurnOnEngine();
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIRST), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FirstGear_SwitchInSpeedIs30()
    {
        const int carSpeed = 20;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(carSpeed);
        car.SetGear(2);
        car.SetSpeed(30);
        Assert.That(TrySwitchGear(car, Gear.FIRST), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_SecondGear_SwitchInSpeedIs20()
    {
        const int carSpeed = 20;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.SECOND), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_SecondGear_SwitchInSpeedIs50()
    {
        const int carSpeed = 50;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        Assert.That(TrySwitchGear(car, Gear.SECOND), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_ThirdGear_SwitchInSpeedIs30()
    {
        const int carSpeed = 30;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.THIRD), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_ThirdGear_SwitchInSpeedIs60()
    {
        const int carSpeed = 60;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        car.SetGear(4);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.THIRD), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FourthGear_SwitchInSpeedIs40()
    {
        const int carSpeed = 40;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(2);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FOURTH), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FourthGear_SwitchInSpeedIs90()
    {
        const int carSpeed = 90;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        car.SetGear(5);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FOURTH), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FifthGear_SwitchInSpeedIs50()
    {
        const int carSpeed = 50;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(2);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIFTH), Is.True);
    }
    
    [Test]
    public void Positive_GearTest_FifthGear_SwitchInSpeedIs150()
    {
        const int carSpeed = 150;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        car.SetGear(5);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIFTH), Is.True);
    }
    // NEGATIVE
     
    [Test]
    public void Negative_GearTest_FirstGear_SpeedIs31()
    {
        const int carSpeed = 31;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(20);
        car.SetGear(2);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIRST), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_SecondGear_SwitchInSpeedIs19()
    {
        const int carSpeed = 19;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.SECOND), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_SecondGear_SwitchInSpeedIs51()
    {
        const int carSpeed = 51;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.SECOND), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_ThirdGear_SwitchInSpeedIs29()
    {
        const int carSpeed = 29;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.THIRD), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_ThirdGear_SwitchInSpeedIs61()
    {
        const int carSpeed = 61;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        car.SetGear(4);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.THIRD), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_FourthGear_SwitchInSpeedIs39()
    {
        const int carSpeed = 39;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(2);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FOURTH), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_FourthGear_SwitchInSpeedIs91()
    {
        const int carSpeed = 91;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(3);
        car.SetSpeed(50);
        car.SetGear(5);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FOURTH), Is.False);
    }
    
    [Test]
    public void Negative_GearTest_FifthGear_SwitchInSpeedIs49()
    {
        const int carSpeed = 49;
        var car = new Car();
        car.TurnOnEngine();
        car.SetGear(1);
        car.SetSpeed(30);
        car.SetGear(2);
        car.SetSpeed(carSpeed);
        Assert.That(TrySwitchGear(car, Gear.FIFTH), Is.False);
    }
 
    private static bool TrySwitchGear(ICar car, Gear newGear)
    {
        try
        {
            car.SetGear((int)newGear);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}