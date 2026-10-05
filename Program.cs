using System;

namespace PokemonBattleSimulator;

public static class Program
{
    public static void Main(string[] args)
    {
        bool keepPlaying = true;

        while (keepPlaying)
        {
            // 1. The player starts the game.
            try { if (!Console.IsOutputRedirected) Console.Clear(); } catch { }
            Console.WriteLine("=================================================");
            Console.WriteLine("       POKÉMON BATTLE SIMULATOR - OPDRACHT 2     ");
            Console.WriteLine("=================================================");

            // 2. The player gives a name to the first trainer.
            Console.Write("\nEnter a name for the FIRST trainer (default: Ash): ");
            string? name1 = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name1)) name1 = "Ash";
            Trainer trainer1 = new Trainer(name1);

            // 3. The player gives a name to the second trainer.
            Console.Write("Enter a name for the SECOND trainer (default: Gary): ");
            string? name2 = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name2)) name2 = "Gary";
            Trainer trainer2 = new Trainer(name2);

            // Optional demonstration of Error Handling (try-catch with Exception)
            // Attempting to add a 7th pokeball to prove the restriction works:
            Console.WriteLine("\n[System Check] Testing belt capacity exception handling...");
            try
            {
                Pokeball extraBall = new Pokeball(new Charmander("Extra", "Fire", "Water"));
                trainer1.AddPokeball(extraBall); // Should throw Exception because belt already has 6!
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Expected Exception Caught]: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress Enter to begin the battle round between the two trainers...");
            Console.ReadLine();

            // 10. Repeat 4 to 9 until all pokeballs have been used by both trainers (6 pokeballs).
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\n================== [ ROUND {i + 1} / 6 ] ==================");

                // 4. The first trainer throws the pokeball on its belt.
                Charmander? pokemon1 = trainer1.ThrowPokeball(i);

                // 5. The pokeball released the charmander and charmander does its battle cry.
                if (pokemon1 != null)
                {
                    pokemon1.BattleCry();
                }

                // 6. The second trainer throws the pokeball on its belt.
                Charmander? pokemon2 = trainer2.ThrowPokeball(i);

                // 7. The pokeball released the charmander and charmander does its battle cry.
                if (pokemon2 != null)
                {
                    pokemon2.BattleCry();
                }

                // 8. The first trainer returns the charmander back to its pokeball.
                trainer1.ReturnPokemon(i);

                // 9. The second trainer returns the charmander back to its pokeball.
                trainer2.ReturnPokemon(i);

                Console.WriteLine("-------------------------------------------------");
            }

            Console.WriteLine("\nAll Pokeballs on both belts have been used!");

            // The player can quit or restart the game.
            Console.Write("\nWould you like to restart the game? (yes/no): ");
            string? choice = Console.ReadLine()?.Trim().ToLower();

            if (choice != "yes" && choice != "y")
            {
                keepPlaying = false;
                Console.WriteLine("\nThanks for playing! Goodbye!");
            }
        }
    }
}
