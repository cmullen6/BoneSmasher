using UnityEngine;

[CreateAssetMenu(menuName = "Status Effects/New Status Effect")]
public class StatusEffectData : ScriptableObject
{
    public string effectName;

    [Header("Duration")]
    public int duration = 3;
    public int maxStacks = 1;

    [Header("Damage Over Time")]
    public bool dealsDamageEachTurn;
    public int damagePerTick;

    [Header("Armor Modifier")]
    public bool modifiesArmor;
    public int armorModifier;

    [Header("Thorns")]
    public bool reflectsDamage;
    public int reflectPercent;

    [Header("Event Triggers")]
    public bool triggerOnTurnStart;
    public bool triggerOnTurnEnd;
    public bool triggerOnDamageTaken;

    [Header("UI")]
    public Sprite icon;
}
