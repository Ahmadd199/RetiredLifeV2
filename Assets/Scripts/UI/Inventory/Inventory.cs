using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot { public Item item; public int count; }

public class Inventory : MonoBehaviour
{
    [Range(1, 120)] public int capacity = 20;
    public List<InventorySlot> slots = new();

    void Awake()
    {
        if (slots.Count == 0)
            for (int i = 0; i < capacity; i++) slots.Add(new InventorySlot());
    }

    public bool Add(Item item, int amount = 1)
    {
        // stack first
        foreach (var s in slots)
            if (s.item == item && s.count < item.maxStack)
            {
                int add = Mathf.Min(amount, item.maxStack - s.count);
                s.count += add; amount -= add;
                if (amount <= 0) return true;
            }
        // empty slots
        foreach (var s in slots)
            if (s.item == null)
            {
                s.item = item; s.count = Mathf.Min(amount, item.maxStack);
                amount -= s.count;
                if (amount <= 0) return true;
            }
        return amount <= 0;
    }

    public void ClearSlot(int index) { slots[index].item = null; slots[index].count = 0; }

    public void SetSlot(int index, Item item, int count)
    {
        slots[index].item = item; slots[index].count = count;
        if (slots[index].count <= 0) ClearSlot(index);
    }

    public void Swap(int a, int b)
    {
        (slots[a].item, slots[b].item) = (slots[b].item, slots[a].item);
        (slots[a].count, slots[b].count) = (slots[b].count, slots[a].count);
    }
}
