namespace PokemonBattleSimulator;

/// <summary>
/// Manages the rounds and combat rules between two trainers.
/// Implements Rock-Paper-Scissors elemental mechanics and tracks round scores.
/// </summary>
public class Battle
{
    public Trainer Trainer1 { get; }
    public Trainer Trainer2 { get; }

    public int Trainer1Wins { get; private set; }
    public int Trainer2Wins { get; private set; }
    public int Draws { get; private set; }

    // Static random instance shared across all battles
    private static readonly Random _random = new();

    public Battle(Trainer trainer1, Trainer trainer2)
    {
        Trainer1 = trainer1;
        Trainer2 = trainer2;
    }

    /// <summary>
    /// Executes the full battle between the two trainers.
    /// </summary>
    public void Fight()
    {
        Console.WriteLine("\n=======================================================");
        Console.WriteLine($"   BATTLE START: {Trainer1.Name} VS {Trainer2.Name}!   ");
        Console.WriteLine("=======================================================");

        // Keep track of which Pokeball slots have NOT been thrown yet (0 to 5)
        List<int> availableIndices1 = new() { 0, 1, 2, 3, 4, 5 };
        List<int> availableIndices2 = new() { 0, 1, 2, 3, 4, 5 };

        // Active Pokémon currently in the arena
        Pokemon? activePokemon1 = null;
        Pokemon? activePokemon2 = null;
        int activeBallIndex1 = -1;
        int activeBallIndex2 = -1;

        int roundNumber = 1;

        // Loop until all pokeballs are used (or no available pokemon left to throw)
        while (availableIndices1.Count > 0 || availableIndices2.Count > 0 || activePokemon1 != null || activePokemon2 != null)
        {
            // If one trainer has no pokemon in arena and no balls left, battle ends
            if (activePokemon1 == null && availableIndices1.Count == 0) break;
            if (activePokemon2 == null && availableIndices2.Count == 0) break;

            Console.WriteLine($"\n------------------ [ ROUND {roundNumber} ] ------------------");

            // 1. Trainer 1 brings out a Pokémon (either keeps current winner, or throws random new one)
            if (activePokemon1 == null)
            {
                int pick = _random.Next(0, availableIndices1.Count);
                activeBallIndex1 = availableIndices1[pick];
                availableIndices1.RemoveAt(pick);

                activePokemon1 = Trainer1.ThrowPokeball(activeBallIndex1);
                activePokemon1?.BattleCry();
            }
            else
            {
                Console.WriteLine($"{Trainer1.Name}'s {activePokemon1.Nickname} stays ready in the arena!");
            }

            // 2. Trainer 2 brings out a Pokémon (either keeps current winner, or throws random new one)
            if (activePokemon2 == null)
            {
                int pick = _random.Next(0, availableIndices2.Count);
                activeBallIndex2 = availableIndices2[pick];
                availableIndices2.RemoveAt(pick);

                activePokemon2 = Trainer2.ThrowPokeball(activeBallIndex2);
                activePokemon2?.BattleCry();
            }
            else
            {
                Console.WriteLine($"{Trainer2.Name}'s {activePokemon2.Nickname} stays ready in the arena!");
            }

            if (activePokemon1 == null || activePokemon2 == null)
            {
                break;
            }

            // 3. Resolve round with Rock-Paper-Scissors
            int winner = EvaluateRound(activePokemon1, activePokemon2);
            Arena.RecordRound(); // Track round on Arena scoreboard

            if (winner == 1)
            {
                Trainer1Wins++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {Trainer1.Name}'s {activePokemon1.Nickname} wins Round {roundNumber}!");
                Console.ResetColor();

                // BONUS: Winner stays in arena, loser returns to Pokeball
                Trainer2.ReturnPokemon(activeBallIndex2);
                activePokemon2 = null;
            }
            else if (winner == 2)
            {
                Trainer2Wins++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {Trainer2.Name}'s {activePokemon2.Nickname} wins Round {roundNumber}!");
                Console.ResetColor();

                // BONUS: Winner stays in arena, loser returns to Pokeball
                Trainer1.ReturnPokemon(activeBallIndex1);
                activePokemon1 = null;
            }
            else
            {
                Draws++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Result: Round {roundNumber} is a DRAW between {activePokemon1.Nickname} and {activePokemon2.Nickname}!");
                Console.ResetColor();

                // BONUS: On a draw, both Pokémon return to their Pokeballs
                Trainer1.ReturnPokemon(activeBallIndex1);
                Trainer2.ReturnPokemon(activeBallIndex2);
                activePokemon1 = null;
                activePokemon2 = null;
            }

            roundNumber++;
        }

        // Return any remaining active Pokémon at the end of the battle
        if (activePokemon1 != null) Trainer1.ReturnPokemon(activeBallIndex1);
        if (activePokemon2 != null) Trainer2.ReturnPokemon(activeBallIndex2);

        // Announce overall battle winner
        Console.WriteLine("\n=======================================================");
        Console.WriteLine($"                   BATTLE SUMMARY                     ");
        Console.WriteLine("=======================================================");
        Console.WriteLine($"{Trainer1.Name} Round Wins: {Trainer1Wins}");
        Console.WriteLine($"{Trainer2.Name} Round Wins: {Trainer2Wins}");
        Console.WriteLine($"Draws:             {Draws}");
        Console.WriteLine("-------------------------------------------------------");

        if (Trainer1Wins > Trainer2Wins)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"★ WINNER: Trainer {Trainer1.Name} won the battle! ★");
            Console.ResetColor();
        }
        else if (Trainer2Wins > Trainer1Wins)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"★ WINNER: Trainer {Trainer2.Name} won the battle! ★");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("★ The battle ended in a DRAW! ★");
            Console.ResetColor();
        }

        // Record battle in Arena scoreboard
        Arena.RecordBattle();
    }

    /// <summary>
    /// Rock-Paper-Scissors matchup logic:
    /// - Charmander (Fire) wins from Bulbasaur (Grass)
    /// - Bulbasaur (Grass) wins from Squirtle (Water)
    /// - Squirtle (Water) wins from Charmander (Fire)
    /// Returns 1 if p1 wins, 2 if p2 wins, 0 for draw.
    /// </summary>
    private static int EvaluateRound(Pokemon p1, Pokemon p2)
    {
        // Same species/type -> Draw
        if (p1.GetType() == p2.GetType())
        {
            return 0;
        }

        // Charmander (Fire) beats Bulbasaur (Grass)
        if (p1 is Charmander && p2 is Bulbasaur) return 1;
        if (p1 is Bulbasaur && p2 is Charmander) return 2;

        // Bulbasaur (Grass) beats Squirtle (Water)
        if (p1 is Bulbasaur && p2 is Squirtle) return 1;
        if (p1 is Squirtle && p2 is Bulbasaur) return 2;

        // Squirtle (Water) beats Charmander (Fire)
        if (p1 is Squirtle && p2 is Charmander) return 1;
        if (p1 is Charmander && p2 is Squirtle) return 2;

        return 0;
    }
}
