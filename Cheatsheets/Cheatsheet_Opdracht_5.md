# OOP Cheatsheet - Opdracht 5 (English)

---

## Question 1: What is encapsulation?

Encapsulation is one of the foundational pillars of Object-Oriented Programming (OOP) that involves bundling data (fields) and the methods that operate on that data into a single unit (a class), while restricting direct outside access to the internal components of that object.

Rather than exposing variables directly as public fields where any external code can freely tamper with or corrupt them, encapsulation enforces data hiding. The internal representation of an object is kept private, and access is mediated through controlled access points—specifically properties with getters (`get`) and setters (`set`), or dedicated methods. Encapsulation also includes immutability (preventing data from being altered after initialization) and class restriction using keywords such as `sealed` to control class inheritance.

*(Word count: ~130 words)*

---

## Question 2: Why do we use encapsulation?

We use encapsulation to guarantee data integrity, reduce bugs, and protect software from unintended side effects. When internal fields are public, any part of the codebase can assign invalid, unexpected, or destructive values to an object at any time, leading to difficult-to-trace bugs.

By hiding fields behind getters and setters, a class retains full control over its internal state. It can perform validation rules, enforce invariants, or keep properties entirely read-only so that values cannot be mutated after creation. Furthermore, encapsulation decouples how an object stores data from how the rest of the application interacts with it. If developers ever need to change the internal implementation of a class, they can do so without breaking or requiring changes in any other part of the system that relies on that class.

*(Word count: ~145 words)*

---

## Question 3: How do we use encapsulation in our code?

In our Pokémon project, encapsulation has been applied throughout the codebase across multiple distinct techniques:

1. **Read-Only Properties**: In the `Pokemon` class, fields are replaced with read-only properties (`public string Nickname { get; }`, `public ElementType Strength { get; }`, and `public ElementType Weakness { get; }`). Once an instance is created in the constructor, its values can never be modified from the outside.
2. **Type Safety via Enums**: We replaced raw string types with a strongly-typed `ElementType` enum (`Fire`, `Water`, `Grass`). This prevents invalid or misspelled strings from being assigned as strengths or weaknesses.
3. **The `sealed` Keyword**: The `Pokeball` class is marked as `public sealed class Pokeball`, completely preventing other classes from inheriting from it. Additionally, its `ContainedPokemon` property only has a getter, ensuring that the Pokémon assigned to a Pokeball cannot be swapped out or changed later.
4. **Eliminating Magic Numbers**: In `Trainer.cs`, the hardcoded number `6` was replaced with an encapsulated named constant: `public const int MaxBeltCapacity = 6;`.

*(Word count: ~165 words)*

---

## Key Keywords & Concepts for Opdracht 5

| Keyword / Concept | Purpose & Meaning | Example in our code |
| :--- | :--- | :--- |
| **Properties (`{ get; }`)** | Exposes values safely via getters while keeping fields hidden and immutable. | `public string Nickname { get; }` |
| **`private set`** | Allows a property to be read publicly, but only modified from within its own class. | `public bool IsOpen { get; private set; }` |
| **`sealed`** | Prevents other classes from inheriting from this class. | `public sealed class Pokeball` |
| **`enum`** | Creates a distinct, type-safe set of named constants instead of using error-prone strings. | `public enum ElementType { Fire, Water, Grass }` |
| **`const`** | Declares an immutable compile-time value to eliminate "magic numbers". | `public const int MaxBeltCapacity = 6;` |
