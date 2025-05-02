namespace CarFactory.Models.Engine;

public class MediumEngine : IEngine
{
    public string Type => "дизельный";
    public int Gears => 6;
    public int MaxSpeed => 250;
    public string EngineCharactersToString()
    {
        string characters = $"Тип двигателя: {Type}, кол-во передач: {Gears}, максимальная скорость: {MaxSpeed}";
        return characters;
    }
}