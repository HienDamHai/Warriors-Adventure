# Warrior's Adventure

A 2D pixel-art action/adventure game built with Unity and C#. Fight monsters and a boss, grow stronger as you level up, and recover the stolen sacred crown.

> University course team project (3 members) · June 2025 – July 25, 2025 · Windows standalone

## Demo

[Watch the gameplay video](https://drive.google.com/file/d/1oLLGWwxrubLY_0acVfYNdb3GdR6DLxtf/view?usp=sharing)

## Screenshots

### Scenes

| Main Menu |
| --- |
| ![Main Menu](Assets/GamePlay/MainMenu.png) | ![Map 1](Documentation/Screenshots/Scenes/map-1.png) |

| Map 1: The Forest of Monsters | |
|:---:|:---:|
| **Village** | **Mountain** |
| ![Village](Assets/GamePlay/Village.png) | ![Mountain](Assets/GamePlay/Mountain.png) |
| **River** | **Forest** |
| ![River](Assets/GamePlay/River.png) | ![Forest](Assets/GamePlay/Forest.png) |

| Map 2: Banger of Death Castle | |
|:---:|:---:|
| **Castle** | **Boss Room** |
| ![Castle](Assets/GamePlay/Castle.png) | ![Boss Room](Assets/GamePlay/Boss.png) |

| Shop | Stats panel | Stat upgrade panel |
| --- | --- | --- |
| ![Shop](Assets/GamePlay/Shop.png) | ![Stats](Assets/GamePlay/Stats.png) | ![Upgrade](Assets/GamePlay/Skills.png) |

### Characters

| The Warrior | Torch Red | Lancer | Thief | Boss |
| --- | --- | --- | --- | --- |
| ![Warrior](Assets/GamePlay/Player.png) | ![Torch Red](Assets/GamePlay/Torch.png) | ![Lancer](Assets/GamePlay/Lancer.png) | ![Thief](Assets/GamePlay/Thief.png) | ![Boss](Assets/GamePlay/BangerOfDeath.png) |

### Items

| Pumpkin | Mushroom | Meat | Gold | Treasure Chest | EXP Potion | Secret Key |
| --- | --- | --- | --- | --- | --- | --- |
| ![Pumpkin](Assets/GamePlay/Pumbkin.png) | ![Mushroom](Assets/GamePlay/Mushroom.png) | ![Meat](Assets/GamePlay/Meat.png) | ![Gold](Assets/GamePlay/Gold.png) | ![Chest](Assets/GamePlay/Chest.png) | ![EXP Potion](Assets/GamePlay/Exp.png) | ![Key](Assets/GamePlay/Key.png) |

## Story

The peaceful kingdom was thrown into chaos when its sacred crown was stolen by a mysterious dark force. As a brave warrior, you must set out on a dangerous journey, defeat monsters and powerful bosses, and recover the crown to restore peace to the kingdom.

## Features

- Player movement and sword combat (melee attack)
- Enemy AI: monsters detect and attack the player
- Boss fight with its own behavior and attacks
- Health system
- Experience and leveling: stats increase on level-up
- Character stat upgrades: Health, Damage, Run Speed, Attack Speed
- Quick-access item slots (3 slots) at the top corner
- Shop with a shopkeeper
- Scoring: points for defeating enemies and collecting gold
- Secret key and secret room with treasure
- Game Over / Game Win screens with a summary, retry and return to Main Menu

## Gameplay

1. Explore the map as the Warrior.
2. Defeat monsters with sword attacks to earn score and EXP.
3. Collect gold and items, and spend gold in the shop.
4. Level up and upgrade your stats.
5. Find the secret key to open the secret room.
6. Defeat the boss and recover the crown.
7. After winning or losing, see the summary and choose to replay or return to the Main Menu.

## Enemies and Boss

| Name | Damage | Speed | Attack Range | Health | Notes |
| --- | --- | --- | --- | --- | --- |
| Torch Red | 30 | 2 | 1 | 5 | Fast-burning with low health and short range. Easy to defeat when approached carefully. |
| Lancer | 40 | 2 | 2 | 30 | Balanced stats, attacks from medium range, good durability. |
| Thief | 50 | 5 | 2 | 10 | Very fast and deadly, low health but hard to hit. |
| Banger of Death (Boss) | 120 | 7 | 2 | 300 | Extremely powerful boss with high speed and devastating damage. Final challenge. |

## Items and Scoring

| Item | Effect |
| --- | --- |
| Gold | Currency used in the shop |
| EXP Potion | Grants EXP |
| Pumpkin | Damage buff |
| Mushroom | Restores health |
| Meat | Restores health |
| Treasure Chest | Found in the secret room |
| Secret Key | Hidden somewhere in the adventure; opens the secret room |

| Target | Points |
| --- | --- |
| Torch Red | 10 |
| Lancer | 15 |
| Thief | 20 |
| Boss | 100 |
| Gold | 5 per gold |

## Controls

| Action | Control |
| --- | --- |
| Move | `W` `A` `S` `D` |
| Attack | Left mouse button |
| Open Shop | `K` |
| Open upgrade panel | `M` |
| Open Stats | `N` |
| Use item | Left click on item |
| Drop item | Right click on item |

## Tech

- Engine: Unity 6 (6000.1.3f1)
- Language: C#
- Tilemap, Collider2D, Prefabs
- Platform: Windows standalone

## Getting Started

1. Install Unity Hub and Unity Editor 6000.1.3f1.
2. Clone this repository and open the folder from Unity Hub.
3. Open the Main Menu scene and press Play.
4. To build for Windows: **File → Build Profiles → Windows → Build**.

## My Contributions

I worked in a team of 3. My parts:

- **Player:** built the main character, its actions and animations, and the sword attack.
- **Enemies and boss:** built the monsters, their attack behavior and combat interaction with the player; balanced HP and damage.
- **Level design:** built the map (mountains, roads, forests, rivers, castles) and took part in the story.
- **Progression:** EXP and leveling, stat upgrades (Health, Damage, Run Speed, Attack Speed) and the stats screen.
- **Game flow:** damage handling, enemy detection, enemy death with score and EXP rewards, secret room and secret key, and the Game Over / Game Win screens with summary, retry and Main Menu.

## Credits

- [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords) asset pack by Pixel Frog.
- Other free assets found online, combined with AI-generated assets.
