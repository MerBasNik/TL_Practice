namespace Fighters.Models.Races
{
    public class Human : IRace
    {
        public string Name => "Human";
        public int Damage => 15;

        public int Health => 70;

        public int Armor => 30;
    }
}
