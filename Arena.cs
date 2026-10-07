namespace PokemonBattleSimulator;

/// <summary>
/// Represents the Arena where battles take place.
/// 
/// Restrictions met:
/// - Uses composition: Arena has a Battle instance.
/// - Uses static variables and static methods to keep track of the score across all battles and rounds.
/// </summary>
public class Arena
{
    // STATIC scoreboard variables (shared across the entire program)
    public static int TotalRoundsFought { get; private set; } = 0;
    public static int TotalBattlesFought { get; private set; } = 0;

    // Composition: Arena has a reference to the Battle
    private Battle? _currentBattle;

    /// <summary>
    /// Static method to increment the total rounds fought.
    /// </summary>
    public static void RecordRound()
    {
        TotalRoundsFought++;
    }

    /// <summary>
    /// Static method to increment the total battles fought.
    /// </summary>
    public static void RecordBattle()
    {
        TotalBattlesFought++;
    }

    /// <summary>
    /// Static method to display the scoreboard.
    /// </summary>
    public static void ShowScoreboard()
    {
        Console.WriteLine("\n=======================================================");
        Console.WriteLine("                  ARENA SCOREBOARD                     ");
        Console.WriteLine("=======================================================");
        Console.WriteLine($" Total Battles Fought: {TotalBattlesFought}");
        Console.WriteLine($" Total Rounds Fought:  {TotalRoundsFought}");
        Console.WriteLine("=======================================================");
    }

    /// <summary>
    /// Starts a battle between two trainers inside the arena.
    /// Uses composition: Arena creates and runs the Battle object.
    /// </summary>
    public void StartBattle(Trainer trainer1, Trainer trainer2)
    {
        // Composition: instantiate Battle inside Arena
        _currentBattle = new Battle(trainer1, trainer2);
        
        // Execute the battle gameplay loop
        _currentBattle.Fight();

        // Show the updated arena scoreboard
        ShowScoreboard();
    }
}
