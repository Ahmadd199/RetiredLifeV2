using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionBarUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private TMP_Text text;
    [SerializeField] private float autoHideSeconds = 0f; // 0 = never auto-hide
    private Coroutine hideRoutine;

    private void Awake()
    {
        if (!root) root = gameObject;
        root.SetActive(false);
    }

    public void Show(string message)
    {
        if (hideRoutine != null) { StopCoroutine(hideRoutine); hideRoutine = null; }

        if (text) text.text = message;
        root.SetActive(true);

        if (autoHideSeconds > 0f) 
            hideRoutine = StartCoroutine(AutoHide());
    }

    public void Hide()
    {
        if (hideRoutine != null) { StopCoroutine(hideRoutine); hideRoutine= null; }
        root.SetActive(false);
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(autoHideSeconds);
        Hide();
    }

    public void ShowForSeonds(string message, float seconds)
    {
        autoHideSeconds = seconds;
        Show(message);
    }

    public void SetAutoHide(float seconds) => autoHideSeconds = seconds;
}
