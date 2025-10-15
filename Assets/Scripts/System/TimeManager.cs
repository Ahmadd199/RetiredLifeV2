using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [System.Serializable] public class TimeChangedEvent : UnityEvent<int, int, int, float> { }
    // args: day, hour, minutes, normalizedDay [0..1]

    [Header("Time Setting")]
    [Tooltip("Minutes advanced per real-time second")]
    public float minutesPerSecond = 10f; //6s per in-game hour
    public int startDay = 1;
    public int startHour = 6;

    public TimeChangedEvent OnTimeChanged;

    private float minutes;
    private int day;

    private void Awake()
    {
        day = startDay;
        minutes = startHour * 60f;
        FireEvent();
    }

    private void Update()
    {
        minutes += minutesPerSecond * Time.deltaTime;
        if (minutes >= 1440f) { minutes -= 1440f; day++; }
        FireEvent();
    }

    void FireEvent()
    {
        int hour = Mathf.FloorToInt(this.minutes / 60f);
        int minutes = Mathf.FloorToInt(this.minutes % 60f);
        float normalized = minutes / 1440f;
        OnTimeChanged?.Invoke(day, hour, minutes, normalized);
    }
}
