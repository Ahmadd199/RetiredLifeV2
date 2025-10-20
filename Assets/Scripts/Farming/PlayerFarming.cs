using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFarming : MonoBehaviour
{
    private PlotBehaviour nearbyPlot;

    // Called by PlayerInput's Interact action
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (nearbyPlot != null)
        {
            if (nearbyPlot.IsEmpty())
            {
                nearbyPlot.PlantCrop(new Crop("Wheat", 2));
            }
            else
            {
                nearbyPlot.HarvestCrop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            nearbyPlot = other.GetComponent<PlotBehaviour>();
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

    // Plant with P
    if (Input.GetKeyDown(KeyCode.P) && nearbyPlot.IsEmpty())
    {
        nearbyPlot.PlantCrop(new Crop("Wheat", 2));
    }

    // Harvest with H
    if (Input.GetKeyDown(KeyCode.H) && !nearbyPlot.IsEmpty())
    {
        nearbyPlot.HarvestCrop();
    }

    if (nearbyPlot != null)
    Debug.Log("Nearby plot detected");

}

}
