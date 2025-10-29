using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFarming : MonoBehaviour
{
    private PlotBehaviour nearbyPlot;
    private FarmingInventoryConnector farmingConnector;

    void Start()
    {
        farmingConnector = FindAnyObjectByType<FarmingInventoryConnector>();

        if (farmingConnector == null)
        {
            Debug.LogWarning("FarmingInventoryConnector not found in scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            nearbyPlot = other.GetComponent<PlotBehaviour>();
            Debug.Log("Nearby plot detected");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plot") && other.GetComponent<PlotBehaviour>() == nearbyPlot)
        {
            nearbyPlot = null;
        }
    }

    void Update()
    {
        if (nearbyPlot == null) return;

        // Plant crop with P
        if (Input.GetKeyDown(KeyCode.P) && nearbyPlot.IsEmpty())
        {
            nearbyPlot.PlantCrop(new Crop("Wheat", 2));
        }

        // Grow crop with G
        if (Input.GetKeyDown(KeyCode.G) && !nearbyPlot.IsEmpty())
        {
            nearbyPlot.GrowCrop();
            Debug.Log("Crop grown one stage!");
        }

        //  Harvest with H
        if (Input.GetKeyDown(KeyCode.H) && !nearbyPlot.IsEmpty())
        {
           string cropName = nearbyPlot.GetCropName(); 
           nearbyPlot.HarvestCrop(); 

        if (farmingConnector != null && !string.IsNullOrEmpty(cropName))
          farmingConnector.AddCropToInventory(cropName);
        }

    }
}
