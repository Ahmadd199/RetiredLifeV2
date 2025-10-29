using UnityEngine;

public class Plot : MonoBehaviour
{
    public Crop plantedCrop;

    public bool IsEmpty()
    {
        return plantedCrop == null;
    }

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

    public void GrowCrop()
    {
        if (!IsEmpty())
            plantedCrop.Grow();
    }

    public Crop HarvestCrop()
    {
        if (!IsEmpty() && plantedCrop.Harvest())
        {
            Crop harvested = plantedCrop;
            plantedCrop = null;
            return harvested;
        }

        return null;
    }
}
