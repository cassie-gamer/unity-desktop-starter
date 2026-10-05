# Unity Desktop Starter — Full Run Guide (Windows)

A tiny 3D "move and collect" game for Windows. Move a cube with WASD / arrow keys, collect spinning spheres for points, beat the 60-second timer.

This guide assumes you've never opened Unity before. Follow it top to bottom.

---

## Part 1 — Install everything (one time, ~15 minutes)

### 1. Install Unity Hub
1. Go to https://unity.com/download
2. Download **Unity Hub** for Windows and run the installer
3. Open Unity Hub and sign in with a free Unity ID (create one if you don't have it)

### 2. Install the Unity Editor
1. In Unity Hub, go to **Installs** → **Install Editor**
2. Pick the latest **LTS** version (Long Term Support — most stable, e.g. 6000.x LTS)
3. On the modules screen, check:
   - ✅ **Microsoft Visual Studio Community** (code editor — say yes when it prompts)
   - ✅ **Windows Build Support (IL2CPP)**
4. Click Install and wait — this downloads a few GB, good time for a break

### 3. Install Git (for the repo)
1. Go to https://git-scm.com/download/win
2. Run the installer, keep all defaults, click through
3. To verify: open **PowerShell** and type `git --version` — you should see a version number

---

## Part 2 — Get the code

### Option A: Clone from GitHub (recommended)
Open PowerShell and run:

```powershell
git clone https://github.com/cassie-gamer/unity-desktop-starter.git
cd unity-desktop-starter
```

You'll get:
```
unity-desktop-starter/
├── README.md
├── .gitignore
└── Assets/
    └── Scripts/
        ├── PlayerMover.cs
        ├── PickupSpinner.cs
        ├── ScoreManager.cs
        └── GameTimer.cs
```

### Option B: Download ZIP
If you don't want git: open https://github.com/cassie-gamer/unity-desktop-starter in a browser → **Code** → **Download ZIP** → extract it somewhere.

---

## Part 3 — Create the Unity project

1. Open **Unity Hub** → **Projects** → **New project**
2. Select **3D (Core)** template (not 2D, not URP for this starter)
3. Project name: `MyFirstGame`
4. Location: anywhere, e.g. `C:\Users\YourName\UnityProjects\`
5. Click **Create project** — Unity opens the Editor (takes a minute first time)

### Copy the scripts in
1. In Windows File Explorer, open your new Unity project folder → `Assets`
2. Create a folder called `Scripts` inside `Assets` if it doesn't exist
3. Copy these 4 files from the cloned repo into `Assets\Scripts\`:
   - `PlayerMover.cs`
   - `PickupSpinner.cs`
   - `ScoreManager.cs`
   - `GameTimer.cs`
4. Back in Unity, you'll see them appear under **Project** → **Assets** → **Scripts**
   - If Unity shows compile errors at the bottom, click **Console** to see them — with these files there should be none

---

## Part 4 — Build the scene (step by step)

You start with a default scene containing **Main Camera** and **Directional Light**. Keep both.

### 4.1 — The player (a cube)
1. In the **Hierarchy** panel (left), right-click → **3D Object** → **Cube**
2. With the Cube selected, in the **Inspector** (right):
   - Click **Add Component**, type `PlayerMover`, press Enter (attaches the movement script)
   - Click **Add Component**, type `Rigidbody`, press Enter (leave all defaults)
     - This is needed so pickups can detect touching the player
3. Rename it to `Player` (click the name in Hierarchy, or F2)

### 4.2 — The ground (a plane)
1. Right-click Hierarchy → **3D Object** → **Plane**
2. With the Plane selected, in Inspector set **Transform → Scale** to `X: 10, Y: 1, Z: 10`
3. Leave it at position `0, 0, 0`

### 4.3 — Pickups (spheres)
1. Right-click Hierarchy → **3D Object** → **Sphere**
2. In Inspector:
   - **Transform → Scale**: `0.5, 0.5, 0.5`
   - **Transform → Position**: something like `3, 0.5, 2` (sitting just above the plane)
   - Expand **Sphere Collider**, check ✅ **Is Trigger**
   - **Add Component** → type `PickupSpinner` → Enter
3. Duplicate it: select the sphere, press **Ctrl+D** 6–8 times
4. Move each duplicate to a different spot on the plane (change Position X/Z between -8 and 8, keep Y at 0.5)

### 4.4 — GameManager (score + timer logic)
1. Right-click Hierarchy → **Create Empty**
2. Rename it to `GameManager`
3. **Add Component** → `ScoreManager`
4. **Add Component** → `GameTimer`

### 4.5 — UI (score and timer text)
1. Right-click Hierarchy → **UI** → **Canvas** (this holds UI elements)
2. Right-click the new **Canvas** → **UI** → **Text - TextMeshPro**
   - If Unity asks to import TMP Essentials, click **Import**
3. Rename this text to `ScoreText`
   - In Inspector, set its **Rect Transform** anchors to top-left
   - Set **Position** roughly X: 120, Y: -30 (tweak as needed)
   - Change the text to `Score: 0`, make font size ~24, color white
4. Right-click **Canvas** → **UI** → **Text - TextMeshPro** again
5. Rename to `TimerText`
   - Anchors to top-right, Position roughly X: -120, Y: -30
   - Text `Time: 60`, font size ~24, color white
6. Select **GameManager** in Hierarchy:
   - Drag **ScoreText** from Hierarchy into the **Score Text** slot on the ScoreManager component
   - Drag **TimerText** into the **Timer Text** slot on the GameTimer component

### 4.6 — Camera
1. Select **Main Camera**
2. In Inspector set **Transform**:
   - Position: `X: 0, Y: 10, Z: -8`
   - Rotation: `X: 45, Y: 0, Z: 0`
3. This gives a nice angled top-down view of the plane

### 4.7 — Save
Press **Ctrl+S**. Save the scene as `MainScene` in `Assets\Scenes\` when prompted.

---

## Part 5 — Press Play and test

1. Click the **▶ Play** button at the top of the Editor
2. Click inside the **Game** view so it captures your keyboard
3. Move with **WASD** or **arrow keys**
4. Touch the spheres — they spin, disappear, and your score goes up
5. The timer counts down from 60. At 0, the player freezes.
6. Click **⏸ Pause** or **▶ Play** again to stop

### If it doesn't work — quick checklist
- [ ] Player has **Rigidbody** AND **PlayerMover**?
- [ ] Each sphere has **Is Trigger** checked AND **PickupSpinner**?
- [ ] Spheres are at Y ≈ 0.5 (not buried under the plane)?
- [ ] GameManager has both scripts, and both Text slots are filled (not "None")?
- [ ] Any red errors in the **Console**? (Window → General → Console) — read the first one, it usually names the script and line

---

## Part 6 — Build a real Windows .exe

1. **File** → **Build Settings**
2. Click **Add Open Scenes** (adds your current scene)
3. On the left select **PC, Mac & Linux Standalone**
4. Set **Target Platform**: `Windows`
5. Set **Architecture**: `x86_64` (64-bit)
6. Click **Build**
7. Create/choose a folder like `C:\Users\YourName\UnityProjects\MyFirstGame\Builds\Windows\`
8. Wait — Unity compiles and gives you `MyFirstGame.exe` plus a `_Data` folder
9. Double-click the `.exe` to play! Share the whole folder if you send it to a friend.

> Note: keep the `.exe` and its `_Data` folder together — the game won't run without both.

---

## Part 7 — What each script does

**PlayerMover.cs**
- `Update()` runs every frame
- `Input.GetAxis("Horizontal")` → A/D or ←/→ as -1 to 1
- `Input.GetAxis("Vertical")` → W/S or ↑/↓ as -1 to 1
- Multiplies by `speed * Time.deltaTime` so movement is smooth and framerate-independent
- `transform.Translate(...)` moves the cube

**PickupSpinner.cs**
- `Update()` spins the sphere with `transform.Rotate`
- `OnTriggerEnter()` fires when the player enters its trigger → calls `ScoreManager.Instance.AddPoint()` → hides itself

**ScoreManager.cs**
- Singleton (`Instance`) so pickups can reach it from anywhere
- `AddPoint()` increments score and updates the UI text

**GameTimer.cs**
- Counts down `timeLeft` every frame
- Updates the timer UI with `Mathf.CeilToInt`
- At 0: disables `PlayerMover` so the player freezes

---

## Part 8 — Ideas to try next

- **Respawning pickups**: instead of `SetActive(false)`, move the pickup to a random X/Z and keep it active
- **Win condition**: when score reaches total pickups, show "You Win!" text
- **Sound**: add an AudioSource to the player, call `PlayOneShot` in `OnTriggerEnter`
- **Better movement**: replace `Translate` with Rigidbody physics (`AddForce`) for momentum

Want the code for any of these? They each live in this same repo — just ask.
