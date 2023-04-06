using System.Text;
using Lab3_1.Dictionary;

namespace Lab3_1;

public interface ICar
{
    public bool IsTurnedOn();
    public Direction GetDirection();
    public int GetSpeed();
    public Gear GetGear();
    public void TurnOnEngine();
    public void TurnOffEngine();
    public void SetGear(int gear);
    public void SetSpeed(int speed);
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
        _speed = CarDictionary.CAR_SPEED_MIN;//TODO: const
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

    public void TurnOnEngine()
    {
        if (!_isTurnedOn) // нет смсла проверять возможность запуска, так как заглушить машину можно только при определенных условиях
            _isTurnedOn = true;
    }

    public void TurnOffEngine()
    {
        if (!_isTurnedOn)
            return;
        var exceptionTextBuilder = new StringBuilder();
        var canTurnOffEngine = true;//TODO: убрать один глагол
        if (_direction != Direction.STANDING_STILL)
        {
            exceptionTextBuilder.Append("Car don`t standing still \\n");
            canTurnOffEngine = false;
        }

        if (_speed != CarDictionary.CAR_SPEED_ZERO)
        {
            exceptionTextBuilder.Append("Engine stop possible at zero speed \\n");
            canTurnOffEngine = false;
        }

        if (_gear != Gear.NEUTRAL)
        {
            exceptionTextBuilder.Append("Engine stop possible at gearbox is neutral \\n");
            canTurnOffEngine = false;
        }

        if (!canTurnOffEngine) throw new CarException(exceptionTextBuilder.ToString());

        _isTurnedOn = false;
    }

    public void SetGear(int gear)
    {
        if (gear < CarDictionary.MIN_GEAR_NUMBER | gear > CarDictionary.MAX_GEAR_NUMBER)
        {
            throw new CarException("Gear value in not valid!");
        }
        if ((Gear)gear != Gear.NEUTRAL)
            CheckIsTurnedOnEngine();

        Gear newGear = (Gear)gear; //int newGearInt = (int)newGear;
        var exceptionTextBuilder = new StringBuilder();
        var canSwitchGear = true;// TODO: rename

        if (newGear == Gear.REVERSE)
        {
            if (_speed != CarDictionary.CAR_SPEED_ZERO)
            {
                exceptionTextBuilder.Append("Can`t set reverse gear if the car is moving   \\n");
                canSwitchGear = false;
            }
        } else if (newGear == Gear.FIRST)
        {
            if (_direction == Direction.BACKWARD)
            {
                exceptionTextBuilder.Append("Can`t set first gear if the car is moving backward   \\n");
                canSwitchGear = false;
            }
            else if (_speed > CarDictionary.GearOnSpeedLimitsDictionary[newGear].Last())//TODO: const
            {
                exceptionTextBuilder.Append($"Can`t set first gear. Current speed  = {_speed}  \\n");
                canSwitchGear = false;
            }
        }
        else if (newGear != Gear.NEUTRAL)
        {
            if (_direction != Direction.FORWARD)
            {
                exceptionTextBuilder.Append("Can`t set second gear if the car dont moving forward  \\n");
                canSwitchGear = false;
            }
            else if (_speed < CarDictionary.GearOnSpeedLimitsDictionary[newGear].First() | _speed > CarDictionary.GearOnSpeedLimitsDictionary[newGear].Last())
            {
                exceptionTextBuilder.Append($"Can`t set second gear. Current speed  = {_speed}  \\n");
                canSwitchGear = false;
            }
        }

        if (!canSwitchGear) throw new CarException(exceptionTextBuilder.ToString());
        _gear = newGear;
    }

    public void SetSpeed(int speed)
    {
        if (speed < CarDictionary.CAR_SPEED_MIN | speed > CarDictionary.CAR_SPEED_MAX)
            throw new CarException("Input speed is not valid!");

        CheckIsTurnedOnEngine();
        if (_speed == speed)
            return;//TODO: use void
        
        var exceptionTextBuilder = new StringBuilder();
        var canSetSpeed = true;//TODO: rename
        if (_gear == Gear.NEUTRAL & speed > _speed)//TODO: упросить
        {
            exceptionTextBuilder.Append($"Can`t set new speed. No acceleration in neutral gear   \\n");
            canSetSpeed = false;
        }

        var speedLimitsInGear = CarDictionary.GearOnSpeedLimitsDictionary[_gear];
        if (speed < speedLimitsInGear.First() | speed > speedLimitsInGear.Last())  
        {
            exceptionTextBuilder.Append($"Can`t set new speed. Gear {(int) _gear} not suitable for speed = {speed}   \\n");
            canSetSpeed = false;
        }

        if (!canSetSpeed) throw new CarException(exceptionTextBuilder.ToString());
        _speed = speed;
        SyncDirection();
    }

    private void SyncDirection()
    {
        if (_speed == CarDictionary.CAR_SPEED_ZERO & _direction != Direction.STANDING_STILL)
            _direction = Direction.STANDING_STILL;
        else if (_speed != CarDictionary.CAR_SPEED_ZERO & _gear == Gear.NEUTRAL)
            return;
        else if (_speed > CarDictionary.CAR_SPEED_ZERO & _gear == Gear.REVERSE & _direction != Direction.BACKWARD)
            _direction = Direction.BACKWARD;
        else if (_speed > CarDictionary.CAR_SPEED_ZERO & _gear != Gear.REVERSE & _direction != Direction.FORWARD)
            _direction = Direction.FORWARD;
    }

    private void CheckIsTurnedOnEngine()//TODO: rename
    {
        if (!_isTurnedOn)
            throw new CarException("Engine is turned off!");
    }
}