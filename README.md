# Treasure Hunt

*Truy Tìm Kho Báu* — a 2D side-scrolling platformer built with Unity. Guide the hero through three levels, shoot down monsters with your bow, avoid water and traps, light up the lamp posts to open the gates and reach the treasure.

## Features

- 3 levels plus a main menu with an in-game "How to play" screen
- Bow and arrow combat with a fire cooldown
- Health system (hearts UI) and score counter
- Moving platforms, bounce pads and lamp-post switches that open doors
- Background music and sound effects, win / game-over screens
- Pause at any time

## Controls

| Key | Action |
| --- | --- |
| `←` `→` / `A` `D` | Move |
| `Space` | Jump |
| `H` | Shoot arrow |
| `P` | Pause / resume |

## Requirements

- Unity **2022.3.16f1** (LTS)
- Packages: 2D feature set, Cinemachine, TextMeshPro (restored automatically from `Packages/manifest.json`)

## Getting started

1. Clone the repository:
   ```bash
   git clone https://github.com/youngboi03/TreasureHunt.git
   ```
2. Open the folder with Unity Hub using Unity 2022.3.16f1. The first import rebuilds the `Library/` folder and can take a few minutes.
3. Open `Assets/Scenes/Menu.unity` and press **Play**.

To build: **File → Build Settings**, check that the scenes are in this order — `Menu`, `Man1`, `Man2`, `Man3` — then **Build**.

## Project structure

```
Assets/
├── DoHoa/      # Sprites, tilesets, animations (graphics)
├── music/      # Background music and sound effects
├── Scenes/     # Menu, Man1, Man2, Man3
└── Scrips/     # Gameplay C# scripts
```

### Main scripts

| Script | Purpose |
| --- | --- |
| `dichuyen.cs` | Player movement, jumping, shooting animation, pause |
| `VaCham.cs` | Player health, damage, win / game-over handling |
| `prefabArow.cs` / `Arow.cs` | Spawning arrows and arrow hit logic |
| `Score.cs`, `Mau.cs` | Score text and heart (health) UI |
| `traiphai.cs`, `lenxuong.cs`, `thuhoangdadichuyen.cs` | Moving platforms and patrolling monsters |
| `donbay.cs` | Bounce pad |
| `vachamtruden.cs`, `trudenTat.cs`, `toe.cs` | Lamp-post switches and doors |
| `audio.cs` | Music and sound-effect playback |
| `button.cs` | Menu buttons and scene loading |

## Optimizations

- UI (score, hearts) updates only when the value changes instead of every frame
- Cached lookups instead of `GameObject.Find` on every hit; `CompareTag` instead of string comparison
- Animator parameters use cached hashes
- Background follows the camera in `LateUpdate` to avoid jitter
- Long music tracks use **Streaming** load type to reduce memory usage
- Fixed: moving platform never released the player after they stepped off
- Fixed: game could stay frozen (`timeScale = 0`) after returning to the menu
- Fixed: repeated hits after game over could replay the end screen
