namespace PokemonBattleSimulator;

/// <summary>
/// Opdracht 1: Charmander class
/// 
/// Requirements:
/// - Nickname (string)
/// - Strength (fire)
/// - Weakness (water)
/// - A constructor for all fields
/// - NO field for battle cry!
/// - A method to yell its battle cry (its own name)
/// </summary>
public class Charmander
{
    // 1. Fields
    public string Nickname;
    public string Strength;
    public string Weakness;

    // 2. Constructor: must initialize all fields
    public Charmander(string nickname, string strength, string weakness)
    {
        Nickname = nickname;
        Strength = strength;
        Weakness = weakness;
    }

    // 3. Battle Cry Method
    // IMPORTANT: Restrictions state "The Charmander class doesn't use a field for its battle cry"
    public void BattleCry()
    {
        // TODO: Print the nickname to the console (e.g. "Charmander!" or $"{Nickname}!")
        Console.WriteLine($"{Nickname}!");
    }
}
