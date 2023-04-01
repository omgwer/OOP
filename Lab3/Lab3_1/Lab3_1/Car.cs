using System.Text;
using Lab3_1.Dictionary;

namespace Lab3_1;

public interface ICar
{
    public bool IsTurnedOn();
    public Direction GetDirection();
    public int GetSpeed();
    public Gear GetGear();
    public bool TurnOnEngine();
    public bool TurnOffEngine();
    public bool SetGear(int gear);
    public bool SetSpeed(int speed);
}

public class Car : ICar
{
    private bool _isTurnedOn;
    private Direction _direction;
    private int _speed;
    private Gear _gear;

    public Car()
    {
        _isTurnedOn = false;
        _direction = Direction.STANDING_STILL;
        _speed = 0;
        _gear = Gear.NEUTRAL;
    }

    public bool IsTurnedOn()
    {
        return _isTurnedOn;
    }

    public Direction GetDirection()
    {
        return _direction;
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public Gear GetGear()
    {
        return _gear;
    }

    public bool TurnOnEngine()
    {
        if (!_isTurnedOn) // нет смсла проверять возможность зазпуска, так как заглушить машину можно только при определенных условиях
            _isTurnedOn = true;
        return true;
    }

    public bool TurnOffEngine()
    {
        if (!_isTurnedOn)
            return true;
        var exceptionTextBuilder = new StringBuilder();
        var isCanTurnOffEngine = true;
        if (_direction != Direction.STANDING_STILL)
        {
            exceptionTextBuilder.Append("Car don`t standing still \\n");
            isCanTurnOffEngine = false;
        }

        if (_speed != 0)
        {
            exceptionTextBuilder.Append("Engine stop possible at zero speed \\n");
            isCanTurnOffEngine = false;
        }

        if (_gear != Gear.NEUTRAL)
        {
            exceptionTextBuilder.Append("Engine stop possible at gearbox is neutral \\n");
            isCanTurnOffEngine = false;
        }

        if (!isCanTurnOffEngine) throw new Exception(exceptionTextBuilder.ToString());

        _isTurnedOn = false;
        return true;
    }

    public bool SetGear(int gear)
    {
        if (gear < CarDictionary.MIN_GEAR_NUMBER | gear > CarDictionary.MAX_GEAR_NUMBER)
        {
            throw new ArgumentException("Gear value in not valid!");
        }

        Gear newGear = (Gear)gear; //int newGearInt = (int)newGear;
        var exceptionTextBuilder = new StringBuilder();
        var isCanSwitchGear = true;

        switch (newGear)
        {
            case Gear.REVERSE:
                if (_speed != CarDictionary.CAR_SPEED_ZERO)
                {
                    exceptionTextBuilder.Append("Can`t set reverse gear if the car is moving   \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.FIRST:
                if (_direction == Direction.BACKWARD)
                {
                    exceptionTextBuilder.Append("Can`t set first gear if the car is moving backward   \\n");
                    isCanSwitchGear = false;
                }
                else if (_speed > 30)
                {
                    exceptionTextBuilder.Append($"Can`t set first gear. Current speed  = {_speed}  \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.SECOND:
                if (_direction != Direction.FORWARD)
                {
                    exceptionTextBuilder.Append("Can`t set second gear if the car dont moving forward  \\n");
                    isCanSwitchGear = false;
                }
                else if (_speed < 20 | _speed > 50)
                {
                    exceptionTextBuilder.Append($"Can`t set second gear. Current speed  = {_speed}  \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.THIRD:
                if (_direction != Direction.FORWARD)
                {
                    exceptionTextBuilder.Append("Can`t set third gear if the car dont moving forward  \\n");
                    isCanSwitchGear = false;
                }
                else if (_speed < 30 | _speed > 60)
                {
                    exceptionTextBuilder.Append($"Can`t set third gear. Current speed  = {_speed}  \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.FOURTH:
                if (_direction != Direction.FORWARD)
                {
                    exceptionTextBuilder.Append("Can`t set fourth gear if the car dont moving forward  \\n");
                    isCanSwitchGear = false;
                }
                else if (_speed < 40 | _speed > 90)
                {
                    exceptionTextBuilder.Append($"Can`t set fourth gear. Current speed  = {_speed}  \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.FIFTH:
                if (_direction != Direction.FORWARD)
                {
                    exceptionTextBuilder.Append("Can`t set fifth gear if the car dont moving forward  \\n");
                    isCanSwitchGear = false;
                }
                else if (_speed < 50 | _speed > 150)
                {
                    exceptionTextBuilder.Append($"Can`t set fifth gear. Current speed  = {_speed}  \\n");
                    isCanSwitchGear = false;
                }

                break;
            case Gear.NEUTRAL:
                break;
        }

        if (!isCanSwitchGear) throw new Exception(exceptionTextBuilder.ToString());
        _gear = newGear;
        return true;
    }

    public bool SetSpeed(int speed)
    {
        if (speed < CarDictionary.CAR_SPEED_MIN | speed > CarDictionary.CAR_SPEED_MAX)
            throw new ArgumentException("Input speed is not valid!");
        var exceptionTextBuilder = new StringBuilder();
        var isCanSetSpeed = true;
        if (_gear == Gear.NEUTRAL & (speed - _speed) > CarDictionary.CAR_SPEED_ZERO)
        {
            exceptionTextBuilder.Append($"Can`t set new speed. No acceleration in neutral gear   \\n");
            isCanSetSpeed = false;
        }

        var speedLimitsInGear = CarDictionary.GearOnSpeedLimitsDictionary[_gear];
        if (speed < speedLimitsInGear.First() | speed > speedLimitsInGear.Last())  
        {
            exceptionTextBuilder.Append($"Can`t set new speed. Gear {(int) _gear} not suitable for speed = {speed}   \\n");
            isCanSetSpeed = false;
        }

        if (!isCanSetSpeed) throw new Exception(exceptionTextBuilder.ToString());
        _speed = speed;
        syncDirection();
        return true;
    }

    private void syncDirection()
    {
        if (_speed == 0 & _direction != Direction.STANDING_STILL)
            _direction = Direction.STANDING_STILL;
        else if (_speed > 0 & _gear == Gear.REVERSE & _direction != Direction.BACKWARD)
            _direction = Direction.BACKWARD;
        else if (_speed > 0 & _gear != Gear.REVERSE & _direction != Direction.FORWARD)
            _direction = Direction.FORWARD;
    }
}