using CarFactory.Models.Cars;
using CarFactory.Models.Engine;

namespace CarFactory;

public class CarManager
{
    private static List<ICar> _cars = new List<ICar>();
    
    public static void Start()
    {
        Console.WriteLine("ИГРА ПО СОЗДАНИЮ АВТОМОБИЛЯ");
        while (true)
        {
            Console.WriteLine("Выберите команду:");
            Console.WriteLine("1. Создать автомобиль\n" +
                              "2. Посмотреть все авто\n" +
                              "3. Удалить автомобиль\n" +
                              "4. Завершить игру");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ICar car = CarFactory.CreateCar();
                    _cars.Add(car);
                    Console.WriteLine("Автомобиль успешно создан");
                    car.PrintCarConfigs();
                    break;
                case "2":
                    ShowAllCars(_cars);
                    break;
                case "3":
                    DeleteAuto(_cars);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("неправильный ввод данных. Попробуйте еще раз");
                    break;
            }
        }
    }

    private static void DeleteAuto(List<ICar> cars)
    {
        Console.Write("Введите индекс автомобиля, который хотите удалить: ");
        bool carIdParse = int.TryParse(Console.ReadLine(), out int carId);
        if (!carIdParse)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }
        if (!(carId - 1 < cars.Count))
        {
            Console.WriteLine("Существующих авто пока нет");
            return;
        }
        cars.Remove(cars[carId - 1]);
        Console.WriteLine("Авто успешно удалено");
    }

    private static void ShowAllCars(List<ICar> cars)
    {
        if (cars == null || cars.Count == 0)
        {
            Console.WriteLine("Автомобилей пока нет");
        }
        int counter = 1;
        foreach (ICar car in cars)
        {
            car.PrintCarConfigs();
        }
    }
}