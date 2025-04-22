# VR Project Design Document

**Date:** 10/04/2025  
**Authors:** Kevin Wu & Rida Chaarani  

---

## 1. App Info

**Tentative Title:**  
**VR Exoskeleton Simulation**

**Category (check all that apply):**

- [ ] Education & Training  
- [ ] Mental Health & Fitness  
- [ ] Travel & Discovery  
- [ ] Media & Entertainment  
- [ ] Productivity & Collaboration  
- [ ] Gaming  
- [ ] Art & Creativity  
- [x] Other: Data collection  

---

## 2. Pitch

**The goal is for users to:**  
Provide a standardized testing platform to evaluate the efficacy of various exoskeleton designs for construction workers through different tests tailored to each exoskeleton type.

**Why VR?**  
The simulation test will be consistent across different test sites, as the simulation will always be the same regardless of the real-life test location.

**High-Level User Experience:**  
Users will be capable of selecting different test cases, such as evaluating arm support or back support exoskeletons. An augmented reality (AR) version of the simulation may also be developed to enhance flexibility and real-world applicability.

**Targeted Device Capabilities:**  
- 6 degrees of freedom: translational and rotational x, y & z
- Control over movement and rotation of head & controllers  

---

## 3. Basics

**App Environment:**  
- Virtual construction site

**User Navigation:**  
- Continuous movement  

---

## 4. Events & Interactions

**Feedback:**  
- Haptic/audio feedback on:
  - Task completion
  - Simulation completion  

- visual feedback on:
  - Task progression
  - Task completion
  - Simulation completion

**3D Sound:**  
- Ambient construction site sounds (talking, birds, drills, etc.) 

**Controller Defaults:**  
- Left hand: Direct interactor  
- Right hand: Direct interactor  
- Ray interactor: Not toggleable with thumb stick  

**Main Menu:**  
- Located in front of the user at start  
- User can select specific test  

**Optional UI Elements:**  
- TBD  

---

## 5. Scenes

### Main Scene

**Purpose:**
To welcome the participant, provide a brief overview of the simulation, and allow them to choose which exoskeleton scenario to test.

**Interactions:**  
- The user is greeted with a welcome message and brief instructions.  
- Two large buttons are presented:
  - **Back Support** – Loads the back support exoskeleton testing scene.
  - **Arm Support** – Loads the arm support exoskeleton testing scene.  
- Menu appears directly in front of the user upon scene start.
- Trigger press while pointing at a button selects that option and loads the corresponding scene.

### Back Support Scene

**Purpose:**  
To evaluate the performance and support of a back support exoskeleton in a simulated rebar-tying task.

**Interactions:**  
- A short tutorial UI is presented at the start to explain the task process.
- The user is placed in a virtual construction zone.
- The task involves tying rebar in a 6m x 6m grid with 25cm spacing between each rebar.
- Visual and/or audio cues guide the user through proper posture and motion.
- Trigger or grab interactions are used to simulate tying actions.
- Progress tracking or task completion feedback will be provided.

### Arm Support Scene

**Purpose:**  
To evaluate the performance and support of an arm support exoskeleton in a drill-based simulation.

**Interactions:**  
- A short tutorial UI is presented at the start to explain the task process.
- The task area setup and objectives are currently TBD.
- The scene will feature hand-based interactions focused on simulating arm fatigue tasks.
- Trigger or grab interactions will be used as appropriate once the task is finalized.

---

## 6. Optimization & Publishing

**Comfort & Accessibility:**  
- Clear visual cues for interactables  
- Intuitive and simple controls  
- Progress indicators  

**Target Platform:**  
- Oculus Meta Quest (wireless)  

**Performance Targets:**  
- **FPS:** ≥ 60  
- **Milliseconds/frame:** < 16.67 ms  
- **Triangles/frame:** 50k – 100k  
- **Draw calls/frame:** 50 – 200  

**Lighting Strategy:**  
- [ ] All baked  
- [x] Mostly baked with some mixed  
- [ ] All real-time  
- Light probes **will** be used for more realistic mixed lighting  

---

## 7. Sketch

- To be made  
