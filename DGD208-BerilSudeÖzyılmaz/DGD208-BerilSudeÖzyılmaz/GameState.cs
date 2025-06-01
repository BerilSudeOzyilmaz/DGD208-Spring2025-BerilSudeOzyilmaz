using System.Collections.Generic;

[Serializable]
public class GameState
{
    public List<PetData> Pets { get; set; } = new();
    public DateTime SaveTime { get; set; }
    public int TotalPlayMinutes { get; set; }
}

[Serializable]
public class PetData
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Hunger { get; set; }
    public int Sleep { get; set; }
    public int Fun { get; set; }
}