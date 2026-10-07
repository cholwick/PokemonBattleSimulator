# OOP Cheatsheet - Opdracht 1 (Nederlands)

> **Let op:** In de opdracht staat: *"Je beantwoordt de volgende vragen in het Engels met minimaal 100 woorden in jouw cheatsheet."* 
> Deze Nederlandse versie is ideaal om de theorie écht goed te begrijpen en je voor te bereiden op de **mondelinge uitleg**. De Engelse versie staat in `Cheatsheet_Opdracht_1.md` voor het inleveren!

---

## Vraag 1: Waarom zou je code willen schrijven in een object-georiënteerde programmeertaal (OOP)?

Het schrijven van code in een object-georiënteerde programmeertaal (zoals C# of Java) stelt ontwikkelaars in staat om software te modelleren rondom herkenbare concepten en entiteiten uit de echte wereld, in plaats van alleen een lange lijst met opeenvolgende instructies (zoals bij procedureel programmeren). Binnen OOP wordt een programma opgedeeld in op zichzelf staande 'objecten' die zowel hun eigen gegevens (eigenschappen en data) als hun eigen gedrag (functies en methoden) combineren.

Een belangrijk voordeel hiervan is modulariteit en onderhoudbaarheid. Naarmate een project groter wordt, wordt procedurele code snel onoverzichtelijk en foutgevoelig: een kleine wijziging op één plek kan onverwacht elders iets kapotmaken. OOP lost dit op met **inkapseling (encapsulation)**, waarbij interne data van een object beschermd blijft tegen ongeoorloofde aanpassingen van buitenaf. Hierdoor zijn bugs veel eenvoudiger te isoleren en op te lossen.

Daarnaast zorgt OOP voor herbruikbaarheid van code. Door concepten zoals **overerving (inheritance)** en **polymorfisme (polymorphism)** kun je een algemene basisklasse maken en deze uitbreiden zonder steeds opnieuw het wiel uit te vinden. Dit maakt samenwerken in een team veel overzichtelijker, houdt de codebase gestructureerd en zorgt ervoor dat applicaties makkelijk kunnen meegroeien.

*(Aantal woorden: ~170 woorden)*

---

## Vraag 2: Wat is het verschil tussen een class en een object?

Het verschil tussen een class en een object kun je het beste vergelijken met het verschil tussen een **bouwtekening** en het **werkelijke huis** dat aan de hand van die tekening is gebouwd.

Een **class** is een abstracte blauwdruk of sjabloon. Het beschrijft welke eigenschappen (variabelen/fields) een entiteit heeft en welke acties (methods) het kan uitvoeren. Echter, de class zelf bestaat nog niet als een tastbaar stukje data in het werkgeheugen. In ons project is de `Charmander` class bijvoorbeeld de blauwdruk: het legt vast dat iedere Charmander een bijnaam heeft, sterk is tegen Fire, zwak is tegen Water, en een BattleCry kan doen.

Een **object** daarentegen is een concrete, werkelijke instantie die met behulp van het keyword `new` in het computergeheugen wordt aangemaakt op basis van die blauwdruk. Als je in C# schrijft: `new Charmander("Sparky", "Fire", "Water")`, creëer je een uniek object met zijn eigen specifieke data en naam. Vanaf dezelfde class kun je oneindig veel verschillende unieke objecten maken, elk met hun eigen bijnaam.

*(Aantal woorden: ~160 woorden)*

---

## Belangrijke C# Keywords voor Opdracht 1

| Keyword | Betekenis & Doel | Voorbeeld in code |
| :--- | :--- | :--- |
| **`class`** | Het sleutelwoord om een nieuwe blauwdruk/type te definiëren met daarin fields, constructors en methods. | `public class Charmander { ... }` |
| **`new`** | Maakt een daadwerkelijk object (instantie) aan in het geheugen op basis van de class en roept de constructor aan. | `Charmander c = new Charmander("Charry", "Fire", "Water");` |
| **`void`** | Geeft aan dat een method een actie uitvoert, maar **geen** waarde teruggeeft (geen `return`). | `public void BattleCry() { ... }` |
| **`null`** | Geeft aan dat een variabele leeg is en naar niets wijst in het geheugen (afwezigheid van een object). | `string? input = null;` |
