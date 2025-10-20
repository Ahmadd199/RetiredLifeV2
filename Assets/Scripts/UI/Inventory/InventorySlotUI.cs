using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index;
    public Image icon;
    public TMP_Text countText;
    public Image highlight;

    public System.Action<int, PointerEventData.InputButton> OnClick;
    public System.Action<int, bool> OnHover; // (index, enter)

    public void Set(Sprite sprite, int count)
    {
        icon.sprite = sprite;
        icon.enabled = sprite != null;
        countText.text = count > 1 ? count.ToString() : "";
    }

    public void OnPointerEnter(PointerEventData e) { highlight.enabled = true; OnHover?.Invoke(index, true); }
    public void OnPointerExit(PointerEventData e) { highlight.enabled = false; OnHover?.Invoke(index, false); }

    public void OnPointerClick(PointerEventData e)
    {
        OnClick?.Invoke(index, e.button); // left/right
    }
}
