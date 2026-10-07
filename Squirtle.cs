namespace PokemonBattleSimulator;

/// <summary>
/// Squirtle subclass of Pokemon.
/// Inherits from Pokemon and initializes with ElementType enums.
/// </summary>
public class Squirtle : Pokemon
{
    public Squirtle(string nickname)
        : base(nickname, ElementType.Water, ElementType.Grass)
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}!");
    }
}
