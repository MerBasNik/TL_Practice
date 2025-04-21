namespace Fighters.Models.Races;

public class Elves : IRace
{
    public string Name => "Elves";
    public int Damage => 5;

    public int Health => 100;

    public int Armor => 20;
}