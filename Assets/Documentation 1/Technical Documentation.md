---
id: technical documentation
title: Technical Documentation for VR Game: Underwater Protection
---
<h1>Technical Documentation: Underwater Protection</h1>

<h3>In this technical Documentation you'll find everything you need to start using and improving our project.</h3>

#

## Requirements
Unity Version: 2020.3.16f1
#
## Hierachy
Our Hierarchy is structured as follows:
<img src="./Doc_Pictures/Hierarchy.png" width="400" height="400" />

The empty Gameobjects with the underscores are supposed to be Dividers. It gives a nice Overview and you know where to find everything. 
You'll find all Objects that can be interacted with under ___OBJECTS___, all other Objects that build the World like Frames, Bushes, Rocks, Terrain and Background Audios are under ___WORLD___.
You'll find empty Gameobjects with Scripts attached to it under ___SCRIPTS___ and ___ANIMATIONS___.
We used a [Path Creator Tool](#bezier)

#
## Folders
The Unity-Project is organised into these folders:
* `Animations` -> Our Own Animations
* `Audio` -> All Audio Files
* `Documentation` 
* [`External Assets`](#assets)
* `Materials` 
* `Models` 
    * `Prefab`
* `Scenes`
* `Scripts`
    * `Audio` -> All Scripts working with some kind of Audio
    * `Interaction` -> Interactions: p.e. checking if Player looks a particular way or destroying an object, haptic feedback
    * `Movement` -> moving along the rope
    * `Objects` -> spawning new Objects like Rocks, Garbage and Plants
    * `Other` -> Scene Manager for global Variables
    * `World` -> animal-related Scripts
* `XR` -> XR Interaction Toolkit
#
## Code

### Classes

### State Diagram

#### Scripts

Every script starts with a clear description of what it's for.

```markdown title = "Code Example"
Some code here!
```
#
## Assets

We ordered our list of assets into two categories: Imported ones and those, we created ourselves.

### Imported

Note: The paths listed below belong to the assets acutally used in the game. Assets that are in the project because they
are part of a specific package but are not used in the game are not included.

#### 3D Models

* Whale
    * Assets/ExternalAssets/Humpback whale/humpback_whale_model_baked_animation.FBX
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/characters/animals/fish/humpback-whale-3547)
* Coke Can
    * Assets/ExternalAssets/External Garbages/Cola Can/Cola Can.prefab
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/cola-can-96659)
* Sardinia
    * Assets/ExternalAssets/Sardine/Prefabs/SardineSkinWithDemoScript.prefab 
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/characters/animals/fish/sardine-37963)
* Hands
    * Assets/Models/Prefab/Hand 1.prefab
    * [LINK ZUM ASSET](https://github.com/Novaborn-dev/VR-Hands-with-Unity-XR)
* Rocks
    * Choice of 
        * Assets/ExternalAssets/PBR_Rock_Cliffs_Pack/Prefabs/Static_Stone_Prefabs
        * Assets/ExternalAssets/PBR_Rock_Cliffs_Pack/Prefabs/Standart_Stone_Prefabs  
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/props/exterior/pbr-rock-cliffs-pack-105772)
* Bottle: 
    * Assets/ExternalAssets/External Garbages/Bottle.prefab
    * [LINK ZUM ASSET](https://blendswap.com/blend/2410)
* Plastic bag:
    * Assets/ExternalAssets/External Garbages/Package/hanging_package.fbx
    * [LINK ZUM ASSET](https://www.turbosquid.com/3d-models/3d-model-pbr-glossiness-1703956#)
* Bushes:
    * Assets/ExternalAssets/YughuesFreeBushes2018/Prefabs/P_Bush01.prefab
    * Assets/ExternalAssets/YughuesFreeBushes2018/Prefabs/P_Bush02.prefab
    * Assets/ExternalAssets/YughuesFreeBushes2018/Prefabs/P_Bush03.prefab
    * Assets/ExternalAssets/YughuesFreeBushes2018/Prefabs/P_Bush04.prefab
    * Assets/ExternalAssets/YughuesFreeBushes2018/Prefabs/P_Bush05.prefab
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168)

#### Textures

* [Wood-Textures](https://assetstore.unity.com/packages/2d/textures-materials/wood/hand-painted-seamless-wood-texture-vol-6-162145)



#### Audio
* We created a new Underwater Effect in Audition from these two Audiofiles
    * [Underwater Ambience](https://freesound.org/people/YoloSwaggings/sounds/406623/)
    * [Underwater Bubbles](https://freesound.org/people/Robinhood76/sounds/96742/)
* [Humpback Whale Song from Monterey Bay](https://www.youtube.com/watch?v=5tRMqbPH_pk)

#### Tools
* Bezier Path Creator for creating Curves our Whale and Fish can follow
    * Assets/ExternalAssets/PathCreator
    * <a href="https://assetstore.unity.com/packages/tools/utilities/b-zier-path-creator-136082" id="# bezier">LINK ZUM ASSET</a>
    'TODO: SCHEISS VERLINKUNG GEHT NICHT'
#
### Created

* Drag Movement System: 
    * Assets/Scripts/Movement_Scripts/dragMovementSystem.cs
    * Inspired by the Continuous Move Provider from [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html)
#

## Contact

If you have any further questions, feel free to contact us:
* [Marvin Ottersberg](mailto:marvin.ottersberg@student.fh-kiel.de)
* [Micha Wewers](mailto:micha.t.wewers@student.fh-kiel.de)