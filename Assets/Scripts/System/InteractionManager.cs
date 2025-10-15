using UnityEngine;
using System;

public class InteractionManager : MonoBehaviour
{
    public KeyCode key = KeyCode.E;
    public float maxDistance = 2f;
    public event Action<string, bool> OnPrompt;

    IInteractable current;

    private void Update()
    {
        if (current != null && Input.GetKeyDown(key))
            current.Interact();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var interact = other.GetComponent<IInteractable>();
        if (interact == null) return;

        float d = Vector2.Distance(transform.position, other.transform.position);
        if (d <= maxDistance)
        {
            if (current == null ||
                d < Vector2.Distance(transform.position, ((Component)current).transform.position))
            {
                current = interact;
                OnPrompt?.Invoke(interact.GetPrompt(), true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (current != null && other .GetComponent<IInteractable>() == current)
        {
            current = null;
            OnPrompt?.Invoke("", false);
        }
    }
}
