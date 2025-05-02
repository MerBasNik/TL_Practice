namespace CarFactory.Models.Engine;

public class GreatEngine : IEngine
{
    public string Type => "бензиновый";
    public int Gears => 7;
    public int MaxSpeed => 400;
    public string EngineCharactersToString()
    {
        string characters = $"Тип двигателя: {Type}, кол-во передач: {Gears}, максимальная скорость: {MaxSpeed}";
        return characters;
    }
}