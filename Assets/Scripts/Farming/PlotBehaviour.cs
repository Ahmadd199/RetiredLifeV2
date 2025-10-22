using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    private Plot plot;
    private SpriteRenderer sr;

    [Header("Colors")]
    public Color emptyColor = new Color(0.6f,0.3f,0.1f);
    public Color growingColor = Color.green;
    public Color readyColor = Color.yellow;

    [Header("Optional Sprites")]
    public Sprite emptySprite;
    public Sprite growingSprite;
    public Sprite readySprite;

    private CropState lastState;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        plot = new Plot();
        UpdateVisual();
    }

    void Update()
    {
        if (!plot.IsEmpty() && plot.plantedCrop.state != lastState)
        {
            UpdateVisual();
            lastState = plot.plantedCrop.state;
        }
    }

    // PUBLIC INTERFACE

    public bool IsEmpty()
    {
        return plot.IsEmpty();
    }

    public void PlantCrop(Crop crop)
    {
        if (plot.IsEmpty())
        {
            plot.PlantCrop(crop);
            lastState = crop.state;
            UpdateVisual();
        }
    }

    public void GrowCrop()
    {
        plot.GrowCrop();
        UpdateVisual();
    }

    public void HarvestCrop()
    {
        plot.HarvestCrop();
        UpdateVisual();
    }

    // PRIVATE VISUAL UPDATE
    private void UpdateVisual()
    {
        if (!plot.IsEmpty())
        {
            switch(plot.plantedCrop.state)
            {
                case CropState.Seed:
                case CropState.Growing:
                    sr.sprite = growingSprite;
                    sr.color = growingColor;
                    break;
                case CropState.ReadyToHarvest:
                    sr.sprite = readySprite;
                    sr.color = readyColor;
                    break;
            }
        }
        else
        {
            sr.sprite = emptySprite;
            sr.color = emptyColor;
        }
    }
}
