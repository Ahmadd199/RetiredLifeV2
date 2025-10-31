using UnityEngine;

namespace RetiredLife
{
    /// <summary>
    /// Interface for all interactable objects in the game
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Checks if the object can be interacted with
        /// </summary>
        /// <returns>True if interaction is possible, false otherwise</returns>
        bool CanInteract();

        /// <summary>
        /// Handles the interaction with the object
        /// </summary>
        void Interact();
    }
}