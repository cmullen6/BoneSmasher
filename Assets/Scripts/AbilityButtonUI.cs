using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AbilityButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AbilityData ability;
    public AbilityUser player;

    public Image icon;
    public TMP_Text cooldownText;
    public Button button;

    public TooltipUI tooltip;

    int cooldownRemaining = 0;

    void Start()
    {
        icon.sprite = ability.icon;
        button.onClick.AddListener(UseAbility);
        UpdateUI();
    }

    void UseAbility()
    {
        if (!player.CanAct())
            return;

        if (cooldownRemaining > 0)
            return;

        player.UseAbility(ability);

        cooldownRemaining = ability.cooldownTurns;

        UpdateUI();
    }

    public void ReduceCooldown()
    {
        if (cooldownRemaining > 0)
        {
            cooldownRemaining--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        cooldownText.text = cooldownRemaining > 0 ? cooldownRemaining.ToString() : "";
        button.interactable = cooldownRemaining == 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Show(
            ability.abilityName +
            "\nDamage: " + ability.damage +
            "\nCooldown: " + ability.cooldownTurns
        );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hide();
    }
}