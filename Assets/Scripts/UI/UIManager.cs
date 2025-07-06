using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public StatsUI statsUI;
    public SkillsUI skillsUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ToggleStats()
    {
        if (statsUI.IsOpen)
        {
            statsUI.Close();
        }
        else
        {
            skillsUI.Close();
            statsUI.Open();
        }
    }

    public void ToggleSkills()
    {
        if (skillsUI.IsOpen)
        {
            skillsUI.Close();
        }
        else
        {
            statsUI.Close();
            skillsUI.Open();
        }
    }
}
