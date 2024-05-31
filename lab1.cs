using System;

public interface ITransportable
    {
        void Load();
        void Unload();
    }
public interface IRefuelable
{
    void Refuel();
}

public abstract class InfantryUnit : ITransportable
{
    protected string PersonalWeapon { get; set; }
    protected int FootSpeed { get; set; }
    protected int Health { get; set; }

    public InfantryUnit(int health){}

    public void Load(){}

    public void Unload(){}
}

public abstract class Vehicle : IRefuelable
{
    protected int FuelReserve { get; set; }
    protected string MainWeapon { get; set; }
    protected int Speed { get; set; }

    public void Refuel(){}
}

public class Soldier : InfantryUnit
{
    public Soldier(int health) : base(health){}
}

public class MachineGunTeam : InfantryUnit
{
    public string MainWeapon { get; set; }
    public MachineGunTeam(int health) : base(health){}
}

public class Tank : Vehicle
{
    public string SecondaryWeapon { get; set; }
}

public class Plane : Vehicle
{
    public int DetectionRange { get; set; }
}

public class Helicopter : Vehicle
{
    public int DetectionRange { get; set; }
    public int Troops { get; set; }
}

public class Howitzer : Vehicle
{
    public int StrikeRange { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        int health = ReadInt("Введите здоровье солдата: ", minValue: 1, maxValue: 100);
        Soldier soldier = new Soldier(health);
        Console.WriteLine("Солдат создан!");
    }

    static int ReadInt(string prompt, int minValue, int maxValue)
    {
        int result;
        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                if (result >= minValue && result <= maxValue)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Пожалуйста, введите значение между {minValue} и {maxValue}.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод, пожалуйста, введите число.");
            }
        } while (true);
    }
}