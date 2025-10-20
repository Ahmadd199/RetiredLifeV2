using UnityEngine;

public class Plot
{
    public Crop plantedCrop;

    // Check if a crop is planted
    public bool IsEmpty()
    {
        return plantedCrop == null;
    }

    // Plant a crop
    public void PlantCrop(Crop crop)
    {
        if (IsEmpty())
        {
            plantedCrop = crop;
            Debug.Log($"{crop.cropName} planted!");
        }
        else
        {
            Debug.Log("This plot already has a crop.");
        }
    }

    // Grow the crop (advance time)
    public void GrowCrop()
    {
        if (!IsEmpty())
        {
            plantedCrop.Grow();
        }
    }

    // Harvest the crop
    public void HarvestCrop()
    {
        if (!IsEmpty() && plantedCrop.Harvest())
        {
            plantedCrop = null; // clear the plot
        }
    }
}