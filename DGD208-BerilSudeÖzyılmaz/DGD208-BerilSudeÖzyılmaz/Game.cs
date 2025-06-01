public class Game
{
    private bool _isRunning;
    private readonly PetManager _petManager = new();
    private readonly Menu<PetType> _petTypeMenu;

    public Game()
    {
        _petTypeMenu = new Menu<PetType>("Select Pet Type",
            Enum.GetValues(typeof(PetType)).Cast<PetType>().ToList(),
            pt => pt.ToString());

        _petManager.OnNotification += message =>
        {
            Console.WriteLine(message);
            Console.ReadKey();
        };
    }

    public async Task GameLoop()
    {

        Initialize();


        _isRunning = true;
        while (_isRunning)
        {

            string userChoice = GetUserInput();

            await ProcessUserChoice(userChoice);
        }

        Console.WriteLine("Thanks for playing!");
    }

    private void Initialize()
    {
        Console.WriteLine("Welcome to the Interactive Pet Simulator\n\n" +

            "About the Game:\r\n" +
            "- Console-based virtual pet care simulation\r\n" +
            "- Inspired by the Tamagotchi of the 90s\r\n\r\n" +

            "Key Features:\r\n- 4 different types of pets:\r\n" +
            "  - Dog  | Cat  | Bird | Rabbit\r\n" +
            "- The 3 basic stat you need to manage:\r\n" +
            "  - Hunger : Feed with appropriate food\r\n" +
            "  - Sleep : Rest with a bed/blanket\r\n" +
            "  - Entertainment : Play with toys\r\n\r\n" +

            "Game Mechanics:\r\n" +
            "- Stats decrease over time (1 point every 5 seconds)\r\n" +
            "- If a stat drops to 0, the pet dies!\r\n" +
            "- Dead pets do not come back\r\n\r\nControls\r\n" +
            "- Use number keys in menus\r\n- Automatic recording feature (every 5 minutes)\r\n" +
            "- Manual recording/uploading options\r\n\r\n" +

            "How to Play\r\n" +
            "1. Get pet from the main menu\r\n" +
            "2. Check their status with �View Pads�\r\n" +
            "3. Use the appropriate item for dropped stats\r\n" +
            "4. Try to keep all pets alive");

        Console.ReadKey();
    }

    private string GetUserInput()
    {
        Console.Clear();
        Console.WriteLine("~Main Menu~");
        Console.WriteLine("1. Adopt a Pet");
        Console.WriteLine("2. View Pets");
        Console.WriteLine("3. Save Game");
        Console.WriteLine("4. Load Game");
        Console.WriteLine("5. Delete Save");
        Console.WriteLine("6. Creator Info");
        Console.WriteLine("7. Exit");
        Console.Write("Enter your choice: ");
        return Console.ReadLine();
    }

    private async Task ProcessUserChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                await AdoptPet();
                break;
            case "2":
                ViewPets();
                break;
            case "3":
                ShowSaveMenu();
                break;
            case "4":
                ShowLoadMenu();
                break;
            case "5":
                ShowDeleteMenu();
                break;
            case "6":
                CreatorInfo();
                break;
            case "7":
                _isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                break;
        }
    }
    private void CreatorInfo()
    {
        Console.Clear();
        Console.WriteLine("~Creator Info~");
        Console.WriteLine("Creator Name:Beril Sude �zy�lmaz");
        Console.WriteLine("Student Number:225040077");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }


    private async Task AdoptPet()
    {

        Console.Clear();
        Console.WriteLine("~Adopt a Pet~");
        Console.WriteLine("Select pet type:");

        var petTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>().ToList();

        for (int i = 0; i < petTypes.Count; i++)
        {
            var tempPet = new Pet("", petTypes[i]);
            Console.WriteLine($"{i + 1}. {petTypes[i]}");
            Console.WriteLine(tempPet.GetAsciiArt());
            Console.WriteLine();
        }

        Console.WriteLine("0. Go Back");
        Console.Write("Enter selection: ");

        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            if (selection == 0) return;

            if (selection > 0 && selection <= petTypes.Count)
            {
                var selectedType = petTypes[selection - 1];

                Console.Write("Enter your pet's name: ");
                string name = Console.ReadLine();

                var pet = new Pet(name, selectedType);
                _petManager.AddPet(pet);

                Console.WriteLine($"\nYou've adopted a {selectedType} named {name}!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid selection! Press any key to try again.");
                Console.ReadKey();
                await AdoptPet();
            }
        }
        else
        {
            Console.WriteLine("Please enter a number! Press any key to try again.");
            Console.ReadKey();
            await AdoptPet();
        }
    }

    private void ViewPets()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("~Your Pets~");

            if (_petManager.Pets.Count == 0)
            {
                Console.WriteLine("You don't have any pets yet!");
                Console.WriteLine("\nPress any key to return to main menu.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < _petManager.Pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_petManager.Pets[i].Name} ({_petManager.Pets[i].Type})");
            }

            Console.WriteLine("\n0. Back to Main Menu");
            Console.Write("\nSelect a pet to view details: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0) return;

                if (choice > 0 && choice <= _petManager.Pets.Count)
                {
                    var selectedPet = _petManager.Pets[choice - 1];
                    bool inPetMenu = true;

                    while (inPetMenu)
                    {
                        Console.Clear();
                        Console.WriteLine(selectedPet.GetAsciiArt());
                        Console.WriteLine($"\n{selectedPet}");
                        Console.WriteLine("\n1. Use Item");
                        Console.WriteLine("0. Back to Pets List");
                        Console.Write("\nSelect an option: ");

                        string petMenuChoice = Console.ReadLine();

                        switch (petMenuChoice)
                        {
                            case "1":
                                UseItemOnPet(selectedPet).Wait();
                                break;
                            case "0":
                                inPetMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Press any key to try again.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection! Press any key to try again.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Please enter a number! Press any key to try again.");
                Console.ReadKey();
            }
        }
    }

    private async Task UseItemOnPet(Pet pet)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"~Use Item on {pet.Name}~");
            Console.WriteLine(pet.GetAsciiArt());
            Console.WriteLine($"\nCurrent Stats:\n{pet}");

            var compatibleItems = ItemDatabase.AllItems
                .Where(item => item.CompatibleWith.Contains(pet.Type))
                .ToList();

            if (compatibleItems.Count == 0)
            {
                Console.WriteLine("No items available for this pet type!");
                Console.ReadKey();
                return;
            }

            var itemMenu = new Menu<Item>("Select Item", compatibleItems,
                i => $"{i.Name} (+{i.EffectAmount} {i.AffectedStat}, {i.Duration}s)");
            var selectedItem = itemMenu.ShowAndGetSelection();
            if (selectedItem == null) return;

            Console.Clear();
            Console.WriteLine($"Using {selectedItem.Name} on {pet.Name}...");
            Console.WriteLine(pet.GetAsciiArt());
            Console.WriteLine($"\nBefore:\n{pet}");

            await Task.Delay((int)(selectedItem.Duration * 1000));

            switch (selectedItem.AffectedStat)
            {
                case PetStat.Hunger:
                    pet.Hunger = Math.Min(100, pet.Hunger + selectedItem.EffectAmount);
                    break;
                case PetStat.Sleep:
                    pet.Sleep = Math.Min(100, pet.Sleep + selectedItem.EffectAmount);
                    break;
                case PetStat.Fun:
                    pet.Fun = Math.Min(100, pet.Fun + selectedItem.EffectAmount);
                    break;
            }

            Console.Clear();
            Console.WriteLine($"~Item Used on {pet.Name}~");
            Console.WriteLine(pet.GetAsciiArt());
            Console.WriteLine($"\nAfter:\n{pet}");
            Console.WriteLine($"\n{pet.Name}'s {selectedItem.AffectedStat} increased by {selectedItem.EffectAmount}!");

            Console.WriteLine("\n1. Use another item");
            Console.WriteLine("0. Back to pet menu");
            Console.Write("\nSelect an option: ");

            string continueChoice = Console.ReadLine();
            if (continueChoice == "0") break;
        }
    }

    private void ShowSaveMenu()
    {
        Console.Clear();
        Console.WriteLine("~Save Game~");
        Console.Write("Enter save slot name: ");
        string slotName = Console.ReadLine();

        SaveManager.SaveGame(_petManager, string.IsNullOrWhiteSpace(slotName) ? "autosave" : slotName);
        Console.WriteLine("Game saved successfully!");
        Console.ReadKey();
    }

    private void ShowLoadMenu()
    {
        Console.Clear();
        Console.WriteLine("~Load Game~");

        var saves = SaveManager.GetSaveSlots();
        if (saves.Count == 0)
        {
            Console.WriteLine("No save files found!");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < saves.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {saves[i]}");
        }

        Console.Write("Select save slot: ");
        if (int.TryParse(Console.ReadLine(), out int selection) && selection > 0 && selection <= saves.Count)
        {
            var state = SaveManager.LoadGame(saves[selection - 1]);
            if (state != null)
            {
                _petManager.LoadFromState(state);
                Console.WriteLine($"Loaded {saves[selection - 1]} save!");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection!");
        }

        Console.ReadKey();
    }

    private void ShowDeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("~Delete Save Game~");

        var saves = SaveManager.GetSaveSlots();
        if (saves.Count == 0)
        {
            Console.WriteLine("No save files found!");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < saves.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {saves[i]}");
        }

        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select save to delete: ");

        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            if (selection == 0) return;

            if (selection > 0 && selection <= saves.Count)
            {
                if (ConfirmDeletion(saves[selection - 1]))
                {
                    if (SaveManager.DeleteSave(saves[selection - 1]))
                    {
                        Console.WriteLine($"Save '{saves[selection - 1]}' deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Delete failed!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid selection!");
            }
        }

        Console.ReadKey();
    }

    private bool ConfirmDeletion(string saveName)
    {
        Console.Write($"Are you sure you want to delete '{saveName}'? (yes/no): ");
        return Console.ReadLine()?.ToLower() == "yes";
    }


    private DateTime _lastAutoSave = DateTime.Now;

    public async Task GameLoop1()
    {
        while (_isRunning)
        {

            if ((DateTime.Now - _lastAutoSave).TotalMinutes >= 5)
            {
                SaveManager.SaveGame(_petManager, "autosave");
                _lastAutoSave = DateTime.Now;
            }

            await Task.Delay(100);
        }
    }
}