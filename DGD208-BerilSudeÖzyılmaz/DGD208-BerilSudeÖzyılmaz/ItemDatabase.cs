public static class ItemDatabase
{
    public static List<Item> AllItems = new List<Item>
    {
        // Foods
        new Item { 
            Name = "Chew Bone", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Dog }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 15,
            Duration = 2.5f  // Takes 2.5 seconds to eat
        },
        new Item { 
            Name = "Beef Dry Food", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Dog }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 30,
            Duration = 3.0f  // Takes 3 seconds to eat
        },
        new Item { 
            Name = "Chicken Wet Food", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Cat }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 15,
            Duration = 2.0f
        },
        new Item { 
            Name = "Salmon Dry Food", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Cat }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 25,
            Duration = 3.0f
        },
        new Item { 
            Name = "Seed Mix", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Bird }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 10,
            Duration = 1.0f
        },
        new Item { 
            Name = "Fruit Bite", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Bird }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 20,
            Duration = 2.0f
        },
        new Item { 
            Name = "Carrot", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Rabbit }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 15,
            Duration = 3.0f
        },
        new Item { 
            Name = "Lettuce", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Rabbit }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 25,
            Duration = 4.0f
        },
        
        // Universal Foods
        new Item { 
            Name = "Vitamin Treat", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 10,
            Duration = 1.0f  // Quick treat
        },
        new Item { 
            Name = "Gourmet Dinner", 
            Type = ItemType.Food, 
            CompatibleWith = new List<PetType> { PetType.Dog, PetType.Cat }, 
            AffectedStat = PetStat.Hunger, 
            EffectAmount = 40,
            Duration = 5.0f  // Fancy meal takes time
        },
        
        // Toys
        new Item { 
            Name = "Rope Tug Toy", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Dog }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 20,
            Duration = 4.0f
        },
        new Item { 
            Name = "Plush Toy", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Dog }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 15,
            Duration = 2.5f
        },
        new Item { 
            Name = "Feather Wand", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Cat }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 20,
            Duration = 3.0f  // Playing with feather
        },
        new Item { 
            Name = "Laser Pointer", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Cat }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 15,
            Duration = 2.0f
        },
        new Item { 
            Name = "Swing", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Bird }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 15,
            Duration = 3.0f  // Swinging
        },
        new Item { 
            Name = "Mirror", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Bird }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 10,
            Duration = 1.5f
        },
        new Item { 
            Name = "Willow Stick", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Rabbit }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 15,
            Duration = 3.5f
        },
        new Item { 
            Name = "Tunnel", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Rabbit }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 20,
            Duration = 4.0f  // Running through tunnels
        },
        
        // Universal Toys
        new Item { 
            Name = "Ball", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit }, 
            AffectedStat = PetStat.Fun, 
            EffectAmount = 10,
            Duration = 2.0f
        },
        
        // Sleep Items
        new Item { 
            Name = "Fluffy Bed", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Dog, PetType.Cat }, 
            AffectedStat = PetStat.Sleep, 
            EffectAmount = 30,
            Duration = 6.0f  // Takes time to fall asleep
        },
        new Item { 
            Name = "Sof Blanket", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit }, 
            AffectedStat = PetStat.Sleep, 
            EffectAmount = 20,
            Duration = 4.0f
        },
        new Item { 
            Name = "Perch", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Bird }, 
            AffectedStat = PetStat.Sleep, 
            EffectAmount = 25,
            Duration = 3.0f
        },
        new Item { 
            Name = "Hideaway", 
            Type = ItemType.Toy, 
            CompatibleWith = new List<PetType> { PetType.Rabbit }, 
            AffectedStat = PetStat.Sleep, 
            EffectAmount = 25,
            Duration = 5.0f  // Takes time to get comfortable
        }
    };
}