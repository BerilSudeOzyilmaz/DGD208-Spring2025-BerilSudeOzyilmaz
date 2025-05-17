public class Game
{
    private bool _isRunning;

    public async Task GameLoop()
    {
        // Initialize the game
        Initialize();

        // Main game loop
        _isRunning = true;
        while (_isRunning)
        {
            // Display menu and get player input
            string userChoice = GetUserInput();

            // Process the player's choice
            await ProcessUserChoice(userChoice);
        }

        Console.WriteLine("Thanks for playing!");
    }

    private void Initialize()
    {
        Console.WriteLine("Welcome to the Interactive Pet Simulator");
        Console.WriteLine("Press any key to start");
        Console.ReadKey();
    }

    private string GetUserInput()
    {
        Console.Clear();
        Console.WriteLine("~Interactive Pet Simulator Main Menu~");
        Console.WriteLine("1. Adopt a Pet");
        Console.WriteLine("2. View Pets");
        Console.WriteLine("3. Use Item");
        Console.WriteLine("4. Creator Info");
        Console.WriteLine("5. Exit");
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
                await UseItem();
                break;
            case "4":
                CreatorInfo();
                break;
            case "5":
                _isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                break;
        }
    }
    private void CreatorInfo()
    {
        Console.Clear();
        Console.WriteLine("~Creator Info~");
        Console.WriteLine("This game was created by Beril Sude Özyýlmaz");
        Console.WriteLine("Student Number:225040077");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
    private async Task AdoptPet()
    {
        Console.WriteLine("Adopting a pet...");
        Console.ReadKey();
    }

    private void ViewPets()
    {
        Console.WriteLine("Viewing pets...");
        Console.ReadKey();
    }

    private async Task UseItem()
    {
        Console.WriteLine("Using an item...");
        Console.ReadKey();
    }
}