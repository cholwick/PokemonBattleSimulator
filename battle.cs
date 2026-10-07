namespace PokemonBattleSimulator;

/// <summary>
/// Manages the rounds and combat rules between two trainers.
/// Uses ElementType enum and eliminates magic numbers.
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

        // Using Trainer.MaxBeltCapacity instead of a magic number
        List<int> availableIndices1 = Enumerable.Range(0, Trainer.MaxBeltCapacity).ToList();
        List<int> availableIndices2 = Enumerable.Range(0, Trainer.MaxBeltCapacity).ToList();

        Pokemon? activePokemon1 = null;
        Pokemon? activePokemon2 = null;
        int activeBallIndex1 = -1;
        int activeBallIndex2 = -1;

        int roundNumber = 1;

        // Loop until all pokeballs are used (or no available pokemon left to throw)
        while (availableIndices1.Count > 0 || availableIndices2.Count > 0 || activePokemon1 != null || activePokemon2 != null)
        {
            if (activePokemon1 == null && availableIndices1.Count == 0) break;
            if (activePokemon2 == null && availableIndices2.Count == 0) break;

            Console.WriteLine($"\n------------------ [ ROUND {roundNumber} ] ------------------");

            // 1. Trainer 1 brings out a Pokémon
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

            // 2. Trainer 2 brings out a Pokémon
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

            // 3. Resolve round using ElementType enum comparisons
            int winner = EvaluateRound(activePokemon1, activePokemon2);
            Arena.RecordRound();

            if (winner == 1)
            {
                Trainer1Wins++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {Trainer1.Name}'s {activePokemon1.Nickname} ({activePokemon1.Strength}) wins Round {roundNumber} against {activePokemon2.Nickname} ({activePokemon2.Strength})!");
                Console.ResetColor();

                // Winner stays in arena, loser returns to Pokeball
                Trainer2.ReturnPokemon(activeBallIndex2);
                activePokemon2 = null;
            }
            else if (winner == 2)
            {
                Trainer2Wins++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {Trainer2.Name}'s {activePokemon2.Nickname} ({activePokemon2.Strength}) wins Round {roundNumber} against {activePokemon1.Nickname} ({activePokemon1.Strength})!");
                Console.ResetColor();

                // Winner stays in arena, loser returns to Pokeball
                Trainer1.ReturnPokemon(activeBallIndex1);
                activePokemon1 = null;
            }
            else
            {
                Draws++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Result: Round {roundNumber} is a DRAW between {activePokemon1.Nickname} and {activePokemon2.Nickname} (both {activePokemon1.Strength})!");
                Console.ResetColor();

                // On a draw, both Pokémon return to their Pokeballs
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

        Arena.RecordBattle();
    }

    /// <summary>
    /// Type-safe matchup evaluation using ElementType enums:
    /// - If p1's Strength matches p2's Weakness -> p1 wins (1).
    /// - If p2's Strength matches p1's Weakness -> p2 wins (2).
    /// - Otherwise -> Draw (0).
    /// </summary>
    private static int EvaluateRound(Pokemon p1, Pokemon p2)
    {
        if (p1.Strength == p2.Weakness) return 1;
        if (p2.Strength == p1.Weakness) return 2;
        return 0;
    }
}
