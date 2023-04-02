namespace Lab3_1.Dictionary;

public static class CarDictionary
{
    public static readonly int MIN_GEAR_NUMBER = -1;
    public static readonly int MAX_GEAR_NUMBER = 5;
    public static readonly int CAR_SPEED_ZERO = 0;
    public static readonly int CAR_SPEED_MIN = 0;
    public static readonly int CAR_SPEED_MAX = 150;

    public static readonly Dictionary<Gear, List<int>>
        GearOnSpeedLimitsDictionary = new Dictionary<Gear, List<int>>()
        {
            {Gear.REVERSE, new List<int>(){CAR_SPEED_MIN, 20}},
            { Gear.NEUTRAL,  new List<int>(){CAR_SPEED_MIN, CAR_SPEED_MAX}},
            { Gear.FIRST,  new List<int>(){0, 30}},
            { Gear.SECOND,  new List<int>(){20, 50}},
            { Gear.THIRD,  new List<int>(){30, 60}},
            { Gear.FOURTH,  new List<int>(){40, 90}},
            { Gear.FIFTH,  new List<int>(){50, CAR_SPEED_MAX}},
        };
    
    
}