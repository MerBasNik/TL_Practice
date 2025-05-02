using CarFactory.Models.BodyType;
using CarFactory.Models.Brand;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory;

public class CarFactory
{
    const string unexpectedInput = "Неверный ввод данных. Попробуй ещё раз";
    
    public static ICar CreateCar()
    {
        Console.WriteLine("СОЗДАНИЕ АВТОМОБИЛЯ МЕЧТЫ");
        IBrand brand = getBrand();
        IBodyType bodyType = getBodytype();
        IColor  color = getColor();
        IEngine engine = getEngine();
        ITransmission transmission = getTransmission();
        
        Car car = new Car(brand, bodyType, color, engine, transmission);
        
        return car;
    }

    private static ITransmission getTransmission()
    {
        Console.WriteLine("Выберите коробку передач");
        Console.WriteLine("1. Автоматическая\n" +
                          "2. Механическая\n" +
                          "3. Робот\n" +
                          "4. Вариатор");
        ITransmission transmission = null;
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    transmission = new Automatic();
                    break;
                case "2":
                    transmission = new Manual();
                    break;
                case "3":
                    transmission = new Robotic();
                    break;
                case "4":
                    transmission = new Cvt();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }
        return transmission;
    }

    private static IEngine getEngine()
    {
        Console.WriteLine("Выберите тип двигателя");
        Console.WriteLine("1. Слабенький\n" +
                          "2. Средний\n" +
                          "3. Самый мощный");
        IEngine engine = null;
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    engine = new SmallEngine();
                    break;
                case "2":
                    engine = new MediumEngine();
                    break;
                case "3":
                    engine = new GreatEngine();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }
        return engine;
    }

    private static IColor getColor()
    {
        Console.WriteLine("Выберите тип кузова");
        Console.WriteLine("1. Белый\n" +
                          "2. Черный\n" +
                          "3. Красный\n" +
                          "4. Серый\n" +
                          "5. Синий");
        IColor color = null;
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    color = new WhiteColor();
                    break;
                case "2":
                    color = new BlackColor();
                    break;
                case "3":
                    color = new RedColor();
                    break;
                case "4":
                    color = new GrayColor();
                    break;
                case "5":
                    color = new BlueColor();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }
        return color;
    }

    private static IBodyType getBodytype()
    {
        Console.WriteLine("Выберите тип кузова");
        Console.WriteLine("1. Седан\n" +
                          "2. Купе\n" +
                          "3. Хэтчбэк");
        IBodyType bodyType = null;
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bodyType = new Sedan();
                    break;
                case "2":
                    bodyType = new Coupe();
                    break;
                case "3":
                    bodyType = new Hatchback();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }
        return bodyType;
    }

    private static IBrand getBrand()
    {
        Console.WriteLine("Выберите марку автомобиля");
        Console.WriteLine("1. Mercedes\n" +
                          "2. BMW\n" +
                          "3. Toyota\n" +
                          "4. Audi\n" +
                          "5. Lada");
        IBrand brand = null;
        bool isValidInput = false;
        while (!isValidInput)
        {
            isValidInput = true;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    brand = new Mercedes();
                    break;
                case "2":
                    brand = new Bmw();
                    break;
                case "3":
                    brand = new Toyota();
                    break;
                case "4":
                    brand = new Audi();
                    break;
                case "5":
                    brand = new Lada();
                    break;
                default:
                    Console.WriteLine(unexpectedInput);
                    isValidInput = false;
                    break;
            }
        }

        return brand;
    }
}