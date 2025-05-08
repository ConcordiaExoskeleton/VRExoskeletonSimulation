# VRExoskeletonSimulation

## Overview

This project is a VR testing simulation designed for wireless virtual reality headsets (Tested on Meta Quest 3) paired with usage of an exoskeleton to evaluate and test the efficacy of different exoskeleton designs in a construction environments as a standarized test. It's goal is to simulates tasks like lifting, carrying, placing, and tying rebar in a realistic outdoor construction site environment.

## Features

#### Core features:

- Back support exoskeleton testing mode
    - rebar tying simulation of a 6m x 6m with 25cm spacing work zone
- Arm support exoskeleton testing mode
- Tutorial UI for each scene
- Realistic construction site environment
- Physics-based object interaction
- Progress/Completion feedback

#### Other features:

- Audio and haptic feedback
- Menu scene with scene selection
- Modular design for future task additions
- Support for direct interactor input

## Visuals

X

## Controls

| Action          | Control              |  
|-----------------|----------------------|  
| Grab            | Grip button          |  
| Tie             | Trigger button       |


## Hardware Requirements

- VR headset (Tested on Meta Quest 3)
- Compatible PC with Meta Quest Link
- Installed Meta Quest app (for developer mode)
- USB-C cable for connecting Quest to PC (if using wired link)
- Exoskeleton

## How to Run

1. **Enable Developer Mode** on your Meta Quest 3:
   - Open the **Meta Quest app** on your mobile device.
   - Go to **Settings > Developer Mode** and enable it.

2. **Connect to PC**:
   - Use **Meta Quest Link** via USB-C or Air Link to connect the headset to your Unity development environment.

3. **Unity Setup**:
   - Install Unity with the **Android Build Support** module.
   - Open the project in Unity Hub.
   - Go to **Edit > Project Settings**
   - Under **XR Plug-in Management**, enable **OpenXR** for Android.
   - Go to **File > Build Settings**.
   - Select **Android** as the platform and click **Switch Platform**.
   

4. **Build and Run**:
   - Connect your headset via USB.
   - Select your headset in the **Build Settings > Run Device** dropdown.
   - Click **Build and Run** to deploy directly to the headset.

## Tech Stack:
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) 
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white) ![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white) ![Meta](https://img.shields.io/badge/Meta-%230467DF.svg?style=for-the-badge&logo=Meta&logoColor=white)

**Platform:** Meta Quest 3 (Android) \
**XR SDK:** Oculus XR Plugin

## Authors and acknowledgment

Developed by: Interns Kevin Wu and Rida Chaarani

Special thanks: PhD Professor Dr. Amin Hammad and Concordia university for lending and providing access to exoskeletons, virtual reality headset and other materials needed for this project.

## Project status

🚧 **Early Development**  
We are currently building the core scenes and establishing interaction systems. More features and polish coming soon!

## License

All rights reserved by the creators of the VRExoskeletonSimulation