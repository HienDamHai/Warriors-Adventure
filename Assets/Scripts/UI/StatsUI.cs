using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public Component statsCanvas;
    public bool IsOpen => statsOpen;

    private bool statsOpen = false;

    private InputAction toggleStatsAction;

    private void Awake()
    {
        statsCanvas.gameObject.SetActive(false);
        toggleStatsAction = InputSystem.actions.FindAction("ToggleStats");
        toggleStatsAction.performed += ctx => UIManager.Instance.ToggleStats();
    }

    private void Start()
    {
        UpdateAllStats();
    }

    public void Open()
    {
        Time.timeScale = 0;
        UpdateAllStats();
        statsCanvas.gameObject.SetActive(true);
        statsOpen = true;
    }

    public void Close()
    {
        Time.timeScale = 1;
        statsCanvas.gameObject.SetActive(false);
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
