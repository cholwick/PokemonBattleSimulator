namespace PokemonBattleSimulator;

/// <summary>
/// Squirtle subclass of Pokemon.
/// 
/// Requirements:
/// - Inherits from abstract Pokemon base class.
/// - Calls the parent constructor (: base).
/// - Strength is Water, Weakness is Leaf.
/// - Overrides the abstract BattleCry method.
/// </summary>
public class Squirtle : Pokemon
{
    // Subclass constructor calling the parent constructor (: base)
    public Squirtle(string nickname, string strength = "Water", string weakness = "Leaf")
        : base(nickname, strength, weakness)
    {
    }

    // Overridden BattleCry method (Polymorphism)
    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}!");
    }
}
