namespace Fighters.Models.Races;

public class Orcs : IRace
{
    public string Name => "Orcs";
    public int Damage => 15;

    public int Health => 80;

    public int Armor => 10;
}