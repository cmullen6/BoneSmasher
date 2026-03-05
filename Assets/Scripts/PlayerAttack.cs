using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public StatusEffectData bleed;

    public StatusEffectManager enemyEffects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyEffects.ApplyEffect(bleed);

            Debug.Log("Bleed attack used.");
        }
    }
}
