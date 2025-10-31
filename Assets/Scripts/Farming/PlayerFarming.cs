using UnityEngine;

public class PlayerFarming : MonoBehaviour
{
    private Plot nearbyPlot;
    public FarmingHotbarUI hotbarUI; 
    public Inventory inventory;

    void Start()
    {
        if (!hotbarUI) hotbarUI = FindAnyObjectByType<FarmingHotbarUI>();
        if (!inventory) inventory = FindAnyObjectByType<Inventory>();
    }

    void Update()
    {
        if (!nearbyPlot) return;

        // PLANT (P)
        if (Input.GetKeyDown(KeyCode.P) && nearbyPlot.IsEmpty())
        {
            var slot = inventory.slots[hotbarUI.SelectedIndex];

            if (slot.item != null && slot.item is FarmItem && slot.item.itemName.Contains("Seed"))
            {
                // remove 1 seed
                slot.count -= 1;
                if (slot.count <= 0) inventory.ClearSlot(hotbarUI.SelectedIndex);

                // convert "Wheat Seed" → "Wheat"
                string cropName = slot.item.itemName.Replace(" Seed", "");
                nearbyPlot.PlantCrop(new Crop(cropName, 2));

                hotbarUI.RefreshAllSlots();  
            }
        }

        // GROW (G)
        if (Input.GetKeyDown(KeyCode.G) && !nearbyPlot.IsEmpty())
            nearbyPlot.GrowCrop();

        // HARVEST (H)
        if (Input.GetKeyDown(KeyCode.H) && !nearbyPlot.IsEmpty())
        {
            Crop harvested = nearbyPlot.HarvestCrop();
            if (harvested != null)
            {
                var connector = FindAnyObjectByType<FarmingInventoryConnector>();
                if (connector != null)
                    connector.AddCropToInventory(harvested.cropName);

                hotbarUI.RefreshAllSlots();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
            nearbyPlot = other.GetComponent<Plot>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
            nearbyPlot = null;
    }
}
