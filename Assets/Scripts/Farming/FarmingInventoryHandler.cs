using UnityEngine;
using System.Collections.Generic;

public class FarmingInventoryHandler : MonoBehaviour
{
    [System.Serializable]
    public class FarmSlot
    {
        public FarmItem item;
        public int count;
    }

    [Header("Inventory Settings")]
    public int capacity = 10;
    public List<FarmSlot> slots = new();

    [Header("Crop Items")]
    public FarmItem wheatItem;
    public FarmItem carrotItem;

    void Awake()
    {
        for (int i = 0; i < capacity; i++)
        {
            slots.Add(new FarmSlot());
        }
    }

    public void AddCrop(string cropName)
    {
        FarmItem cropToAdd = GetCropItem(cropName);
        if (cropToAdd == null)
        {
            Debug.LogWarning($"No FarmItem found for crop name: {cropName}");
            return;
        }

        foreach (var slot in slots)
        {
            if (slot.item == cropToAdd && slot.count < cropToAdd.maxStack)
            {
                slot.count++;
                Debug.Log($"Stacked {cropToAdd.itemName}. Count now: {slot.count}");
                return;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = cropToAdd;
                slot.count = 1;
                Debug.Log($"Added new {cropToAdd.itemName} to inventory!");
                return;
            }
        }

        Debug.LogWarning("Inventory full! Could not add crop.");
    }

    private FarmItem GetCropItem(string cropName)
    {
        switch (cropName)
        {
            case "Wheat": return wheatItem;
            case "Carrot": return carrotItem;
            default: return null;
        }
    }
}
