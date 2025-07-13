using UnityEngine;
using UnityEngine.InputSystem;

public class SkillsUI : MonoBehaviour
{
    public Component skillsCanvas;
    public bool IsOpen => skillsOpen;

    private bool skillsOpen = false;

    private InputAction toggleSkillsAction;

    private void Awake()
    {
        skillsCanvas.gameObject.SetActive(false);
        toggleSkillsAction = InputSystem.actions.FindAction("ToggleSkills");
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
