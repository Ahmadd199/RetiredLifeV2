using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RetiredLife
{
    /// <summary>
    /// Controls the game's pause state
    /// </summary>
    public class PauseController : MonoBehaviour
    {
        public static bool IsGamePaused { get; private set; }

        public static void SetPause(bool isPaused)
        {
            IsGamePaused = isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
