using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public AbilityUser player;

    AbilityButtonUI[] buttons;

    int turnNumber = 1;

    void Start()
    {
        buttons = FindObjectsByType<AbilityButtonUI>(FindObjectsSortMode.None);
        StartPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        Debug.Log("Enemy Turn");

        // Enemy would act here
        Invoke(nameof(StartPlayerTurn), 1f);
    }

    void StartPlayerTurn()
    {
        turnNumber++;

        player.ResetTurn();

        foreach (AbilityButtonUI b in buttons)
        {
            b.ReduceCooldown();
        }

        Debug.Log("Turn " + turnNumber);
    }
}