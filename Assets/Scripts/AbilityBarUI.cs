using UnityEngine;

public class AbilityBarUI : MonoBehaviour
{
    public AbilityData[] abilities;
    public GameObject buttonPrefab;

    public AbilityUser player;

    void Start()
    {
        foreach (AbilityData ability in abilities)
        {
            GameObject btn = Instantiate(buttonPrefab, transform);

            AbilityButtonUI ui = btn.GetComponent<AbilityButtonUI>();

            ui.Setup(ability, player);
        }
    }
}