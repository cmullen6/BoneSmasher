using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Health playerHealth;
    public StatusEffectManager playerEffects;

    public void ApplyUpgrade(UpgradeData upgrade)
    {
        if (upgrade.maxHealthBonus > 0)
        {
            playerHealth.maxHealth += upgrade.maxHealthBonus;
            playerHealth.currentHealth += upgrade.maxHealthBonus;
        }

        if (upgrade.thornsBonus > 0)
        {
            Debug.Log("Thorns increased by " + upgrade.thornsBonus);
        }

        if (upgrade.bleedDamageBonus > 0)
        {
            Debug.Log("Bleed damage increased by " + upgrade.bleedDamageBonus);
        }
    }
}
