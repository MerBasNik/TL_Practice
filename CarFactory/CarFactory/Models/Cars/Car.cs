using CarFactory.Models.BodyType;
using CarFactory.Models.Brand;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Cars;

public class Car : ICar
{
    private readonly IBodyType _bodyType;
    private readonly IBrand _brand;
    private readonly IEngine _engine;
    private readonly ITransmission _transmission;
    private readonly IColor _color;
    
    public Car(IBrand brand, IBodyType bodyType, IColor color, IEngine engine, ITransmission transmission)
    {
        _brand = brand;
        _bodyType = bodyType;
        _color = color;
        _engine = engine;
        _transmission = transmission;
    }

    public override void PrintCarConfigs()
    {
        Console.WriteLine("Конфигурация автомобиля\n" +
                          $"Марка: {_brand.Brand}\n" +
                          $"Цвет: {_color.Color}\n" +
                          $"Тип кузова: {_bodyType.BodyType}\n" +
                          $"Двигатель: {_engine.EngineCharactersToString()}\n" +
                          $"Коробка передач: {_transmission.TransmissionType}");
    }
}