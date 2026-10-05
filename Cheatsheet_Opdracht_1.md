# OOP Cheatsheet - Opdracht 1 (English)

---

## Question 1: Why would you want to write your code in an object-oriented programming language?

Writing code in an object-oriented programming (OOP) language allows developers to model software around real-world concepts and entities rather than just sequential actions and procedures. In OOP, programs are divided into self-contained objects that combine both data (state) and behavior (functions).

One major benefit of this approach is modularity and maintainability. When your application grows larger, procedural code often becomes difficult to manage because changes in one part of the program can easily break other parts. In contrast, OOP uses encapsulation to keep an object's internal details hidden and protected, making bugs much easier to isolate and fix. 

Another reason is code reusability. Through inheritance and polymorphism, developers can build generic templates and extend existing functionality without rewriting code from scratch. This makes team collaboration smoother, keeps code organized, and makes software much easier to scale, test, and adapt over time.

*(Word count: ~150 words)*

---

## Question 2: What's the difference between a class and an object?

The difference between a class and an object is the difference between a blueprint and the actual item built from that blueprint. 

A **class** is a blueprint, definition, or template that describes what kind of data an entity can store and what actions it can perform. It defines the fields (variables), properties, and methods, but it does not represent any specific physical instance in memory yet. For example, a `Charmander` class specifies that all Charmanders have a nickname, an elemental strength of Fire, a weakness to Water, and a battle cry method.

An **object**, on the other hand, is a specific instance created in memory from that class using the `new` keyword. For example, when you write `new Charmander("Sparky", "Fire", "Water")`, you create an individual object with its own distinct nickname and data. You can create multiple unique Charmander objects from the exact same class blueprint.

*(Word count: ~155 words)*

---

## Key C# Keywords for Opdracht 1

| Keyword | Meaning & Purpose | Example |
| :--- | :--- | :--- |
| **`class`** | Used to declare a new blueprint/type that holds fields, methods, and constructors. | `public class Charmander { ... }` |
| **`new`** | Creates an actual instance (an object) in memory from a class blueprint and calls its constructor. | `Charmander c = new Charmander("Charry", "Fire", "Water");` |
| **`void`** | Specifies that a method performs an action but does **not** return any value to the caller. | `public void BattleCry() { ... }` |
| **`null`** | Represents the absence of a value or an empty reference that does not point to any object in memory. | `string? name = null;` |
