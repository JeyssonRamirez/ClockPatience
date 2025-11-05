# 🕐 Clock Patience Game (C# SOLID Architecture)

A console-based implementation of the **Clock Patience** card game, designed with **SOLID principles** and a **clean Nlayer architecture** in C#.
This project demonstrates a clear separation of concerns across multiple layers (1.Presentation, 2.Application, 3.Core, 4.Data, 5.Crosscutting, and 6.IoC).

---

## 📖 Problem Description

The Clock Patience (also known as “Clock Solitaire”) is a card game played with a standard deck of 52 cards.
Cards are dealt face down into 13 piles representing clock positions (1 to 12 and the center for Kings).

Check the Technical Exercisepdf file in /docs

Gameplay:

1. Deal four cards to each pile (52 cards total).
2. Start by turning over the top card of the **King pile (center)**.
3. Place the revealed card face up under the pile corresponding to its rank:

   * A → 1 o’clock pile
   * 2 → 2 o’clock pile
   * ...
   * K → King (center)
4. Expose the next card from that pile and repeat.
5. The game ends when the required pile is empty.
6. You win if **all 52 cards** are exposed.

---

## 🧩 Project Structure

```
ClockPatience/
├── Presentation/
│   └── Program.cs
├── Application/
│   ├── Application.Definition (Interfaces)/
│   │   └── ICardParser.cs
│   │   └── IGameEngine.cs
│   │   └── IClockPatienceService.cs
│   └── Application.Implementation (Implementation)/
│       └── CardParser.cs
│       └── ClockPatienceGameEngine.cs
│       └── ClockPatienceService.cs
├── Core/
│   ├── Entities/
│   │   ├── Card.cs
│   │   ├── CardType.cs
│   │   ├── GameResult.cs
│   │   ├── Pile.cs
├── Data/
│   └── IInputReader.cs (Interface)
│   └── ConsoleInputReader.cs
│   └── IOutputWriter.cs (Interface)
│   └── ConsoleOutputWriter.cs
├── Crosscutting/
│   ├── Extension/
│   │   ├── CustomEnumExtensions.cs
│   │   ├── StringValueAttribute.cs
│   └── SelectListItemDto.cs.cs
├── IoC/
│   └── DependencyInjection.cs
```

---

## ⚙️ Layers Description

| Layer            | Responsibility                                                                    |
| ---------------- | --------------------------------------------------------------------------------- |
| **Presentation** | Console app for user input/output. Depends on `IClockPatienceService`.            |
| **Application**  | Implements game orchestration and exposes use cases.                              |
| **Core**         | Contains the domain entities and business logic (game rules).                     |
| **Data**         | Handles input deck reading from console.                                          |
| **Crosscutting** | Shared utilities, constants, and helpers.                                         |
| **IoC**          | Configures Dependency Injection using `Microsoft.Extensions.DependencyInjection`. |

---

## 🧠 Technologies Used

* **.NET 8 / C# 12**
* **xUnit** for unit testing
* **FluentAssertions** for expressive assertions
* **Moq** for mocking interfaces
* **SOLID principles** applied to all layers
* **Dependency Injection (IoC)** via `ServiceCollection`

---

## 🚀 Running the App

### 1. Clone the Repository

```bash
git clone https://github.com/JeyssonRamirez/ClockPatience.git
cd ClockPatience
```

### 2. Build

```bash
dotnet build
```

### 3. Run

```bash
dotnet run --project Presentation.ConsoleGame
```

### 4. Input Format

Enter decks as four lines of 13 cards each (cards separated by spaces).
Each card has rank + suit (e.g., `AS`, `TD`, `KC`).
End input with `#`.

#### Example:

```
TS QC 8S 8D QH 2D 3H KH 9H 2H TH KS KC
9D JH 7H JD 2S QS TD 2C 4H 5H AD 4D 5D
6D 4S 9S 5S 7S JS 8H 3D 8C 3S 4C 6S 9C
AS 7C AH 6H KD JC 7D AC 5C TC QD 6C 3C
#
```

#### Output:

```
44,KD
```

---


## 📐 SOLID Principles Used

* **S**ingle Responsibility — each class has one purpose (Card, Game, Service, etc.)
* **O**pen/Closed — logic is extensible without modifying core entities
* **L**iskov Substitution — abstractions (interfaces) are replaceable
* **I**nterface Segregation — clean interfaces for specific responsibilities
* **D**ependency Inversion — high-level modules depend on abstractions, not concrete implementations

---

## 🧑‍💻 Author

**Jeysson Ramirez**
Senior Software Developer & Technical Leader
.NET | C# | Azure | Clean Architecture | SOLID

---

## 🏁 License

This project is open-source under the **MIT License**.
