# OOP Cheatsheet - Opdracht 2 (English)

---

## Question 1: What is composition?

Composition is a fundamental concept in Object-Oriented Programming where a complex object is constructed out of one or more other objects. Rather than relying on inheritance (an "IS-A" relationship, such as a Charmander *is a* Pokémon), composition establishes a "HAS-A" relationship. This means that an enclosing object contains other independent objects as its internal parts or fields. 

In a composition relationship, the lifetime and behavior of the child objects are typically tied to and coordinated by the parent object. For example, in our simulation, a `Trainer` has a belt containing a `List<Pokeball>`, and each `Pokeball` contains a `Charmander`. Neither the `Trainer` class nor the `Pokeball` class needs to inherit from each other; instead, they work together as building blocks, combining smaller, focused units into a larger, coherent system.

*(Word count: ~135 words)*

---

## Question 2: Why do we use composition?

We use composition because it promotes modularity, loose coupling, and greater flexibility in software design. In software engineering, there is a widely respected principle: "favor object composition over class inheritance." Deep inheritance hierarchies often make code rigid, fragile, and hard to modify, because changing a base class can unexpectedly break multiple subclasses down the chain.

Composition avoids these issues by allowing classes to remain focused on a single responsibility. A `Pokeball` only needs to know how to open, close, and hold a Pokémon; it does not need to know about trainer names or tournament rules. By assembling objects together through composition, developers can easily change, replace, or upgrade individual components without rewriting the entire program. It also makes unit testing significantly simpler because individual parts can be tested in isolation.

*(Word count: ~135 words)*

---

## Question 3: How do we use composition in our code?

We use composition in our code by defining class fields or properties whose types are other classes or collections of classes. Instead of writing all features inside a single monolithic class, we separate them into distinct classes and assemble them.

In our Pokémon project, composition is applied on multiple levels:
1. **Pokeball and Charmander**: The `Pokeball` class contains a field `public Charmander? ContainedPokemon { get; private set; }`. This gives the `Pokeball` direct access to a `Charmander` object without inheriting from it.
2. **Trainer and Pokeball**: The `Trainer` class has a belt property defined as `public List<Pokeball> Belt { get; private set; } = new List<Pokeball>();`. A `Trainer` object literally *has* six `Pokeball` objects on its belt.
3. When the `Trainer` constructor runs, it instantiates both `Charmander` and `Pokeball` objects and links them together, creating a layered, interconnected object structure.

*(Word count: ~145 words)*

---

## Key Keywords & Concepts for Opdracht 2

| Keyword / Concept | Meaning & Purpose | Example in our code |
| :--- | :--- | :--- |
| **`null`** | Represents the absence of an object reference. Used when a Pokeball is empty or when no Pokémon is returned. | `Charmander? pokemon = null;` |
| **`List<T>`** | A dynamic, generic collection from `System.Collections.Generic` that can grow and shrink in size. Used for the trainer's belt instead of a fixed array. | `public List<Pokeball> Belt = new List<Pokeball>();` |
| **`Exception`** | A class representing an error that occurs during program execution. Used to signal invalid operations (e.g. adding a 7th Pokeball). | `throw new Exception("Belt cannot have more than 6 pokeballs!");` |
| **`try` / `catch`** | Blocks used to handle exceptions gracefully without crashing the application. The risky code runs inside `try`, and the recovery/handling happens inside `catch`. | `try { trainer.AddPokeball(ball); } catch (Exception ex) { Console.WriteLine(ex.Message); }` |
