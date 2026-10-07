namespace PokemonBattleSimulator;

/// <summary>
/// Abstract base class for all Pokémon.
/// 
/// Encapsulation improvements:
/// - Fields are hidden behind read-only properties (getters only).
/// - Values cannot be modified once the object is constructed.
/// - Uses ElementType enum instead of plain strings.
/// </summary>
public abstract class Pokemon
{
    // Encapsulated properties with getters only (immutable once created)
    public string Nickname { get; }
    public ElementType Strength { get; }
    public ElementType Weakness { get; }

    protected Pokemon(string nickname, ElementType strength, ElementType weakness)
    {
        Nickname = nickname;
        Strength = strength;
        Weakness = weakness;
    }

    /// <summary>
    /// Abstract battle cry method that each subclass overrides.
    /// </summary>
    public abstract void BattleCry();
}
