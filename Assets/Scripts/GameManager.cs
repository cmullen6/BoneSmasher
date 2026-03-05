using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AbilityUser player;

    int turn = 1;

    public void EndPlayerTurn()
    {
        Debug.Log("Enemy Turn");

        Invoke("StartPlayerTurn", 1f);
    }

    void StartPlayerTurn()
    {
        turn++;

        player.ResetTurn();

        Debug.Log("Turn " + turn);
    }
}