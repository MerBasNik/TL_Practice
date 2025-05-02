namespace CarFactory.Models.Engine;

public interface IEngine
{ 
    public string Type { get; }
    public int Gears { get; }
    public int MaxSpeed { get; }

    public string EngineCharactersToString();
}
