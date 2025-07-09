using UnityEngine;
using UnityEngine.InputSystem;

public class SkillsUI : MonoBehaviour
{
    public Component skillsCanvas;
    public bool IsOpen => skillsOpen;

    private bool skillsOpen = false;

    public InputAction toggleSkillsAction;

    private void Awake()
    {
        if (skillsCanvas == null)
        {
            Debug.LogError("Skills Canvas is not assigned in the SkillsUI script.");
            return;
        }
        skillsCanvas.gameObject.SetActive(false);
        toggleSkillsAction.Enable();
        toggleSkillsAction.performed += ctx => UIManager.Instance.ToggleSkills();
    }

    public void Open()
    {
        Time.timeScale = 0;
        skillsCanvas.gameObject.SetActive(true);
        skillsOpen = true;
    }

    public void Close()
    {
        Time.timeScale = 1;
        skillsCanvas.gameObject.SetActive(false);
        skillsOpen = false;
    }
}
