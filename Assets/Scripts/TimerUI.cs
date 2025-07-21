using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeRemaining = 60f;
    public bool countdown = true;

    private float currentTime = 0f;
    private bool isPaused = false; // 👉 Thêm biến này

    void Start()
    {
        currentTime = countdown ? timeRemaining : 0f;
    }

    void Update()
    {
        if (isPaused) return; // 👉 Dừng đếm khi bị pause

        if (countdown && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                // TODO: hết giờ
            }
        }
        else if (!countdown)
        {
            currentTime += Time.deltaTime;
        }

        timerText.text = FormatTime(currentTime);
    }

    string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00} : {1:00} : {2:00}", hours, minutes, seconds);
    }

    // 👉 Hàm công khai để dừng timer từ bên ngoài
    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }
}