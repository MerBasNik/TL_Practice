namespace CarFactory.Models.Engine;

public class SmallEngine : IEngine
{
    public string Type => "бензиновый";
    public int Gears => 5;
    public int MaxSpeed => 150;
    public string EngineCharactersToString()
    {
        string characters = $"Тип двигателя: {Type}, кол-во передач: {Gears}, максимальная скорость: {MaxSpeed}";
        return characters;
    }
}