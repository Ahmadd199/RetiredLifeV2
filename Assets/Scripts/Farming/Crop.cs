using UnityEngine;

public enum CropState
{
    Seed,
    Growing,
    ReadyToHarvest
}

public class Crop
{
    public string cropName;
    public int growthTime; 
    public int currentGrowth;
    public CropState state;

    public Crop(string name, int growthTime)
    {
        cropName = name;
        this.growthTime = growthTime;
        currentGrowth = 0;
        state = CropState.Seed;
    }

    public void Grow()
    {
        if (state == CropState.Seed || state == CropState.Growing)
        {
            currentGrowth++;
            if (currentGrowth >= growthTime)
            {
                state = CropState.ReadyToHarvest;
            }
            else
            {
                state = CropState.Growing;
            }
        }
    }

    public bool Harvest()
    {
        if (state == CropState.ReadyToHarvest)
        {
            Debug.Log($"{cropName} harvested!");
            return true;
        }
        return false;
    }
}