using UnityEngine;

public class SimpleInteractable : MonoBehaviour, IInteractable
{
    [TextArea] public string prompt = "Press E to interct";

    public string GetPrompt() => prompt;

    public void Interact()
    {
        Debug.Log($"Interacted with {name}");
        // TODO: Open, Teleport, Talk...
    }
}
