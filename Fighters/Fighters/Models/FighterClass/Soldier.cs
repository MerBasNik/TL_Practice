namespace Fighters.Models.FighterClass;

public class Soldier : IFighterClass
{
    public string Name => "Soldier";
    public int Damage => 15;
    public int Health => 60;
}