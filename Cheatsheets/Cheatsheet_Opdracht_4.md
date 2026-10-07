# OOP Cheatsheet - Opdracht 4 (English)

---

## Question 1: What are static variables and static methods, and how do they differ from instance members?

In Object-Oriented Programming, members (variables and methods) normally belong to a specific instance (object) created with the `new` keyword. These are known as **instance members**. Each individual object has its own separate copy of instance variables in memory.

In contrast, **static variables** and **static methods** belong to the class itself rather than to any individual object. When a variable is declared with the `static` keyword, only one single copy of that variable exists in memory, shared across all instances of the class and accessible throughout the entire program lifespan. 

Similarly, a **static method** is called directly on the class name (for example, `Arena.ShowScoreboard()`) without needing to create an object using `new Arena()`. Static methods cannot access non-static instance fields directly because they do not operate on a specific object instance.

*(Word count: ~140 words)*

---

## Question 2: Why and when do we use static members in Object-Oriented Programming?

We use static members when data or functionality needs to be shared universally across the entire application, or when a utility operation does not depend on the internal state of a specific object.

A classic use case is maintaining global counters, tracking statistics, or configuring shared application state. For instance, in our battle simulator, the total number of battles and rounds fought does not belong to a single trainer or a single battle; it belongs to the entire arena facility. Using static variables ensures that every battle increments the exact same central counter.

Another major use case is utility and helper methods, such as `Math.Sqrt()`, `Console.WriteLine()`, or a shared `Random` number generator. Since generating a random number or calculating a square root does not require an object's individual state, declaring them static makes the code cleaner, faster, and avoids unnecessary object allocations.

*(Word count: ~150 words)*

---

## Question 3: How are static members applied in our Arena and Battle code?

In our Pokémon project, static members are used in two key places:
1. **The Arena Scoreboard**: The `Arena` class declares static variables:
   ```csharp
   public static int TotalRoundsFought { get; private set; } = 0;
   public static int TotalBattlesFought { get; private set; } = 0;
   ```
   Every time a round concludes in `Battle.cs`, it invokes `Arena.RecordRound()`. When a match finishes, it calls `Arena.RecordBattle()`. Because these counters are static, they persist and accumulate across multiple consecutive battles without resetting when a new battle begins.
2. **The Shared Random Generator**: In `Battle.cs`, we use a static `Random` instance (`private static readonly Random _random = new();`). This guarantees that all rounds and battles share one centralized random number generator, avoiding the well-known bug where recreating `Random` instances in rapid succession generates duplicate numbers.

*(Word count: ~140 words)*

---

## Key Keywords & Concepts for Opdracht 4

| Keyword / Concept | Purpose & Meaning | Example in our code |
| :--- | :--- | :--- |
| **`static`** | Declares a member that belongs to the class type itself, rather than to a specific object instance. | `public static int TotalBattlesFought;` <br> `public static void RecordRound();` |
| **Class Call** | Calling a method directly via the class name without instantiating it. | `Arena.ShowScoreboard();` |
| **Composition in Arena** | The `Arena` class contains an internal instance of `Battle`, keeping `Battle` out of `Program.Main`. | `_currentBattle = new Battle(trainer1, trainer2);` |
