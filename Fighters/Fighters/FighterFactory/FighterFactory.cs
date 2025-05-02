using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters;

public class FighterFactory
{
    const string unexpectedInput = "Неверный ввод данных. Попробуй ещё раз";

    public static IFighter FighterBuilderWizard()
    {
        Console.WriteLine("СОЗДАНИЕ БОЙЦА");
        Console.Write("введите имя вашего боца: ");
        string name = Console.ReadLine();
        IRace race = getRace();
        IFighterClass fighterClass = getFighterClass();
        IArmor armor = getArmor();
        IWeapon weapon = getWeapon();

        Fighter fighter = new Fighter(
            name,
            race,
            fighterClass,
            weapon,
            armor
        );

        return fighter;
    }

    private static IRace getRace()
    {
        IRace race = null;
        Console.WriteLine("выберите расу");
        Console.WriteLine("1. Гномы\n" +
                          "2. Эльфы\n" +
                          "3. Люди\n" +
                          "4. Назгулы\n" +
                          "5. Орки");
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    race = new Dwarves();
                    break;
                case "2":
                    race = new Elves();
                    break;
                case "3":
                    race = new Human();
                    break;
                case "4":
                    race = new Nasguls();
                    break;
                case "5":
                    race = new Orcs();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }

        return race;
    }

    private static IFighterClass getFighterClass()
    {
        IFighterClass fighterClass = null;
        Console.WriteLine("выберите класс героя");
        Console.WriteLine("1. Маг\n" +
                          "2. Воин\n" +
                          "3. Лучник\n" +
                          "4. Разбойник");
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    fighterClass = new Mage();
                    break;
                case "2":
                    fighterClass = new Soldier();
                    break;
                case "3":
                    fighterClass = new Archer();
                    break;
                case "4":
                    fighterClass = new Rogue();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }

        return fighterClass;
    }

    private static IArmor getArmor()
    {
        IArmor armor = null;
        Console.WriteLine("выберите защиту");
        Console.WriteLine("1. Ботинки\n" +
                          "2. Шлем\n" +
                          "3. Нагрудник\n" +
                          "4. Кольчуга\n" +
                          "5. Щит\n" +
                          "6. Штаны\n" +
                          "7. Без брони");
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    armor = new Boots();
                    break;
                case "2":
                    armor = new Helmet();
                    break;
                case "3":
                    armor = new Breastplate();
                    break;
                case "4":
                    armor = new ChainMail();
                    break;
                case "5":
                    armor = new Shield();
                    break;
                case "6":
                    armor = new Pants();
                    break;
                case "7":
                    armor = new NoArmor();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }

        return armor;
    }

    private static IWeapon getWeapon()
    {
        IWeapon weapon = null;
        Console.WriteLine("выберите оружие");
        Console.WriteLine("1. Топор\n" +
                          "2. Лук\n" +
                          "3. Дубинка\n" +
                          "4. Кинжал\n" +
                          "5. Меч");
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    weapon = new Axe();
                    break;
                case "2":
                    weapon = new Bow();
                    break;
                case "3":
                    weapon = new Cudgel();
                    break;
                case "4":
                    weapon = new Dagger();
                    break;
                case "5":
                    weapon = new Sword();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }

        return weapon;
    }
}