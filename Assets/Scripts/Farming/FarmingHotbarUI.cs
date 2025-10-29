using UnityEngine;

public class FarmingHotbarUI : MonoBehaviour
{
    [Header("Slot UI references (drag the UI slot objects here)")]
    public FarmingHotbarSlotUI[] slots;

    [Header("Inventory Source")]
    public Inventory mainInventory; // drag the GameManager Inventory here in Inspector

    public int SelectedIndex { get; private set; } = 0;

    void Start()
    {
        RefreshAllSlots();
        RefreshSelection();
    }

    void Update()
    {
        // Number keys to select slot
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSlot(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SelectSlot(7);
        if (Input.GetKeyDown(KeyCode.Alpha9)) SelectSlot(8);
        if (Input.GetKeyDown(KeyCode.Alpha0)) SelectSlot(9);

        // Scroll wheel
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0.1f) SelectSlot((SelectedIndex - 1 + slots.Length) % slots.Length);
        if (scroll < -0.1f) SelectSlot((SelectedIndex + 1) % slots.Length);
    }

    public void RefreshAllSlots()
    {
        if (mainInventory == null) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i >= mainInventory.slots.Count)
            {
                slots[i].Clear();
                continue;
            }

            var invSlot = mainInventory.slots[i];

            if (invSlot.item == null || invSlot.count <= 0)
                slots[i].Clear();
            else
                slots[i].SetItem(invSlot.item.icon, invSlot.count);
        }
    }

    void SelectSlot(int index)
    {
        SelectedIndex = Mathf.Clamp(index, 0, slots.Length - 1);
        RefreshSelection();
    }

    void RefreshSelection()
    {
        for (int i = 0; i < slots.Length; i++)
            slots[i].SetSelected(i == SelectedIndex);
    }
}
