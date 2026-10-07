using System;

namespace PokemonBattleSimulator;

public static class Program
{
    public static void Main(string[] args)
    {
        bool keepPlaying = true;
        // Instantiate the Arena (Battle is NOT used directly in Main!)
        Arena arena = new Arena();

        while (keepPlaying)
        {
            try { if (!Console.IsOutputRedirected) Console.Clear(); } catch { }
            Console.WriteLine("=================================================");
            Console.WriteLine("       POKÉMON BATTLE SIMULATOR - ARENA          ");
            Console.WriteLine("=================================================");

            // 1. Enter names for the two trainers
            Console.Write("\nEnter a name for the FIRST trainer (default: Ash): ");
            string? name1 = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name1)) name1 = "Ash";
            Trainer trainer1 = new Trainer(name1);

            Console.Write("Enter a name for the SECOND trainer (default: Gary): ");
            string? name2 = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name2)) name2 = "Gary";
            Trainer trainer2 = new Trainer(name2);

            Console.WriteLine("\nPress Enter to enter the Arena and start the battle...");
            Console.ReadLine();

            // 2. Start battle through the Arena (using composition, NOT Battle directly!)
            arena.StartBattle(trainer1, trainer2);

            // 3. Ask player to restart or quit
            Console.Write("\nWould you like to fight another battle in the Arena? (yes/no): ");
            string? choice = Console.ReadLine()?.Trim().ToLower();

            if (choice != "yes" && choice != "y")
            {
                keepPlaying = false;
                Console.WriteLine("\nThank you for battling in the Arena! Final Stats:");
                Arena.ShowScoreboard();
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
