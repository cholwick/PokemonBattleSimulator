# OOP Cheatsheet - Opdracht 3 (English)

---

## Question 1: What is inheritance, and why do we use it in Object-Oriented Programming?

Inheritance is a core pillar of Object-Oriented Programming (OOP) that allows a new class (known as a subclass or derived class) to inherit fields, properties, and methods from an existing class (known as a superclass or base class). Inheritance establishes an "IS-A" relationship between entities. For example, a `Charmander` *is a* `Pokemon`, a `Squirtle` *is a* `Pokemon`, and a `Bulbasaur` *is a* `Pokemon`.

We use inheritance primarily to promote code reusability and maintain a clean, organized hierarchy (the DRY principle: Don't Repeat Yourself). Without inheritance, each Pokémon class would need to duplicate the exact same code for storing `Nickname`, `Strength`, and `Weakness`. By placing these shared attributes in the parent `Pokemon` class, we write that code once and automatically share it across all subclasses. This drastically reduces bugs, simplifies updates, and makes adding new Pokémon in the future quick and straightforward.

*(Word count: ~145 words)*

---

## Question 2: What is an abstract class, and how does an abstract method work?

An **abstract class** is a blueprint designed specifically to be inherited by other classes, but it cannot be directly instantiated on its own. In C#, writing `new Pokemon(...)` will result in a compiler error because `Pokemon` is marked with the `abstract` keyword. It exists solely to define common characteristics and establish a contract for its derived subclasses.

An **abstract method** (such as `public abstract void BattleCry();`) is a method declared inside an abstract class that does not contain any code implementation in the parent class. Instead, it acts as a mandatory rule or template: every non-abstract subclass *must* provide its own concrete implementation using the `override` keyword. This guarantees that all Pokémon subclasses will have a `BattleCry()` method while allowing each individual species (`Charmander`, `Squirtle`, `Bulbasaur`) to define exactly what sounds or text it emits.

*(Word count: ~140 words)*

---

## Question 3: What is polymorphism, and how is it applied in our code?

Polymorphism comes from Greek words meaning "many forms." In programming, polymorphism allows objects of different specialized classes to be treated through a single uniform interface (the base class), while each object still behaves according to its own specific class type at runtime.

In our Pokémon project, polymorphism is demonstrated in two major places:
1. **The Pokeball storage**: The `Pokeball` class holds a reference to the abstract base type `Pokemon? ContainedPokemon`. Because of polymorphism, a single `Pokeball` can hold a `Charmander`, a `Squirtle`, or a `Bulbasaur` without needing separate ball classes for each species.
2. **The Battle Cry execution**: In `Program.cs`, the game calls `pokemon.BattleCry()`. At compile time, the program only knows it is dealing with a generic `Pokemon`. But at runtime, C# automatically looks up the actual object's overridden method: Charmander shouts its name, Squirtle shouts its name, and Bulbasaur shouts its name.

*(Word count: ~150 words)*

---

## Key Keywords & Concepts for Opdracht 3

| Keyword | Purpose & Meaning | Example in our code |
| :--- | :--- | :--- |
| **`abstract`** | Declares an incomplete class or method that cannot be instantiated and must be implemented by subclasses. | `public abstract class Pokemon` <br> `public abstract void BattleCry();` |
| **`override`** | Extends or modifies the abstract or virtual implementation of an inherited method in a subclass. | `public override void BattleCry() { ... }` |
| **`base`** | Calls members or the constructor of the parent class from within a derived subclass. | `public Charmander(string name) : base(name, "Fire", "Water")` |
| **Inheritance (`:`)** | The C# syntax symbol used to indicate that a class inherits from a base class. | `public class Squirtle : Pokemon` |
