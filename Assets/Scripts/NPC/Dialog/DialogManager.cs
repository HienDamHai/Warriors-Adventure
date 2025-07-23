using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    public GameObject dialogCanvas;
    public Button dialogBox;

    [Header("Dialog Settings")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogText;
    public Button[] choiceButtons;

    private InputAction advanceAction;

    private NPCDialog currentDialog;
    public bool isDialogActive = false;
    
    private int dialogIndex;

    private Action<InputAction.CallbackContext> advanceActionHandler;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        dialogCanvas.SetActive(false);
    }

    public void StartDialog(NPCDialog dialog)
    {
        if (dialog == null || dialog.lines.Length == 0)
        {
            Debug.LogWarning("Dialog is null or has no lines.");
            return;
        }
        currentDialog = dialog;
        dialogIndex = 0;
        isDialogActive = true;
        ShowDialog();

        foreach (var button in choiceButtons)
        {
            button.gameObject.SetActive(false); // Hide all choice buttons initially
        }
        
        advanceAction = InputSystem.actions.FindAction("AdvanceDialog");
        advanceActionHandler = ctx => AdvanceDialog();
        advanceAction.performed += advanceActionHandler;
        
        dialogBox.onClick.AddListener(AdvanceDialog);
    }

    private void ShowChoices()
    {
        if (currentDialog == null || dialogIndex >= currentDialog.lines.Length)
        {
            Debug.LogWarning("No dialog to show or index out of range.");
            return;
        }
        if (currentDialog.choices.Length > 0)
        {
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < currentDialog.choices.Length)
                {
                    var choice = currentDialog.choices[i];

                    choiceButtons[i].GetComponentInChildren<TMP_Text>().text = choice.choiceText;
                    choiceButtons[i].gameObject.SetActive(true);
                    choiceButtons[i].onClick.RemoveAllListeners();
                    choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choice.nextDialog));
                }
                else
                {
                    choiceButtons[i].onClick.RemoveAllListeners();
                    choiceButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    private void ClearChoices()
    {
        foreach (var button in choiceButtons)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }
    }

    private void AdvanceDialog()
    {
        if (!isDialogActive || currentDialog == null)
        {
            Debug.LogWarning("Dialog is not active or current dialog is null.");
            return;
        }
        if (dialogIndex < currentDialog.lines.Length)
        {
            if (dialogIndex == currentDialog.lines.Length - 1)
            {
                ShowChoices(); // Show choices at the end of the dialog
            }    
            ShowDialog();
        }
        
        else
        {
            EndDialog();
        }
    }

    private void OnChoiceSelected(NPCDialog dialog)
    {
        if (dialog == null)
        {
            EndDialog();
            return;
        }
        StartDialog(dialog);
    }

    private void ShowDialog()
    {
        if (!dialogCanvas.activeSelf)
        {
            this.gameObject.SetActive(true);
            //dialogCanvas.SetActive(true);
        }
        Time.timeScale = 0; // Pause the game

        if (currentDialog == null || dialogIndex >= currentDialog.lines.Length)
        {
            Debug.LogWarning("No dialog to show or index out of range.");
            return;
        }
        var dialog = currentDialog.lines[dialogIndex];
        portrait.sprite = dialog.actor.portrait;
        actorName.text = dialog.actor.actorName;
        dialogText.text = dialog.text;
        
        // Increment the index for the next dialog
        dialogIndex++;
    }

    private void EndDialog()
    {
        isDialogActive = false;
        dialogCanvas.SetActive(false);
        currentDialog = null;
        dialogIndex = 0;

        Time.timeScale = 1; // Resume the game

        advanceAction.Disable(); 
        if (advanceActionHandler != null)
        {
            advanceAction.performed -= advanceActionHandler;
            advanceActionHandler = null;
        }

        ClearChoices();
        dialogBox.onClick.RemoveAllListeners();
    }
}
