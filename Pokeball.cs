namespace PokemonBattleSimulator;

/// <summary>
/// Pokeball class.
/// 
/// Encapsulation improvements:
/// - Marked as 'sealed' so no subclasses can be created.
/// - ContainedPokemon has only a getter (immutable once assigned in constructor).
/// - IsOpen has a private setter so it can only be modified through Throw() and Return().
/// </summary>
public sealed class Pokeball
{
    // Immutable reference to the Pokemon: cannot be changed once assigned
    public Pokemon? ContainedPokemon { get; }

    // Read-only from outside, only modified through Throw() and Return()
    public bool IsOpen { get; private set; }

    public Pokeball(Pokemon? pokemon = null)
    {
        ContainedPokemon = pokemon;
        IsOpen = false;
    }

    /// <summary>
    /// Throws the pokeball, opening it and releasing the Pokemon.
    /// </summary>
    public Pokemon? Throw()
    {
        IsOpen = true;

        if (ContainedPokemon == null)
        {
            Console.WriteLine("The Pokeball opened, but it is empty!");
            return null;
        }

        Console.WriteLine($"The Pokeball opens and releases {ContainedPokemon.Nickname}!");
        return ContainedPokemon;
    }

    /// <summary>
    /// Closes the pokeball on the assigned Pokemon.
    /// Does NOT allow reassigning or replacing the Pokemon inside.
    /// </summary>
    public void Return()
    {
        IsOpen = false;

        if (ContainedPokemon != null)
        {
            Console.WriteLine($"{ContainedPokemon.Nickname} returned to the Pokeball. The Pokeball clicked shut.");
        }
        else
        {
            Console.WriteLine("The empty Pokeball was closed.");
        }
    }
}
