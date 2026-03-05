using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Health playerHealth;

    public void TakeTurn()
    {
        playerHealth.TakeDamage(4);

        Debug.Log("Skeleton attacks!");
    }
}
