public class PetManager
{
    private readonly List<Pet> _pets = new();
    private readonly List<CancellationTokenSource> _petCancellationTokens = new();

    public IReadOnlyList<Pet> Pets => _pets.AsReadOnly();

    public event Action<string> OnNotification;

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
        var cts = new CancellationTokenSource();
        _petCancellationTokens.Add(cts);

        pet.OnPetDied += deadPet =>
        {
            _pets.Remove(deadPet);
            OnNotification?.Invoke($"{deadPet.Name} has died!");
        };

        pet.OnNotification += message => OnNotification?.Invoke(message);

        Task.Run(() => pet.DecreaseStatsAsync(cts.Token));
    }

    public void RemovePet(Pet pet)
    {
        var index = _pets.IndexOf(pet);
        if (index >= 0)
        {
            _petCancellationTokens[index].Cancel();
            _petCancellationTokens.RemoveAt(index);
            _pets.RemoveAt(index);
        }
    }

    public void ClearAllPets()
    {
        foreach (var cts in _petCancellationTokens)
        {
            cts.Cancel();
        }
        _petCancellationTokens.Clear();
        _pets.Clear();
    }

    public void LoadFromState(GameState state)
    {
        ClearAllPets();

        foreach (var petData in state.Pets)
        {
            var pet = new Pet(petData.Name, petData.Type)
            {
                Hunger = petData.Hunger,
                Sleep = petData.Sleep,
                Fun = petData.Fun
            };
            AddPet(pet);
        }
    }
}