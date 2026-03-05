using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/New Ability")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public string description;

    [Header("Combat")]
    public int damage;
    public StatusEffectData statusEffect;
    public int statusStacks;

    [Header("UI")]
    public Sprite icon;

    [Header("Cooldown")]
    public int cooldownTurns = 0;
}
