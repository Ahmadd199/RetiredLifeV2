using UnityEngine;

public class Plot : MonoBehaviour
{
    public Crop plantedCrop;

    public SpriteRenderer cropRenderer;

    [Header("Crop Sprites")]
    public Sprite seedSprite;
    public Sprite growingSprite;
    public Sprite readySprite;

    private void Awake()
    {
        if (cropRenderer == null)
        {
            Transform child = transform.Find("CropSprite");
            if (child != null)
            {
                cropRenderer = child.GetComponent<SpriteRenderer>();
            }
        }

        if (cropRenderer == null)
        {
            Debug.LogError("Plot: No CropSprite found! Make sure Plot has a child named 'CropSprite' with a SpriteRenderer.");
        }
        else
        {
            cropRenderer.sprite = null; 
        }
    }

    public bool IsEmpty()
    {
        return plantedCrop == null;
    }

    public void PlantCrop(Crop newCrop)
    {
        if (!IsEmpty())
        {
            Debug.Log("This plot already has a crop.");
            return;
        }

        plantedCrop = newCrop;
        UpdateVisual();
        Debug.Log($"Planted {newCrop.cropName}");
    }

    public void GrowCrop()
    {
        if (IsEmpty()) return;

        plantedCrop.Grow();
        UpdateVisual();
        Debug.Log($"{plantedCrop.cropName} growth stage: {plantedCrop.state}");
    }

    public Crop HarvestCrop()
    {
        if (IsEmpty()) return null;

        if (plantedCrop.Harvest())
        {
            Crop harvested = plantedCrop;
            plantedCrop = null;
            UpdateVisual();
            Debug.Log($"Harvested!");
            return harvested;
        }

        Debug.Log("Crop is not ready yet!");
        return null;
    }

    private void UpdateVisual()
    {
        if (cropRenderer == null) return;

        if (IsEmpty())
        {
            cropRenderer.sprite = null;
            return;
        }

        switch (plantedCrop.state)
        {
            case CropState.Seed:
                cropRenderer.sprite = seedSprite;
                break;
            case CropState.Growing:
                cropRenderer.sprite = growingSprite;
                break;
            case CropState.ReadyToHarvest:
                cropRenderer.sprite = readySprite;
                break;
        }
    }
}
