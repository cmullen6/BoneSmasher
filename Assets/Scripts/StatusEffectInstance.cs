using UnityEngine;
public class StatusEffectInstance
{
    public StatusEffectData data;

    public int remainingDuration;
    public int stacks;

    public StatusEffectInstance(StatusEffectData effect)
    {
        data = effect;
        remainingDuration = effect.duration;
        stacks = 1;
    }
}