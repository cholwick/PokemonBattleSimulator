namespace PokemonBattleSimulator;

/// <summary>
/// Trainer class
/// 
/// Requirements:
/// - Has a name and a belt with 6 pokeballs: 2 of each of the 3 pokemon (Charmander, Squirtle, Bulbasaur).
/// - Belt is a List<Pokeball>.
/// - Throws an exception if more than 6 pokeballs are on the belt.
/// </summary>
public class Trainer
{
    public string Name { get; set; }

    // Belt containing 6 Pokeballs
    public List<Pokeball> Belt { get; private set; } = new List<Pokeball>();

    public Trainer(string name)
    {
        Name = name;
        InitializeBelt();
    }

    /// <summary>
    /// Initializes the belt with two of each of the three Pokémon (6 total).
    /// </summary>
    private void InitializeBelt()
    {
        try
        {
            // 2 Charmanders
            AddPokeball(new Pokeball(new Charmander($"{Name}'s Charmander #1")));
            AddPokeball(new Pokeball(new Charmander($"{Name}'s Charmander #2")));

            // 2 Squirtles
            AddPokeball(new Pokeball(new Squirtle($"{Name}'s Squirtle #1")));
            AddPokeball(new Pokeball(new Squirtle($"{Name}'s Squirtle #2")));

            // 2 Bulbasaurs
            AddPokeball(new Pokeball(new Bulbasaur($"{Name}'s Bulbasaur #1")));
            AddPokeball(new Pokeball(new Bulbasaur($"{Name}'s Bulbasaur #2")));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error in Trainer {Name}]: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds a Pokeball to the belt. Throws an exception if belt has more than 6.
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
    /// Throws the pokeball at the specified index and releases the Pokemon.
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
    /// Returns the Pokemon into the pokeball at the specified index.
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
