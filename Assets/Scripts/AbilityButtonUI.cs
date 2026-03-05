using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AbilityButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public TMP_Text cooldownText;
    public Button button;

    private AbilityData ability;
    private AbilityUser user;

    private TooltipUI tooltip;

    private int currentCooldown = 0;

    public void Setup(AbilityData data, AbilityUser abilityUser)
    {
        ability = data;
        user = abilityUser;

        icon.sprite = ability.icon;

        tooltip = Object.FindFirstObjectByType<TooltipUI>();

        button.onClick.AddListener(OnClick);

        UpdateCooldownUI();
    }

    void OnClick()
    {
        if (user == null || ability == null) return;

        if (!user.CanAct())
        {
            Debug.Log("Already acted this turn.");
            return;
        }

        if (currentCooldown > 0)
        {
            Debug.Log("Ability on cooldown.");
            return;
        }

        user.UseAbility(ability);

        currentCooldown = ability.cooldownTurns;

        UpdateCooldownUI();
    }

    public void ReduceCooldown()
    {
        if (currentCooldown <= 0) return;

        currentCooldown--;

        UpdateCooldownUI();
    }

    void UpdateCooldownUI()
    {
        if (currentCooldown > 0)
        {
            cooldownText.text = currentCooldown.ToString();
            button.interactable = false;
        }
        else
        {
            cooldownText.text = "";
            button.interactable = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltip == null) return;

        string info =
            ability.abilityName +
            "\nDamage: " + ability.damage +
            "\nCooldown: " + ability.cooldownTurns;

        tooltip.Show(info);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltip == null) return;

        tooltip.Hide();
    }
}
