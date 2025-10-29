using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    private Plot plot; 

    void Awake()
    {
        plot = GetComponent<Plot>();

        if (plot == null)
            Debug.LogError("PlotBehaviour requires a Plot component on the same GameObject!");
    }

    public bool IsEmpty()
    {
        return plot.IsEmpty();
    }

    public void PlantCrop(Crop crop)
    {
        plot.PlantCrop(crop);
    }

    public void GrowCrop()
    {
        plot.GrowCrop();
    }

    public Crop HarvestCrop()
    {
        return plot.HarvestCrop();
    }
}
