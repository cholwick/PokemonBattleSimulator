# OOP Cheatsheet - Opdracht 2 (Nederlands)

> **Let op:** Voor het inleveren gebruik je de Engelse versie in `Cheatsheet_Opdracht_2.md` (minimaal 100 woorden per vraag). Deze Nederlandse versie is speciaal bedoeld om je voor te bereiden op de **mondelinge overhoring** van je docent!

---

## Vraag 1: Wat is composition (compositie)?

Compositie is een fundamenteel principe binnen Object-Oriented Programming (OOP) waarbij een complex object wordt opgebouwd uit één of meerdere andere objecten. In plaats van overerving (een "IS-EEN" relatie, zoals een Charmander *is een* Pokémon), gebruikt compositie een **"HEEFT-EEN" (HAS-A)** relatie. Dit betekent dat een overkoepelend object andere zelfstandige objecten bezit als interne velden of eigenschappen.

Bij compositie is de levenscyclus en het gedrag van de sub-objecten vaak direct verbonden met het hoofdobject. In ons project heeft een `Trainer` bijvoorbeeld een riem met een `List<Pokeball>`, en elke `Pokeball` bevat weer een `Charmander`. Noch de `Trainer`, noch de `Pokeball` hoeft van elkaar te overerven; in plaats daarvan werken ze samen als modulaire bouwstenen die samen één compleet systeem vormen.

*(Aantal woorden: ~125 woorden)*

---

## Vraag 2: Waarom gebruiken we composition?

We gebruiken compositie omdat het zorgt voor modulariteit, losse koppeling (loose coupling) en enorme flexibiliteit in softwareontwerp. Een bekende vuistregel in software development luidt: *"Favor object composition over class inheritance"* (kies liever voor compositie dan overerving). Diepe overervingsstructuren maken code vaak stijf en kwetsbaar: als je iets verandert aan de basisklasse, kan dat onbedoeld meerdere subklassen kapotmaken.

Compositie voorkomt dit doordat elke class gefocust blijft op zijn eigen taak (Single Responsibility). Een `Pokeball` hoeft alleen te weten hoe hij opengaat, dichtgaat en een Pokémon vasthoudt; hij hoeft niets te weten van toernooiregels of trainersnamen. Door objecten via compositie samen te stellen, kun je eenvoudig losse onderdelen vervangen, upgraden of testen zonder de rest van je code overhoop te gooien.

*(Aantal woorden: ~125 woorden)*

---

## Vraag 3: Hoe passen we composition toe in onze code?

We passen compositie in onze code toe door variabelen, properties of lijsten in een class te zetten waarvan het type een andere class is. In plaats van alle logica in één gigantische class te proppen, maken we afzonderlijke classes en koppelen we die aan elkaar.

In ons Pokémon project is compositie op twee niveaus toegepast:
1. **Pokeball en Charmander**: De class `Pokeball` heeft een property:
   ```csharp
   public Charmander? ContainedPokemon { get; private set; }
   ```
   Hierdoor *heeft* een Pokeball een Charmander in zich zonder erven van Charmander.
2. **Trainer en Pokeball**: De class `Trainer` heeft een riem met een lijst van Pokeballs:
   ```csharp
   public List<Pokeball> Belt { get; private set; } = new List<Pokeball>();
   ```
   Een Trainer *heeft* een lijst van 6 Pokeballs op zijn riem. Wanneer de Trainer wordt aangemaakt, maakt de constructor 6 Pokeballs aan met elk een Charmander erin.

*(Aantal woorden: ~140 woorden)*

---

## Belangrijke begrippen voor je mondelinge overhoring

| Begrip | Betekenis in gewone taal | Waar te vinden in onze code |
| :--- | :--- | :--- |
| **`null`** | Geeft de afwezigheid van een object aan. Een lege Pokeball bevat `null`. | `Charmander? ContainedPokemon = null;` |
| **`List<T>`** | Een dynamische lijst uit C# die kan groeien/krimpen (in tegenstelling tot een vaste array). | `public List<Pokeball> Belt = new List<Pokeball>();` |
| **`Exception`** | Een foutmelding-object dat 'gegooid' wordt als er iets misgaat (bijv. meer dan 6 ballen op de riem). | `throw new Exception("Belt limit exceeded!");` |
| **`try` / `catch`** | Voorkomt dat het programma crasht bij een fout. De code draait in `try`, en eventuele fouten vang je op in `catch`. | `try { trainer.AddPokeball(extra); } catch (Exception ex) { ... }` |
| **Composition** | Een "heeft-een" relatie: een object dat bestaat uit andere objecten als bouwstenen. | `Trainer` heeft een `List<Pokeball>`, `Pokeball` heeft een `Charmander`. |
