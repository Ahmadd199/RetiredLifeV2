using UnityEngine;

public class PlayerFarming : MonoBehaviour
{
    private Plot nearbyPlot;
    public Inventory inventory;
    void Start()
    {
        if (!inventory) inventory = FindAnyObjectByType<Inventory>();
    }

    void Update()
    {
        if (nearbyPlot == null) return;

        // PLANT (P)
        if (Input.GetKeyDown(KeyCode.P) && nearbyPlot.IsEmpty())
        {
            // Always plant Wheat
            nearbyPlot.PlantCrop(new Crop("Wheat", 2)); 
            Debug.Log("Planted Wheat.");
        }

        // GROW (G)
        if (Input.GetKeyDown(KeyCode.G) && !nearbyPlot.IsEmpty())
        {
            nearbyPlot.GrowCrop();
            Debug.Log("Crop has grown.");
        }

        // HARVEST (H)
        if (Input.GetKeyDown(KeyCode.H) && !nearbyPlot.IsEmpty())
        {
            Crop harvested = nearbyPlot.HarvestCrop();
            if (harvested != null)
            {
                // Add harvested item
                var connector = FindAnyObjectByType<FarmingInventoryConnector>();
                if (connector != null)
                    connector.AddCropToInventory(harvested.cropName);

                Debug.Log("Harvested and added to inventory.");
            }
        }
    }

   private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Triggered with: " + other.name);

    if (other.CompareTag("Plot"))
    {
        nearbyPlot = other.GetComponent<Plot>();
        Debug.Log("Player is near a plot!");
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    Debug.Log("Stopped triggering with: " + other.name);

    if (other.CompareTag("Plot"))
    {
        nearbyPlot = null;
        Debug.Log("Player left the plot.");
    }
}

}

