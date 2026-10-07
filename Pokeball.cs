namespace PokemonBattleSimulator;

/// <summary>
/// Pokeball class
/// 
/// Can hold any Pokemon (Charmander, Squirtle, Bulbasaur) using polymorphism.
/// </summary>
public class Pokeball
{
    // A pokeball can contain any Pokemon subclass (or null if empty)
    public Pokemon? ContainedPokemon { get; private set; }

    // Tracks if the pokeball is open or closed
    public bool IsOpen { get; private set; }

    public Pokeball(Pokemon? pokemon = null)
    {
        ContainedPokemon = pokemon;
        IsOpen = false;
    }

    /// <summary>
    /// Throws the pokeball, opening it and releasing the Pokemon inside.
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
    /// Returns the Pokemon back into the pokeball, closing it again.
    /// </summary>
    public void Return(Pokemon? pokemon = null)
    {
        if (pokemon != null)
        {
            ContainedPokemon = pokemon;
        }

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
