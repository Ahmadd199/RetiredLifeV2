using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item", fileName = "NewItem")]
public class Item : ScriptableObject
{
    [Header("Basics")]
    public string itemName;
    public Sprite icon;

    [Header("Stacking")]
    [Min(1)] public int maxStack = 99;

    [TextArea]
    public string description;
}
