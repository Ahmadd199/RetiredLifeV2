using UnityEngine;

public class PlayerFarming : MonoBehaviour
{
    private Plot nearbyPlot;

    void Update()
    {
        if (nearbyPlot == null) return;

        // Plant (P)
        if (Input.GetKeyDown(KeyCode.P) && nearbyPlot.IsEmpty())
        {
            nearbyPlot.PlantCrop(new Crop("Wheat", 2));
        }

        // Harvest (H)
        if (Input.GetKeyDown(KeyCode.H) && !nearbyPlot.IsEmpty())
        {
            nearbyPlot.HarvestCrop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            nearbyPlot = other.GetComponent<Plot>();
            Debug.Log("Player is near a plot");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plot") && other.GetComponent<Plot>() == nearbyPlot)
        {
            nearbyPlot = null;
        }
    }
}
