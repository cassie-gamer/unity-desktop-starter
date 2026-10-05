# Unity Desktop Starter - Your First Tiny Game (Windows)

This is a super simple 3D "move and collect" game for Windows. You move a cube with WASD, collect spinning pickups for score, against a 60-second timer.

## 1. Install (one time, on your Windows PC)

1. Download **Unity Hub** from unity.com
2. In Unity Hub, install the latest **LTS** version of the Unity Editor
   - Make sure **Windows Build Support (IL2CPP)** is checked during install
3. Unity will prompt to install Visual Studio Community - say yes, it's the easiest code editor for Unity

## 2. Create the project

1. Open Unity Hub -> New Project
2. Choose **3D (Core)** template
3. Name it `MyFirstGame`, pick a location, click Create
4. Copy all the `.cs` files from this starter into your project's `Assets/Scripts/` folder

## 3. Build your scene (15 minutes)

**Player:**
1. Right-click Hierarchy -> 3D Object -> Cube. This is your player.
2. Add Component -> `PlayerMover` (from PlayerMover.cs)
3. Add Component -> Rigidbody (leave defaults)

**Ground:**
1. Right-click Hierarchy -> 3D Object -> Plane
2. Scale to 10, 1, 10

**Pickups:**
1. Right-click Hierarchy -> 3D Object -> Sphere, scale to 0.5
2. Check **Is Trigger** on its Sphere Collider
3. Add Component -> `PickupSpinner`
4. Duplicate with Ctrl+D and spread 6-8 around the plane

**GameManager (score + timer):**
1. Right-click Hierarchy -> Create Empty, name it `GameManager`
2. Add Component -> `ScoreManager`
3. Add Component -> `GameTimer`

**UI (score and timer text):**
1. Right-click Hierarchy -> UI -> Canvas
2. Right-click the Canvas -> UI -> Text - TextMeshPro (import TMP if asked)
3. Name it `ScoreText`, position top-left, text "Score: 0"
4. Duplicate it, name it `TimerText`, position top-right, text "Time: 60"
5. Select GameManager:
   - Drag ScoreText into ScoreManager's **Score Text** slot
   - Drag TimerText into GameTimer's **Timer Text** slot

**Camera:**
- Position X: 0, Y: 10, Z: -8, Rotation X: 45 so you see the whole plane

Press **Play**. Move with WASD/arrows, grab spheres for points before time runs out!

## 4. How the code works

- **PlayerMover.cs:** reads WASD every frame, moves the cube with `transform.Translate`
- **PickupSpinner.cs:** spins the pickup, and on touch calls `ScoreManager.Instance.AddPoint()` then hides
- **ScoreManager.cs:** singleton that keeps score and updates the UI text
- **GameTimer.cs:** counts down from 60, updates UI, disables player movement at 0

## 5. Build it for Windows

1. File -> Build Settings
2. Click **Add Open Scenes**
3. Select **PC, Mac & Linux Standalone**, Target Platform = **Windows**, Architecture = **x86_64**
4. Click **Build**, create a folder like `Builds/Windows/`, Unity makes a real `.exe` you can double-click and share!

One honest note: I can't compile the .exe for you here on my own computer - Unity builds have to run inside the Unity Editor on your Windows PC. But all the code above is ready to drop in.

## Ideas to try next

- Make pickups respawn in a new random spot instead of disappearing
- Add a win screen when you collect them all
- Add sound when you collect one (AudioSource + PlayOneShot)
