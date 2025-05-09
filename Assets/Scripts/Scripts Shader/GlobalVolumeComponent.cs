using System;
using UnityEngine.Rendering;

/*

!!! Fait en utilisant un tutoriel de Unity !!!

*/

// Crée un post-processing volume component

[Serializable]
[VolumeComponentMenu("Custom/GlobalVolumeComponent")]
public class GlobalVolumeComponent : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter intensity = new ClampedFloatParameter(value: 0, min: 0, max: 1, overrideState: true);
    public bool IsActive() => intensity.value > 0;
}
