using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class HotbarSlotRefs
{
    public Image icon;
    public TMP_Text count;
    public Image selectedFrame;
}

public class HotbarUI : MonoBehaviour
{
    [Header("Slots are populated in the Inspector")]
    public HotbarSlotRefs[] slots = new HotbarSlotRefs[10];

    [Header("Mock Data (replace with your inventory later)")]
    public Sprite[] demoIcons; // assign some item icons to test
    public int[] demoCounts = new int[10];

    public int SelectedIndex { get; private set; } = 0;

    void Start()
    {
        // build demo content if provided
        for (int i = 0; i < slots.Length; i++)
        {
            SetSlot(i, (i < demoIcons.Length) ? demoIcons[i] : null, demoCounts[i]);
        }
        UpdateSelection(SelectedIndex);
    }

    void Update()
    {
        // number keys 1..0 (0 = index 9)
        if (Input.GetKeyDown(KeyCode.Alpha1)) UpdateSelection(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UpdateSelection(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UpdateSelection(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) UpdateSelection(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) UpdateSelection(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) UpdateSelection(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) UpdateSelection(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) UpdateSelection(7);
        if (Input.GetKeyDown(KeyCode.Alpha9)) UpdateSelection(8);
        if (Input.GetKeyDown(KeyCode.Alpha0)) UpdateSelection(9);
        // scroll wheel support
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0.1f) UpdateSelection((SelectedIndex + slots.Length - 1) % slots.Length);
        if (scroll < -0.1f) UpdateSelection((SelectedIndex + 1) % slots.Length);
    }

    public void SetSlot(int index, Sprite icon, int count)
    {
        if (index < 0 || index >= slots.Length) return;
        var s = slots[index];
        if (s.icon)
        {
            s.icon.sprite = icon;
            s.icon.enabled = icon != null;
        }
        if (s.count)
            s.count.text = (count > 1) ? count.ToString() : "";
    }

    void UpdateSelection(int newIndex)
    {
        SelectedIndex = Mathf.Clamp(newIndex, 0, slots.Length - 1);
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].selectedFrame) slots[i].selectedFrame.enabled = (i == SelectedIndex);
        }
        // TODO: notify gameplay about selected item/tool here
    }
}
