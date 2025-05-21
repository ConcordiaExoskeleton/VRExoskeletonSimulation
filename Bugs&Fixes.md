# VR Fixes

This file will contain all the bugs we found and their fixes (if found) while working on this project. Feel free to add to this file.

## Camera position Offset
When I "Build and Run" the game on the Meta Quest 3, the game works, however the starting position is far from what we want want.

**FIX**:
1. Click the "XR Rig" in the hierarchy
2. In the inspector > XR Origin Component > Change "Tracking origin mode" to "Floor" or "Device" depending on what works best for you

## Scree Moving with Camera
When running the game on VR, when you move your head it would move the whole screen with you. It will also show the editor UI on the bottom left of the screen. You would also start half way in the ground.

**FIX**:
1. In the hierarchy, search for “XR Device Simulator”
2. Delete it or Disable it

## Drill Attach
For the arm support test case the drill will switch from grab to attach because with hand dectection grabbing was not accurate and would sometime let go. However the attach currently works with controllers only, and not for hands.