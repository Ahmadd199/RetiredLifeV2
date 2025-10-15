using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeBarUI : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private TMP_Text timeLabel;
    [SerializeField] private Slider timeSlider;

    private void Start()
    {
        if (!timeManager) timeManager = FindAnyObjectByType<TimeManager>();
        timeManager.OnTimeChanged.AddListener(UpdateUI);
        // force first update
        UpdateUI(1, 6, 0, 0f);
    }

    private void UpdateUI(int day, int hour, int minute, float normalized)
    {
        if (timeLabel) timeLabel.text = $"Day {day} {hour:00}:{minute:00}";
        if (timeSlider)
        {
            timeSlider.minValue = 0f;
            timeSlider.maxValue = 1f;
            timeSlider.value = normalized;
        }
    }
}
