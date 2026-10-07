namespace PokemonBattleSimulator;

/// <summary>
/// Abstract base class for all Pokémon.
/// 
/// Requirements:
/// - Nickname, Strength, Weakness fields/properties.
/// - Parent constructor for all fields.
/// - BattleCry must be an abstract method (implemented by each subclass).
/// </summary>
public abstract class Pokemon
{
    // Common fields for all Pokémon
    public string Nickname;
    public string Strength;
    public string Weakness;

    // Parent constructor used by subclasses via : base(...)
    public Pokemon(string nickname, string strength, string weakness)
    {
        Nickname = nickname;
        Strength = strength;
        Weakness = weakness;
    }

    /// <summary>
    /// Abstract method: every subclass must implement its own BattleCry!
    /// </summary>
    public abstract void BattleCry();
}
