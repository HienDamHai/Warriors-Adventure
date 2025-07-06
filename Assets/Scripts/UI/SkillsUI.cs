using UnityEngine;

public class SkillsUI : MonoBehaviour
{
    public CanvasGroup skillsCanvas;
    public bool IsOpen => skillsOpen;

    private bool skillsOpen = false;

    private void Update()
    {
        if (Input.GetButtonDown("ToggleSkills"))//nhan phim m
        {
            UIManager.Instance.ToggleSkills();
        }
    }

    public void Open()
    {
        Time.timeScale = 0;
        skillsCanvas.alpha = 1;
        skillsOpen = true;
    }

    public void Close()
    {
        Time.timeScale = 1;
        skillsCanvas.alpha = 0;
        skillsOpen = false;
    }
}
