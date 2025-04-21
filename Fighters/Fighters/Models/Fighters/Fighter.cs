using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public class Fighter : IFighter
{
    private readonly string _name;
    private readonly IRace _race;
    private readonly IWeapon _weapon;
    private readonly IArmor _armor;
    private readonly IFighterClass _fighterClass;
    private readonly int _currentArmor;
    private int _currentHealth;
    private int _currentDamage;
    private const double _maxDamage = 1.2;
    private const double _minDamage = 0.8;
    private double _criticalHitRatio = 0.2;

    public Fighter(string name, IRace race, IFighterClass fighterClass, IWeapon weapon, IArmor armor)
    {
        _name = name;
        _race = race;
        _weapon = weapon;
        _armor = armor;
        _fighterClass = fighterClass;
        _currentArmor = GetMaxArmor();
        _currentHealth = GetMaxHealth();
    }
    
    public string Name => _name;
    public int GetMaxHealth() => _race.Health + _fighterClass.Health;
    public int GetMaxArmor() => _race.Armor + _armor.Armor;
    public int GetCurrentHealth() => _currentHealth;
    public int GetCurrentArmor() => _currentArmor;
    public int GetCurrentDamage() => _race.Damage + _fighterClass.Damage + _weapon.Damage;
    public int CalculateDamage()
    {
        double damageRatio = _minDamage + (Random.Shared.NextDouble() * (_maxDamage - _minDamage));
        int damage = (int)(damageRatio * GetCurrentDamage());
        damage = (Random.Shared.NextDouble() >= _criticalHitRatio) ? damage * 2 : damage;
        return damage;
    }

    public List<string> GetCharacters()
    {
        List<string> characters = new List<string>
        {
            _race.Name,
            _fighterClass.Name,
            _armor.Name,
            _weapon.Name,
        };
        return characters;
    }
    public int TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Math.Max(_currentHealth, 0);
        return _currentHealth;
    }
}