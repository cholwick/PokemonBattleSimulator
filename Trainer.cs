namespace PokemonBattleSimulator;

/// <summary>
/// Opdracht 2: Trainer class
/// 
/// Requirements:
/// - Trainer has a Name and a Belt with six pokeballs (each containing a Charmander).
/// - Belt MUST be a List<Pokeball>, NOT an array.
/// - If more than 6 pokeballs are added, throw an Exception!
/// - Error handling using try and catch.
/// - Methods to throw a pokeball and return a pokemon.
/// </summary>
public class Trainer
{
    public string Name { get; set; }

    // Belt MUST be a List<Pokeball> (Composition: Trainer HAS-A List of Pokeballs)
    public List<Pokeball> Belt { get; private set; } = new List<Pokeball>();

    public Trainer(string name)
    {
        Name = name;
        InitializeBelt();
    }

    /// <summary>
    /// Initializes the belt with exactly 6 Pokeballs, each containing a Charmander.
    /// Uses try-catch to demonstrate error handling with Exceptions.
    /// </summary>
    private void InitializeBelt()
    {
        try
        {
            for (int i = 1; i <= 6; i++)
            {
                // Create a Charmander for each Pokeball
                Charmander charmander = new Charmander($"{Name}'s Charmander #{i}", "Fire", "Water");
                Pokeball pokeball = new Pokeball(charmander);

                AddPokeball(pokeball);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error in Trainer {Name}]: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a Pokeball to the belt. Throws an exception if the belt already has 6 Pokeballs.
    /// </summary>
    public void AddPokeball(Pokeball pokeball)
    {
        if (Belt.Count >= 6)
        {
            throw new Exception($"Belt limit exceeded! Trainer {Name} cannot have more than 6 Pokeballs on their belt.");
        }

        Belt.Add(pokeball);
    }

    /// <summary>
    /// Throws the pokeball at the specified belt index (0-5).
    /// </summary>
    public Charmander? ThrowPokeball(int index)
    {
        if (index < 0 || index >= Belt.Count)
        {
            Console.WriteLine($"Invalid pokeball slot: {index}");
            return null;
        }

        Console.WriteLine($"\n{Name} throws Pokeball #{index + 1} from their belt!");
        return Belt[index].Throw();
    }

    /// <summary>
    /// Returns the pokemon back into the pokeball at the specified index.
    /// </summary>
    public void ReturnPokemon(int index)
    {
        if (index < 0 || index >= Belt.Count)
        {
            Console.WriteLine($"Invalid pokeball slot: {index}");
            return;
        }

        Console.WriteLine($"\n{Name} calls back the Pokémon into Pokeball #{index + 1}!");
        Belt[index].Return();
    }
}
