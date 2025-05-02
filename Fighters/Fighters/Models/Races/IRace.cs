namespace Fighters.Models.Races
{
    public interface IRace
    {
        string Name { get; }
        public int Damage { get; }
        public int Health { get; }
        public int Armor { get; }
    }
}