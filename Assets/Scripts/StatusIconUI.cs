using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusIconUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text stackText;

    public void Setup(Sprite sprite, int stacks)
    {
        icon.sprite = sprite;

        if (stacks > 1)
            stackText.text = stacks.ToString();
        else
            stackText.text = "";
    }
}
