public class Pet
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Hunger { get; set; } = 50;
    public int Sleep { get; set; } = 50;
    public int Fun { get; set; } = 50;
    public bool IsAlive => Hunger > 0 && Sleep > 0 && Fun > 0;

    public event Action<Pet> OnPetDied;

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
    }

    public async Task DecreaseStatsAsync(CancellationToken cancellationToken)
    {
        while (IsAlive && !cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(5000); // Decrease stats every 5 seconds

            Hunger = Math.Max(0, Hunger - 1);
            Sleep = Math.Max(0, Sleep - 1);
            Fun = Math.Max(0, Fun - 1);

            if (!IsAlive)
            {
                OnPetDied?.Invoke(this);
            }
        }
    }

    public override string ToString()
    {
        return $"{Name} ({Type})\n" +
               $"Hunger: {Hunger}/100 | Sleep: {Sleep}/100 | Fun: {Fun}/100\n";
    }


    public string GetAsciiArt()
    {
        return this.Type switch
        {
            PetType.Dog => """
              .-"-.
             /|6 6|\
            {/(_0_)\}
             _/ ^ \_
            (/ /^\ \)-'
             ""' '""
        """, //Art by Joan Stark

            PetType.Cat => """
              ^~^  ,
             ('Y') )
             /   \/ 
            (\|||/)
        """, //Art by Hayley Jane Wakenshaw

            PetType.Bird => """
               .-.
              /'v'\
             (/   \)
            ==="="===
               |_|
        """, //Art by Morfina

            PetType.Rabbit => """
             (\_/)
            (='.'=)
            (")_(")
        """,

            _ => "No art available"
        };
    }
}