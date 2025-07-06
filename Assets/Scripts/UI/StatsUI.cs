using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;
    public bool IsOpen => statsOpen;

    private bool statsOpen = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))//nhan phim n
        {
            UIManager.Instance.ToggleStats();
        }
    }

    public void Open()
    {
        Time.timeScale = 0;
        UpdateAllStats();
        statsCanvas.alpha = 1;
        statsOpen = true;
    }

    public void Close()
    {
        Time.timeScale = 1;
        statsCanvas.alpha = 0;
        statsOpen = false;
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.damage;
    }

    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.speed;
    }

    public void UpdateMaxHealth()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Max health: " + StatsManager.Instance.maxHealth;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateMaxHealth();
    }
}
