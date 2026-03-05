using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health targetHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = targetHealth.maxHealth;
    }

    void Update()
    {
        slider.value = targetHealth.currentHealth;
    }
}
