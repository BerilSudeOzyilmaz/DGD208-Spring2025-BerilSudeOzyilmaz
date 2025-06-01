using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class SaveManager
{
    private const string SaveDirectory = "Saves";
    private const string SaveFileExtension = ".petsave";

    public static void SaveGame(PetManager petManager, string slotName)
    {
        Directory.CreateDirectory(SaveDirectory);

        var state = new GameState
        {
            Pets = petManager.Pets.Select(p => new PetData
            {
                Name = p.Name,
                Type = p.Type,
                Hunger = p.Hunger,
                Sleep = p.Sleep,
                Fun = p.Fun
            }).ToList(),
            SaveTime = DateTime.Now
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(state, options);
        string savePath = Path.Combine(SaveDirectory, slotName + SaveFileExtension);
        File.WriteAllText(savePath, json);
    }

    public static GameState? LoadGame(string slotName)
    {
        string savePath = Path.Combine(SaveDirectory, slotName + SaveFileExtension);
        if (!File.Exists(savePath))
        {
            return null;
        }

        string json = File.ReadAllText(savePath);
        return JsonSerializer.Deserialize<GameState>(json);
    }

    public static List<string> GetSaveSlots()
    {
        if (!Directory.Exists(SaveDirectory))
        {
            return new List<string>();
        }

        return Directory.GetFiles(SaveDirectory, "*" + SaveFileExtension)
                       .Select(Path.GetFileNameWithoutExtension)
                       .ToList();
    }

    public static bool DeleteSave(string slotName)
    {
        string savePath = Path.Combine(SaveDirectory, slotName + SaveFileExtension);
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            return true;
        }
        return false;
    }
}