using System.Globalization;
using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters
{
    public class GameManager
    {
        private static List<IFighter> _fighters = new List<IFighter>();

        public static void StartGame()
        {
            Console.WriteLine("ИГРА FIGHTERS");
            Console.WriteLine("Проходит в виде поединка двух бойцов");

            while (true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Добавить бойца\n" +
                                  "2. Начать бой\n" +
                                  "3. Посмотреть всех бойцов\n" +
                                  "4. Выбрать бойцов для поединка из существующих и начать бой\n" +
                                  "5. Удалить бойца\n" +
                                  "6. Завершить игру");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _fighters.Add(FighterFactory.FighterBuilderWizard());
                        Console.WriteLine("Боец успешно создан\n");
                        break;
                    case "2":
                        StartBattle(_fighters);
                        break;
                    case "3":
                        GetFighters(_fighters);
                        break;
                    case "4":
                        List<IFighter> fighters = ChooseFighter(_fighters);
                        StartBattle(fighters);
                        break;
                    case "5":
                        DeleteFighter(_fighters);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("неправильный ввод данных. Попробуйте еще раз");
                        break;
                }
            }
        }
        
        public static List<IFighter> ChooseFighter(List<IFighter> fighters)
        {
            if (fighters.Count == 0)
            {
                Console.WriteLine("Бойцов пока нет");
                return null;
            }
        
            List<IFighter> _fighters = new List<IFighter>();
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Введите индекс {i} бойца: ");
                bool fighterParse = int.TryParse(Console.ReadLine(), out int fighterId);
                if (!fighterParse)
                {
                    Console.WriteLine("Некорректный ввод");
                    return null;
                }
        
                if (!(fighterId - 1 < fighters.Count))
                {
                    Console.WriteLine("Существующих бойцов пока нет");
                    return null;
                }

                _fighters.Add(fighters[fighterId - 1]);
            }

            return _fighters;
        }
        
        public static void GetFighters(List<IFighter> fighters)
        {
            if (fighters == null || fighters.Count == 0)
            {
                Console.WriteLine("Бойцов пока нет");
                return;
            }
            int counter = 1;
            foreach (IFighter fighter in fighters)
            {
                Console.WriteLine($"Боец. ID: {counter++}"); 
                fighter.PrintCharacters();
            }
        }

        private static void StartBattle(List<IFighter> fighters)
        {
            if (fighters != null && _fighters.Count >= 2)
            {
                IFighter winner = Play(fighters[0], fighters[1]);
                Console.WriteLine($"Поединок завершён. Победитель {winner.Name}");
                return;
            }
            Console.WriteLine("Для начала боя должно быть создано минимум 2 бойца. " +
                                  $"Текущее кол-во бойцов {_fighters.Count}");
        }

        private static IFighter Play(IFighter fighterA, IFighter fighterB)
        {
            int raund = 0;
            Console.WriteLine("Начальное здоровье:");
            Console.WriteLine($"{fighterA.Name}: {fighterA.GetCurrentHealth()}");
            Console.WriteLine($"{fighterB.Name}: {fighterB.GetCurrentHealth()}");
            while (true)
            {
                raund++;
                var firstFighterDamage = fighterA.CalculateDamage();
                fighterB.TakeDamage(firstFighterDamage);
                var secondFighterDamage = fighterB.CalculateDamage();
                fighterA.TakeDamage(secondFighterDamage);
                Console.WriteLine($"РАУНД {raund}");
                Console.WriteLine($"{fighterA.Name} наносит {firstFighterDamage}, получает {secondFighterDamage}");
                Console.WriteLine($"{fighterB.Name} наносит {secondFighterDamage}, получает {firstFighterDamage}");
                Console.WriteLine($"{fighterA.Name}: {fighterA.GetCurrentHealth()}");
                Console.WriteLine($"{fighterB.Name}: {fighterB.GetCurrentHealth()}");

                if (!fighterA.IsAlive())
                {
                    Console.WriteLine($"{fighterA.Name} погибает");
                    return fighterB;
                }

                if (!fighterB.IsAlive())
                {
                    Console.WriteLine($"{fighterB.Name} погибает");
                    return fighterA;
                }
            }
        }
        public static void DeleteFighter(List<IFighter> fighters)
        {
            Console.Write("Введите индекс бойца, которого хотите удалить: ");
            bool fighterParse = int.TryParse(Console.ReadLine(), out int fighterId);
            if (!fighterParse)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            if (!(fighterId - 1 < fighters.Count))
            {
                Console.WriteLine("Существующих бойцов пока нет");
                return;
            }
            fighters.Remove(fighters[fighterId - 1]);
            Console.WriteLine("Боец успешно удалён");
        }
    }
}