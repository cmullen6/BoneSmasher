using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public StatusEffectManager manager;
    public GameObject iconPrefab;

    List<GameObject> icons = new List<GameObject>();

    void Update()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        foreach (var icon in icons)
            Destroy(icon);

        icons.Clear();

        foreach (var effect in manager.activeEffects)
        {
            GameObject newIcon = Instantiate(iconPrefab, transform);

            Image img = newIcon.GetComponent<Image>();
            img.sprite = effect.data.icon;

            TMP_Text text = newIcon.GetComponentInChildren<TMP_Text>();
            text.text = effect.stacks.ToString();

            icons.Add(newIcon);
        }
    }
}