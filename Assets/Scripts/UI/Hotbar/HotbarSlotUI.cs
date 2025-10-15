using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarSlotUI : MonoBehaviour
{
    [Header("Wiring (children)")]
    [SerializeField] private Image icon;           // child: "Icon" (Image, Type=Simple, Preserve Aspect)
    [SerializeField] private TMP_Text countText;   // child: "Count" (TMP)
    [SerializeField] private GameObject selected;  // child: "Selected" (GameObject, default inactive)

    [Header("Behavior")]
    [SerializeField] private bool hideIconWhenEmpty = true;

    /// <summary>True if an item sprite is currently shown.</summary>
    public bool HasItem => icon != null && icon.enabled && icon.sprite != null;

    // --- Public API (no selection/input logic here) ---

    /// <summary>Show item icon and count. Pass sprite = null or count <= 0 to clear.</summary>
    public void SetItem(Sprite sprite, int count = 1)
    {
        if (!icon) return;

        if (sprite == null || count <= 0)
        {
            Clear();
            return;
        }

        icon.sprite = sprite;
        icon.enabled = true;

        if (countText)
            countText.text = count > 1 ? count.ToString() : "";
    }

    /// <summary>Clear icon & count.</summary>
    public void Clear()
    {
        if (icon)
        {
            icon.sprite = null;
            icon.enabled = !hideIconWhenEmpty ? true : false;
        }
        if (countText) countText.text = "";
    }

    /// <summary>Show/hide the selected highlight overlay.</summary>
    public void SetSelected(bool on)
    {
        if (selected) selected.SetActive(on);
    }

    /// <summary>Update just the count (e.g., stack changes) without changing the icon.</summary>
    public void SetCount(int count)
    {
        if (!countText) return;
        countText.text = (count > 1) ? count.ToString() : "";
        if (icon && hideIconWhenEmpty) icon.enabled = (count > 0) && icon.sprite != null;
    }

    // --- Convenience: auto-wire by child names when you add the component ---

    void Reset()
    {
        // Called when the component is added or Reset is pressed in Inspector
        if (!icon) icon = transform.Find("Icon")?.GetComponent<Image>();
        if (!countText) countText = transform.Find("Count")?.GetComponent<TMP_Text>();
        if (!selected) selected = transform.Find("Selected")?.gameObject;

        // Sensible defaults
        if (selected) selected.SetActive(false);
        if (icon) icon.enabled = false; // empty by default
        if (countText) countText.text = "";
    }
}
