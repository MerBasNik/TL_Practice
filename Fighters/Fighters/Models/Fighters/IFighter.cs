using Fighters.Models.Armors;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }
        public void PrintCharacters();
        public int GetMaxHealth();
        public int GetMaxArmor();
        public int GetCurrentHealth();
        public int GetCurrentArmor();
        
        public int CalculateDamage();
        public int TakeDamage(int damage);
    }
}