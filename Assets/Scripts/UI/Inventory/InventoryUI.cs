using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform gridRoot;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject panelRoot;   // InventoryPanel
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private GameObject tooltipRoot;
    [SerializeField] private TMP_Text tooltipText;

    private InventorySlotUI[] slotUIs;

    // Cursor "carried" item
    private Item carryItem;
    private int carryCount;

    void Start()
    {
        if (!inventory) inventory = FindAnyObjectByType<Inventory>();
        BuildGrid();
        RedrawAll();
        HideTooltip();
        panelRoot.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) Toggle();
    }

    public void Toggle() => panelRoot.SetActive(!panelRoot.activeSelf);

    void BuildGrid()
    {
        foreach (Transform c in gridRoot) Destroy(c.gameObject);
        slotUIs = new InventorySlotUI[inventory.capacity];
        for (int i = 0; i < inventory.capacity; i++)
        {
            var go = Instantiate(slotPrefab, gridRoot);
            var ui = go.GetComponent<InventorySlotUI>();
            ui.index = i;
            ui.OnClick = OnSlotClick;
            ui.OnHover = OnSlotHover;
            slotUIs[i] = ui;
        }
        if (titleText) titleText.text = $"Inventory ({inventory.capacity})";
    }

    void RedrawAll()
    {
        for (int i = 0; i < inventory.capacity; i++) Redraw(i);
    }

    void Redraw(int i)
    {
        var s = inventory.slots[i];
        slotUIs[i].Set(s.item ? s.item.icon : null, s.count);
    }

    void OnSlotHover(int index, bool enter)
    {
        var s = inventory.slots[index];
        if (enter && s.item != null)
        {
            tooltipRoot.SetActive(true);
            tooltipText.text = $"{s.item.itemName}\nx{s.count}";
            // follow mouse (simple)
            var p = Input.mousePosition;
            tooltipRoot.transform.position = p + new Vector3(12f, -12f, 0f);
        }
        else HideTooltip();
    }

    void HideTooltip()
    {
        if (tooltipRoot) tooltipRoot.SetActive(false);
    }

    void OnSlotClick(int index, UnityEngine.EventSystems.PointerEventData.InputButton button)
    {
        var slot = inventory.slots[index];

        if (button == UnityEngine.EventSystems.PointerEventData.InputButton.Left)
        {
            if (carryItem == null)
            {
                // pick up whole stack
                carryItem = slot.item; carryCount = slot.count;
                inventory.ClearSlot(index);
            }
            else
            {
                // place / stack / swap
                if (slot.item == null)
                {
                    inventory.SetSlot(index, carryItem, carryCount);
                    carryItem = null; carryCount = 0;
                }
                else if (slot.item == carryItem && slot.count < slot.item.maxStack)
                {
                    int can = slot.item.maxStack - slot.count;
                    int put = Mathf.Min(can, carryCount);
                    inventory.SetSlot(index, slot.item, slot.count + put);
                    carryCount -= put;
                    if (carryCount <= 0) carryItem = null;
                }
                else
                {
                    // swap
                    var tmpItem = slot.item; var tmpCount = slot.count;
                    inventory.SetSlot(index, carryItem, carryCount);
                    carryItem = tmpItem; carryCount = tmpCount;
                }
            }
        }
        else if (button == UnityEngine.EventSystems.PointerEventData.InputButton.Right)
        {
            // split or place one
            if (carryItem == null)
            {
                if (slot.item != null && slot.count > 1)
                {
                    int take = slot.count / 2;
                    slot.count -= take;
                    carryItem = slot.item; carryCount = take;
                }
                else if (slot.item != null && slot.count == 1)
                {
                    carryItem = slot.item; carryCount = 1;
                    inventory.ClearSlot(index);
                }
            }
            else
            {
                if (slot.item == null)
                {
                    inventory.SetSlot(index, carryItem, 1);
                    carryCount -= 1; if (carryCount == 0) carryItem = null;
                }
                else if (slot.item == carryItem && slot.count < slot.item.maxStack)
                {
                    inventory.SetSlot(index, slot.item, slot.count + 1);
                    carryCount -= 1; if (carryCount == 0) carryItem = null;
                }
            }
        }

        RedrawAll();
        UpdateCursorVisual();
    }

    // Optional: show carried item near cursor (simple text fallback)
    [Header("Cursor Visual (optional)")]
    [SerializeField] private Image cursorIcon;
    [SerializeField] private TMP_Text cursorCount;

    void LateUpdate()
    {
        if (cursorIcon && cursorIcon.enabled)
            cursorIcon.transform.position = Input.mousePosition;
    }

    void UpdateCursorVisual()
    {
        if (!cursorIcon || !cursorCount) return;
        if (carryItem == null) { cursorIcon.enabled = false; cursorCount.text = ""; return; }
        cursorIcon.enabled = true;
        cursorIcon.sprite = carryItem.icon;
        cursorCount.text = carryCount > 1 ? carryCount.ToString() : "";
        cursorIcon.transform.SetAsLastSibling();
    }
}