using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public List<StatusEffectInstance> activeEffects = new List<StatusEffectInstance>();

    Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    // Apply a new status effect
    public void ApplyEffect(StatusEffectData effect)
    {
        StatusEffectInstance existing =
            activeEffects.Find(e => e.data == effect);

        if (existing != null)
        {
            if (existing.stacks < effect.maxStacks)
                existing.stacks++;

            existing.remainingDuration = effect.duration;
        }
        else
        {
            activeEffects.Add(new StatusEffectInstance(effect));
        }

        Debug.Log(effect.effectName + " applied to " + gameObject.name);
    }

    // TURN START EVENT
    public void OnTurnStart()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            StatusEffectInstance effect = activeEffects[i];

            if (effect.data.triggerOnTurnStart)
                ProcessEffect(effect);

            ReduceDuration(effect, i);
        }
    }

    // TURN END EVENT
    public void OnTurnEnd()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            StatusEffectInstance effect = activeEffects[i];

            if (effect.data.triggerOnTurnEnd)
                ProcessEffect(effect);
        }
    }

    // DAMAGE TAKEN EVENT
    public void OnDamageTaken(int damage)
    {
        foreach (StatusEffectInstance effect in activeEffects)
        {
            if (effect.data.triggerOnDamageTaken)
            {
                ProcessEffect(effect);
            }
        }
    }

    // EFFECT LOGIC
    void ProcessEffect(StatusEffectInstance effect)
    {
        if (effect.data.dealsDamageEachTurn)
        {
            int damage = effect.data.damagePerTick * effect.stacks;

            health.TakeDamage(damage);

            Debug.Log(effect.data.effectName +
                " dealt " + damage + " damage.");
        }
    }

    // REDUCE DURATION
    void ReduceDuration(StatusEffectInstance effect, int index)
    {
        effect.remainingDuration--;

        if (effect.remainingDuration <= 0)
        {
            Debug.Log(effect.data.effectName + " expired.");
            activeEffects.RemoveAt(index);
        }
    }
}