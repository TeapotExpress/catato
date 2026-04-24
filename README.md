# Catato ₍^. .^₎⟆

A survival shooter inspired by **Brotato**, built in Unity as a 2-week academic project.

The player fights through endless waves of enemies, collecting XP to level up and allocate stats — with the goal of surviving as long as possible.

▶️ [Play in browser on itch.io](https://teapotexpress.itch.io/catato) — best experienced in fullscreen due to static resolution

---

## Gameplay

- **Wave-based combat** — enemies spawn in escalating waves, each with HP and distinct behavior
- **3 enemy types** with individual HP pools
- **XP & leveling system** — killing enemies drops XP; on level up, the player chooses one of three stats to increase
- **Player stats:**
  - Damage
  - Speed
  - Rate of Fire
- **Survival loop** — game ends on player death; no win condition, only a better run

---

## My Contributions

I was one of two programmers on this project, responsible for:

**Progression & RPG systems**
- XP collection and level threshold logic (`CatExp.cs`)
- Stat application to player combat and movement parameters

**Combat & enemies**
- Player HP, damage intake, and death handling (`CatHp.cs`, `HpBar.cs`)
- Enemy HP, death, and attack logic (`EnemyHp.cs`, `EnemyAttack.cs`)

**Player systems**
- Camera rotation with quaternion lerp (`CameraRot.cs`)
- Paw particle emitter with directional rotation (`PawEmitter.cs`)

**Game feel**
- Sound effects manager with optional volume/pitch overrides (`SFXManager.cs`)

---

## What I'd Do Differently

This was a very early project. Looking back, I'd restructure it with:

- A base `Enemy` class with shared HP/death logic, extended per enemy type
- An `IDamageable` interface to decouple damage sources from targets
- Event-driven stat changes instead of direct value mutation
- Scriptable Objects for stat definitions to make tuning easier without touching code
- Stats are stored in PlayerPrefs — a pattern introduced by my teammate. I'd replace this with a ScriptableObject or static data class for runtime state rather than persistent storage

---

## Stack

- **Engine:** Unity
- **Language:** C#
- **Duration:** 2 weeks (academic team project, first semester)

---

## Running the Project

▶️ [Play in browser on itch.io](https://teapotexpress.itch.io/catato) — best experienced in fullscreen due to static resolution

**OR**
1. Clone the repository
2. Open in Unity Hub (Unity 2022.3.49f1)
3. Open the main scene and hit Play

> ⚠️ Some weapon types are present in code but not fully integrated into the playable build.
