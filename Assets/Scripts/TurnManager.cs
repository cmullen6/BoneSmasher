using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public AbilityUser player;

    private AbilityButtonUI[] abilityButtons;

    void Start()
    {
        abilityButtons = FindObjectsByType<AbilityButtonUI>(FindObjectsSortMode.None);
    }

    public void EndPlayerTurn()
    {
        Debug.Log("Enemy Turn");

        Invoke(nameof(StartPlayerTurn), 1f);
    }

    void StartPlayerTurn()
    {
        player.ResetTurn();

        foreach (AbilityButtonUI btn in abilityButtons)
        {
            btn.ReduceCooldown();
        }

        Debug.Log("Player Turn");
    }
}