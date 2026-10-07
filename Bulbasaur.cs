namespace PokemonBattleSimulator;

/// <summary>
/// Bulbasaur subclass of Pokemon.
/// Inherits from Pokemon and initializes with ElementType enums.
/// </summary>
public class Bulbasaur : Pokemon
{
    public Bulbasaur(string nickname)
        : base(nickname, ElementType.Grass, ElementType.Fire)
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{Nickname}!");
    }
}
