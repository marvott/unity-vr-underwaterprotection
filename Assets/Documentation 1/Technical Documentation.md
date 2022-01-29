---
id: technical documentation
title: Technical Documentation for VR Game: Underwater Protection
---

Copy this `markdown.md` file located in [*/reference/templates* folder](https://github.com/Unity-Technologies/com.unity.multiplayer.docs/blob/master/reference/templates/markdown.md) in the repository or cloned local files. In the */versioned_docs* folder, paste it in a version folder and location. This file contains the minimum code needed to write content. For extensive Markdown features, see [Markdown Guide and Code](../template.md).

In this technical Documentation you'll find everything you need to start using and improving our project.

## Requirements

Unity Version: 2020.3.16f1

## Hierachy

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

## Code

### Classes

### State Diagram



Every script starts with a clear description of what it's for.

```markdown title = "Code Example"
Some code here!
```

## Assets

We ordered our list of assets into two categories: Imported ones and those, we created ourselves.

### Imported

#### 3D Models

* Whale
    * Assets/ExternalAssets/Humpback whale/humpback_whale_model_baked_animation.FBX
    * [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/characters/animals/fish/humpback-whale-3547)
* [Coke Can] [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/cola-can-96659)
* [Sardinia] [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/characters/animals/fish/sardine-37963)
* [Hands] [LINK ZUM ASSET](https://github.com/Novaborn-dev/VR-Hands-with-Unity-XR)
* [Rocks] [LINK ZUM ASSET](https://assetstore.unity.com/packages/3d/props/exterior/pbr-rock-cliffs-pack-105772)
* [Standard Assets Pack] [LINK ZUM ASSET](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2018-4-32351)
* [Bottle] [LINK ZUM ASSET](https://blendswap.com/blend/2410)
* [Nestle Bottle] [LINK ZUM ASSET](https://free3d.com/3d-model/plastic-bottle-14620.html)
* [Cat] [LINK ZUM ASSET](https://www.thingiverse.com/thing:923108/files)
* [Plastic bag] [LINK ZUM ASSET](https://www.turbosquid.com/3d-models/3d-model-pbr-glossiness-1703956#)
* [Bushes](https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168)

#### Textures

* [Wood-Textures](https://assetstore.unity.com/packages/2d/textures-materials/wood/hand-painted-seamless-wood-texture-vol-6-162145)

#### Scripts

#### Audio

* [Humpback Whale Song from Monterey Bay](https://www.youtube.com/watch?v=5tRMqbPH_pk)

#### Tools

* [Bezier Path Creator](https://assetstore.unity.com/packages/tools/utilities/b-zier-path-creator-136082)

### Created

* Drag Movement System based on the Continuous Move Provider from [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html)






[Image alt text](/ img / example - img.png)


## Contact

If you have any further questions, feel free to contact us:
* [Marvin Ottersberg](mailto:marvin.ottersberg@student.fh-kiel.de)
* [Micha Wewers](mailto:micha.t.wewers@student.fh-kiel.de)