namespace PokemonBattleSimulator;

/// <summary>
/// Trainer class.
/// 
/// Encapsulation improvements:
/// - Replaced magic number 6 with a named constant (MaxBeltCapacity).
/// - Fields are hidden behind properties with getters and private setters.
/// </summary>
public class Trainer
{
    // Named constant to eliminate magic numbers
    public const int MaxBeltCapacity = 6;

    // Encapsulated properties
    public string Name { get; private set; }
    public List<Pokeball> Belt { get; private set; } = new List<Pokeball>();

    public Trainer(string name)
    {
        Name = name;
        InitializeBelt();
    }

    /// <summary>
    /// Initializes the belt with two of each Pokémon (Charmander, Squirtle, Bulbasaur).
    /// </summary>
    private void InitializeBelt()
    {
        try
        {
            // 2 of each of the 3 Pokemon (total: MaxBeltCapacity = 6)
            AddPokeball(new Pokeball(new Charmander("Charmander #1")));
            AddPokeball(new Pokeball(new Charmander("Charmander #2")));

            AddPokeball(new Pokeball(new Squirtle("Squirtle #1")));
            AddPokeball(new Pokeball(new Squirtle("Squirtle #2")));

            AddPokeball(new Pokeball(new Bulbasaur("Bulbasaur #1")));
            AddPokeball(new Pokeball(new Bulbasaur("Bulbasaur #2")));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error in Trainer {Name}]: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a Pokeball to the belt. Throws an exception if capacity is exceeded.
    /// </summary>
    public void AddPokeball(Pokeball pokeball)
    {
        if (Belt.Count >= MaxBeltCapacity)
        {
            throw new Exception($"Belt limit exceeded! Trainer {Name} cannot have more than {MaxBeltCapacity} Pokeballs on their belt.");
        }

        Belt.Add(pokeball);
    }

    /// <summary>
    /// Throws the pokeball at the specified slot index.
    /// </summary>
    public Pokemon? ThrowPokeball(int index)
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
    /// Returns the Pokemon into the pokeball at the specified slot index.
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
