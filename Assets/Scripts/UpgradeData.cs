using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/New Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;

    public int bleedDamageBonus;
    public int maxHealthBonus;
    public int thornsBonus;
}
