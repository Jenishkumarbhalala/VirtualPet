using System;

public class Pet
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; } = 6;
    public int Happiness { get; set; } = 7;
    public int Health { get; set; } = 8;

    public void Feed()
    {
        Hunger -= 2;
        Health += 1;
        Console.WriteLine($"-You fed {Name}. {Name}'s hunger decreases, and health improves slightly.");
    }

    public void Play()
    {
        Happiness += 2;
        Hunger += 1;
        Console.WriteLine($"-You played with {Name}. {Name}'s happiness increases, but he's a bit hungrier.");
    }

    public void Rest()
    {
        Health += 2;
        Happiness -= 1;
        Console.WriteLine($"-You let {Name} rest. {Name}'s health improved, but happiness decreased slightly.");
    }

    public void CheckStatus()
    {
        Console.WriteLine($"{Name}'s Status:");
        Console.WriteLine($"-Hunger: {Hunger}");
        Console.WriteLine($"-Happiness: {Happiness}");
        Console.WriteLine($"-Health: {Health}");

        if (Hunger <= 2)
        {
            Console.WriteLine($"{Name} is very hungry. Please feed {Name} soon.");
        }
        if (Happiness <= 2)
        {
            Console.WriteLine($"{Name} is very unhappy. Spend some time playing with {Name}.");
        }
        if (Health <= 2)
        {
            Console.WriteLine($"{Name} is not feeling well. Allow {Name} to rest for a while.");
        }
    }
}

public class Menu
{
    public static void ShowMainMenu()
    {
        
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Feed pet.");
        Console.WriteLine("2. Play with pet");
        Console.WriteLine("3. Let pet Rest");
        Console.WriteLine("4. Check pet's Status");
        Console.WriteLine("5. Exit");
        Console.Write("\nGive user Input:");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose a type of pet:");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");

        Console.Write("\nGive User Input: ");    
        int petType = int.Parse(Console.ReadLine());

        

        Console.WriteLine("\nYou've chosen a " + (petType == 1 ? "Cat" : (petType == 2 ? "Dog" : "Rabbit")) + ". What would you like to name your pet?");
        Console.Write("\nGive good Name:");
        string petName = Console.ReadLine();
        
        Pet pet = new Pet { Name = petName, Type = (petType == 1 ? "Cat" : (petType == 2 ? "Dog" : "Rabbit")) };

        Console.WriteLine($"\nWelcome, {pet.Name}! Let's take good care of him.");
        
        while (true)
        {
            Menu.ShowMainMenu();

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("\nInvalid choice. Please choose a valid option.");
                Console.Write("\nGive user Input:");

            }

            switch (choice)
            {
                case 1:
                    pet.Feed();
                    break;
                case 2:
                    pet.Play();
                    break;
                case 3:
                    pet.Rest();
                    break;
                case 4:
                    pet.CheckStatus();
                    break;
                case 5:
                    Console.WriteLine($"\nThank you for playing with {pet.Name}. Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
