using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Ability")]
public class AbilityData : ScriptableObject
{
    public string abilityName;

    [TextArea]
    public string description;

    public Sprite icon;

    public int damage;

    public int cooldownTurns = 0;
}
