# Retired Life — Sprint 2 (W201)

[![Unity](https://img.shields.io/badge/Unity-2022.3.62f2-LTS)]()
[![Status](https://img.shields.io/badge/Status-Sprint%202%20Delivered-brightgreen)]()
[![Platform](https://img.shields.io/badge/Platform-PC%20(Windows%2FmacOS)-blue)]()

> A 2D pixel farming RPG with life-sim loops. This README follows the structure recommended by **makeareadme.com**.

---

## Table of Contents
- [About the Project](#about-the-project)
- [Features](#features)
- [Screenshots](#screenshots)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Run & Play](#run--play)
- [Usage](#usage)
- [Completed User Stories (Sprint 2)](#completed-user-stories-sprint-2)
- [Roadmap](#roadmap)
- [Tests](#tests)
- [Contributing](#contributing)
- [License](#license)
- [Authors and Acknowledgment](#authors-and-acknowledgment)
- [FAQ](#faq)
- [Project Status](#project-status)

---

## About the Project
**Retired Life** is a Unity-based 2D pixel game inspired by farming/life-sim titles (e.g., Stardew Valley).  
This sprint focused on the **foundational gameplay loops**: inventory UI, farming cycle, fishing + economy, movement across scenes, and basic audio ambiance.

**Why this project?**
- To build a modular life-sim with room for future systems: **combat across the map**, **occupations with level-based skill unlocks**, **more equipment/weapon**, and **multiplayer**.

---

## Features
- Item Bar & Inventory display
- Harvest-to-inventory flow for crops
- Interactable multi-plot farming
- Player movement + animation in **all scenes**
- Market Place scene with **collision** and **buy/sell**
- Fishing in **rivers & oceans** (varied fish types)
- Sell fish for income; money HUD display
- Discard/Pick-up for inventory management
- In‑game **date & time** display
- Background music

> See the **Completed User Stories** section for full details and verification steps.

---

## Screenshots


---

## Getting Started

### Prerequisites
- **Unity 2022.3.62f2 LTS**
- Recommended: Unity modules for Windows/macOS build targets
- (Optional) URP & **Pixel Perfect Camera** for crisp pixel rendering

### Installation
```bash
# Clone your repository
git clone <YOUR_REPO_URL> retired-life
cd retired-life

# Open the folder in Unity Hub and launch with Unity 2022.3.62f2
```

### Run & Play
1. Open a playable scene (e.g., **Farm**, **MarketPlace**, **Fishing**).
2. Press **Play** in the Unity Editor.
3. Use **WASD/Arrow keys** to move, **E/Enter** to interact (adjust if your project uses different bindings).

---

## Usage
- **Farming**: Plant → Grow → Harvest (produce auto‑adds to inventory).
- **Fishing**: Interact at rivers/oceans → catch various fish types → inventory.
- **Economy**: Visit **Market Place** to buy/sell. The **Money HUD** updates instantly.
- **Inventory QoL**: Discard to free space; pick up items when space allows.
- **Time & Date**: Shown on the HUD for planning your day.
- **Audio**: Background music provides ambient feel.

---

## Completed User Stories (Sprint 2)
| Area | User Story (As a player, I want to…) | Priority | Status | Owner(s) |
|---|---|---|---|---|
| UI & Inventory | have a **clear UI item bar** to know what I have in my inventory. | Should Have | **Dev:** Cyrus · **Tester:** Kandy |
| Farming | **harvest grown crops** and have them **automatically added** to my inventory. | Should Have | **Dev:** Kyla · **Tester:** Ahmad |
| Farming / Movement | **move around the farm** and interact with **multiple plots** to manage planting/growing/harvesting. | Should Have | **Dev:** Kyla · **Tester:** Kandy |
| Core Controls | have **player movement and animation across all scenes**. | Should Have | **Dev:** Ahmad · **Tester:** Kandy |
| Economy | explore a **Market Place** with **collision** to **buy/sell** items. | **Must Have** | **Dev:** Ahmad · **Tester:** Cyrus |
| Fishing | **fish in rivers and oceans** to collect items or earn money. | Should Have | **Dev:** Kandy · **Tester:** Cyrus |
| Progression | **collect resources** to progress. | **Must Have** | Tested by Ahmad & Kandy |
| Audio | have **background music**. | Could Have | **Dev:** Kandy |
| Inventory QoL | **discard** & **pick up** items to manage inventory space. | Could Have | **Dev:** Kandy |
| Time UI | **see in‑game date and time** for planning. | Could Have | **Dev:** Kandy |
| Money UI | **see current money** (incl. sales returns). | **Must Have** | **Dev:** Kandy |
| Fishing Variety | **catch different fish types** for satisfaction. | **Must Have** | **Dev:** Kandy |
| Fishing Economy | **sell fish for money** to progress. | **Must Have** | **Dev/Tester:** Kandy |

> **Verification tips**: Enter Play Mode and walk through each row above. Ensure UI elements update live and scene collisions/interactions behave as expected.

---

## Roadmap
Planned major systems (post‑Sprint 2):
- **Combat across the map**
- **Occupations** with **skill unlocks** by job level
- **More equipment & weapons**
- **Multiplayer** core loop

See the open issues for a full list of proposed features and known issues.

---

## Tests
Manual test checklist for a quick pass:
- [ ] Item bar reflects items; updates on add/remove.
- [ ] Harvest adds produce directly to inventory.
- [ ] Player movement + animations work in **every** scene.
- [ ] Market Place: collision works; buy/sell updates money.
- [ ] Fishing works at water; different fish types appear; **selling fish** changes money.
- [ ] Inventory: can discard and pick items; capacity respected.
- [ ] In‑game date/time visible.
- [ ] Background music audible.

*(If you add automated tests later, document how to run them here.)*

---

## Contributing
Contributions are welcome!  
1. Fork the repo and create a feature branch: `git checkout -b feat/your-feature`  
2. Commit with clear messages: `git commit -m "feat(fishing): add rare fish type"`  
3. Push and open a Pull Request.  

Coding tips:
- Keep scripts focused and component-based.
- Prefer ScriptableObjects for data where appropriate.
- Maintain pixel scale and use **Pixel Perfect Camera** in 2D scenes.

---

## License
> **Education/Project use only** during development.  
No explicit open‑source license has been chosen yet. If you wish to use this project, please open an issue to discuss licensing.  
(If you decide on MIT/Apache/etc., add a `LICENSE` file and reference it here.)

---

## Authors and Acknowledgment
- **Cyrus** — Developer, Tester
- **Kyla** — Developer, Tester
- **Ahmad** — Developer, Tester
- **Kandy** — Developer, Tester

Thanks to Unity’s 2D tooling (Tilemaps, Pixel Perfect Camera) and the open knowledge community.

---

## FAQ
**Q: Which Unity version should I use?**  
A: Unity **2022.3.62f2 LTS**.

**Q: Are controls configurable?**  
A: Yes—adjust in the Input System/Project Settings if your project uses custom bindings.

**Q: Where do I sell fish?**  
A: At the **Market Place**; your **Money HUD** updates on sale.

**Q: Why can’t I walk through certain objects?**  
A: Colliders are enabled in scenes by design to shape navigation and interactions.

---

## Project Status
**Sprint 2** is **delivered**. The next milestone targets combat, occupations/skills, expanded equipment, and multiplayer.

---
