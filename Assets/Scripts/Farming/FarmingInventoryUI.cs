using UnityEngine;
using TMPro;

public class FarmingInventoryUI : MonoBehaviour
{
    [Header("References")]
    public FarmingInventoryHandler farmingInventory;  
    public GameObject cropTextTemplate;                

    void Start()
    {
        if (!farmingInventory)
            farmingInventory = FindAnyObjectByType<FarmingInventoryHandler>();

        if (cropTextTemplate != null)
            cropTextTemplate.SetActive(false);

        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool newState = !gameObject.activeSelf;
            gameObject.SetActive(newState);

            if (newState)
                UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        if (!farmingInventory || !cropTextTemplate)
        {
            Debug.LogWarning("Missing FarmingInventoryHandler or cropTextTemplate reference!");
            return;
        }

        foreach (Transform child in transform)
        {
            if (child.gameObject != cropTextTemplate)
                Destroy(child.gameObject);
        }

        foreach (var slot in farmingInventory.slots)
        {
            if (slot.item != null && slot.count > 0)
            {
                GameObject newText = Instantiate(cropTextTemplate, transform);
                newText.SetActive(true);

                TMP_Text text = newText.GetComponent<TMP_Text>();
                text.text = $"{slot.item.itemName} x{slot.count}";
            }
        }
    }
}

