# Pokémon Battle Simulator 🎮

A text-based **Pokémon Battle Simulator** console application built in **C# (.NET 10)** for a school Object-Oriented Programming (OOP) project.

---

## 📖 Project Overview

This project is built incrementally following the school assignments, focusing on mastering core Object-Oriented Programming principles:

- **Opdracht 1: Classes & Objects**
  - Blueprint (`class`) vs. Instance (`object`)
  - Fields, constructors, and methods
  - Creating a `Charmander` entity that can battle cry its name without storing the cry as a field.
- **Opdracht 2: Composition & Error Handling**
  - **Composition ("HAS-A" relationship)**: Complex objects built out of simpler objects.
  - `Pokeball`: Can be empty or contain a `Charmander`. Has `Throw()` and `Return()` actions.
  - `Trainer`: Holds a belt of 6 Pokeballs using a generic `List<Pokeball>`.
  - **Exception Handling**: Prevents adding more than 6 Pokeballs by throwing and catching an `Exception`.
  - **Turn Loop**: Two trainers throwing Pokeballs, releasing Charmanders, yelling their battle cries, and returning them across 6 rounds.

---

## 📂 Project Structure

```
PokemonBattleSimulator/
│
├── Pokemon.cs                    # Abstract base class with fields, constructor & abstract BattleCry()
├── Charmander.cs                 # Charmander subclass (: Pokemon)
├── Squirtle.cs                   # Squirtle subclass (: Pokemon)
├── Bulbasaur.cs                  # Bulbasaur subclass (: Pokemon)
├── Pokeball.cs                   # Pokeball class (can hold any Pokemon)
├── Trainer.cs                    # Trainer class (holds belt with 2 of each of the 3 Pokemon)
├── Program.cs                    # Main entry point with the interactive battle loop
│
├── Cheatsheets/
│   ├── Cheatsheet_Opdracht_1.md      # Opdracht 1 Cheatsheet (English, 100+ words)
│   ├── Cheatsheet_Opdracht_1_NL.md   # Opdracht 1 Cheatsheet (Nederlands)
│   ├── Cheatsheet_Opdracht_2.md      # Opdracht 2 Cheatsheet (English, 100+ words)
│   ├── Cheatsheet_Opdracht_2_NL.md   # Opdracht 2 Cheatsheet (Nederlands)
│   └── Cheatsheet_Opdracht_3.md      # Opdracht 3 Cheatsheet (English, 100+ words)
│
├── PokemonBattleSimulator.csproj     # .NET 10 project file
├── PokemonBattleSimulator.slnx       # Visual Studio solution file
└── .gitignore                        # Excludes build artifacts (bin/, obj/, .vs/)
```

---

## 🚀 How to Run

### Option 1: In Visual Studio
1. Open `PokemonBattleSimulator.slnx` in Visual Studio.
2. Press **F5** or click the green **▶ Play** button at the top toolbar.

### Option 2: In Terminal / PowerShell
```powershell
cd C:\school\code\PokemonBattleSimulator
dotnet run
```

---

## 🏛️ OOP Concepts Covered

| Concept | Explanation | Where to find it |
| :--- | :--- | :--- |
| **Abstract Class & Inheritance** | `Pokemon` is an abstract base class; `Charmander`, `Squirtle`, and `Bulbasaur` inherit from it using `: base(...)`. | `Pokemon.cs`, `Charmander.cs`, etc. |
| **Polymorphism** | `BattleCry()` is declared abstract and overridden in each subclass. `Pokeball` and `Trainer` work with generic `Pokemon`. | `Pokemon.cs`, `Pokeball.cs`, `Program.cs` |
| **Composition** | An object containing other objects as fields/properties. | `Trainer` *has-a* `List<Pokeball>`, and `Pokeball` *has-a* `Pokemon`. |
| **Collections (`List<T>`)** | Dynamic list used instead of fixed arrays for the trainer's belt. | `Trainer.cs` (`List<Pokeball> Belt`) |
| **Exception Handling** | Using `throw`, `try`, and `catch` to handle illegal operations. | `Trainer.cs` throws when belt > 6; `Program.cs` catches it. |

---

## 📚 Cheatsheets & Theory

Detailed English explanations (min. 100 words each for assignment hand-in):
- 🇬🇧 [Opdracht 1 Cheatsheet (EN)](Cheatsheets/Cheatsheet_Opdracht_1.md)
- 🇬🇧 [Opdracht 2 Cheatsheet (EN)](Cheatsheets/Cheatsheet_Opdracht_2.md)
- 🇬🇧 [Opdracht 3 Cheatsheet (EN)](Cheatsheets/Cheatsheet_Opdracht_3.md)
