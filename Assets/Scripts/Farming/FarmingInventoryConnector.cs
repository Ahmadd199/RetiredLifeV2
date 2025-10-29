using UnityEngine;

public class FarmingInventoryConnector : MonoBehaviour
{
    [Header("Links to existing systems")]
    public Inventory mainInventory;   
    [Header("Crop Item Objects (ScriptableObjects)")]
    public Item wheatItem;    
    public Item carrotItem;   

    /// <summary>
    /// Adds the harvested crop to the player's inventory based on its cropName.
    /// </summary>
    public void AddCropToInventory(string cropName)
    {
        if (mainInventory == null)
        {
            Debug.LogWarning("No Inventory assigned to FarmingInventoryConnector!");
            return;
        }

        Item itemToAdd = null;

        switch (cropName.ToLower())
        {
            case "wheat":
                itemToAdd = wheatItem;
                break;

            case "carrot":
                itemToAdd = carrotItem;
                break;

            default:
                Debug.LogWarning($"No matching inventory item found for crop '{cropName}'.");
                return;
        }

        bool success = mainInventory.Add(itemToAdd, 1);
        Debug.Log($"Inventory Count After Adding: {mainInventory.slots.FindAll(s => s.item != null).Count}");


        if (success)
{
    Debug.Log($"{cropName} added to inventory!");

    var hotbar = FindObjectOfType<FarmingHotbarUI>();
    if (hotbar != null)
        hotbar.RefreshAllSlots();
}

      //  if (success)
       // {
       //     Debug.Log($"{cropName} added to inventory!");
            
          //  FindAnyObjectByType<FarmingHotbarUI>()?.RefreshAllSlots();
        //}
       // else
           // Debug.LogWarning($"Inventory full — Could not add {itemToAdd.itemName}");
    }
}
