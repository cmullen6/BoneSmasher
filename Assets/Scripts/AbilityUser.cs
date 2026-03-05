using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public Health target;

    private bool hasActed = false;

    public bool CanAct()
    {
        return !hasActed;
    }

    public void UseAbility(AbilityData ability)
    {
        if (hasActed) return;

        if (target != null)
        {
            target.TakeDamage(ability.damage);
        }

        hasActed = true;

        FindFirstObjectByType<TurnManager>().EndPlayerTurn();
    }

    public void ResetTurn()
    {
        hasActed = false;
    }
}
