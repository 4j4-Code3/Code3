using System;
using UnityEngine.Rendering;

[Serializable]
[VolumeComponentMenu("Custom/GlobalVolumeComponent")]
public class GlobalVolumeComponent : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter intensity = new ClampedFloatParameter(value: 0, min: 0, max: 1, overrideState: true);
    public bool IsActive() => intensity.value > 0;
}
