namespace PokemonBattleSimulator;

/// <summary>
/// Bulbasaur subclass of Pokemon.
/// 
/// Requirements:
/// - Inherits from abstract Pokemon base class.
/// - Calls the parent constructor (: base).
/// - Strength is Grass, Weakness is Fire.
/// - Overrides the abstract BattleCry method.
/// </summary>
public class Bulbasaur : Pokemon
{
    // Subclass constructor calling the parent constructor (: base)
    public Bulbasaur(string nickname, string strength = "Grass", string weakness = "Fire")
        : base(nickname, strength, weakness)
    {
    }

    // Overridden BattleCry method (Polymorphism)
    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}!");
    }
}
