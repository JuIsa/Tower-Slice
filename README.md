# Tower-Slice

Copy of popular mobile game.

## Prefabs


2 different prefabs for X and Z axis with individual scripts attached.
1 Base prefab to use as a starting ground for new prefabs.

## Mechanics 

Mechanics in my version works as folloing:
1. After 1 second you started game X prefab will be spawned
2. When you hit S on keyboard (for now did not add option to play on mobile), new center and size for this prefab will be calculated
3. Addjust new transform and spawn Z prefab
4. Repeat from 1 but without 1 second delay

Scripts to calculate are in ```MovingX.cs```, ```MovingZ.cs``` in __Scripts__ folder
