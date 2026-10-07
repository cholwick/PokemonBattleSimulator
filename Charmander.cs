namespace PokemonBattleSimulator;

/// <summary>
/// Charmander subclass of Pokemon.
/// Inherits from Pokemon and initializes with ElementType enums.
/// </summary>
public class Charmander : Pokemon
{
    public Charmander(string nickname) 
        : base(nickname, ElementType.Fire, ElementType.Water)
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}!");
    }
}