namespace PokemonBattleSimulator;

/// <summary>
/// Opdracht 2: Pokeball class
/// 
/// Requirements:
/// - The pokeball is empty or it can contain a single charmander.
/// - The pokeball can be thrown, which opens it up, and releases the charmander.
/// - The charmander can be returned back to its pokeball, which closes it.
/// </summary>
public class Pokeball
{
    // A pokeball can contain a single Charmander (or null if empty)
    public Charmander? ContainedPokemon { get; private set; }

    // Tracks if the pokeball is currently open or closed
    public bool IsOpen { get; private set; }

    // Constructor: Can be created empty, or with a Charmander inside
    public Pokeball(Charmander? charmander = null)
    {
        ContainedPokemon = charmander;
        IsOpen = false;
    }

    /// <summary>
    /// Throws the pokeball, opening it and releasing the Charmander inside.
    /// </summary>
    public Charmander? Throw()
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
    /// Returns the Charmander back into the pokeball, closing it again.
    /// </summary>
    public void Return(Charmander? pokemon = null)
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
