namespace Fighters.Models.Races;

public class Dwarves :  IRace
{
    public string Name => "Dwarves";
    public int Damage => 10;

    public int Health => 90;

    public int Armor => 25;
}