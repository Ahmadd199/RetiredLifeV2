using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmingHotbarSlotUI : MonoBehaviour
{
    [Header("Wiring (children)")]
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private GameObject selected;

    public void SetItem(Sprite sprite, int count = 1)
    {
        if (sprite == null || count <= 0)
        {
            Clear();
            return;
        }

        icon.sprite = sprite;
        icon.enabled = true;
        countText.text = count > 1 ? count.ToString() : "";
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;
        countText.text = "";
    }

    public void SetSelected(bool on)
    {
        selected.SetActive(on);
    }
}

