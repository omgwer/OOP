// See https://aka.ms/new-console-template for more information

using Lab3_1.Dictionary;

namespace Lab3_1
{
    internal class Program
    {
        private static bool _isRun = true;

        public static void Main(string[] args)
        {
            var car = new Car();
            PrintHelp();
            while (_isRun)
            {//TODO: добавить возможность переключения на нейтраль при выключенном двигателе
                Console.Write("Write your command : ");
                var command = ParseCommandLine();
                if (command == null)
                {
                    Console.WriteLine("Invalid command");
                    continue;
                }

                RunCarCommand(command, car);
            }
        }

        private static void GetCarInfo(ICar car)
        {
            Console.WriteLine($"Gear : {(int)car.GetGear()}");
            Console.WriteLine($"Speed : {car.GetSpeed()}");
            var isTurnedOn = car.IsTurnedOn() == true ? "On" : "Off";
            Console.WriteLine($"Engine : {isTurnedOn}");
            var direction = car.GetDirection() switch
            {
                Direction.FORWARD => "Forward",
                Direction.BACKWARD => "Backward",
                Direction.STANDING_STILL => "Standing still",
                _ => "Error"
            };
            Console.WriteLine($"Direction : {direction}");
        }

        private static void PrintHelp()
        {
            Console.WriteLine($"Commands : ");
            Console.WriteLine($"   - Info ");
            Console.WriteLine($"   - EngineOn ");
            Console.WriteLine($"   - EngineOff ");
            Console.WriteLine($"   - SetGear <Gear> ");
            Console.WriteLine($"   - SetSpeed <Speed> ");
            Console.WriteLine($"   - Exit ");
            Console.WriteLine($"   - Help ");
        }

        private static void RunCarCommand(string[] command, ICar car)
        {
            try
            {
                switch (command[0])
                {
                    case "Info":
                        GetCarInfo(car);
                        break;
                    case "EngineOn":
                        car.TurnOnEngine();
                        break;
                    case "EngineOff":
                        car.TurnOffEngine();
                        break;
                    case "SetGear":
                        int gear = int.Parse(command[1]);
                        car.SetGear(gear);
                        break;
                    case "SetSpeed":
                        int speed = int.Parse(command[1]);
                        car.SetSpeed(speed);
                        break;
                    case "Exit":
                        _isRun = false;
                        break;
                    case "Help":
                        PrintHelp();
                        break;
                    default:
                        PrintHelp();
                        break;
                }
            }
            catch (CarException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                _isRun = false;
            }
        }

        private static string[]? ParseCommandLine()
        {
            var command = Console.ReadLine()!.Split(" ");
            if (command.Length == 0 | command.Length > 2)
                return null;
            if (command[0] == "SetGear" | command[0] == "SetSpeed")
            {
                if (command.Length == 1)
                    return null;
                try
                {
                    int.Parse(command[1]);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return command;
        }
    }
}