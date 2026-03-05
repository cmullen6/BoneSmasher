using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public TMP_Text text;

    public void Show(string info)
    {
        gameObject.SetActive(true);
        text.text = info;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
