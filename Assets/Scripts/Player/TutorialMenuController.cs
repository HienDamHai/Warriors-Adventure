using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialMenuController : MonoBehaviour
{
    public TMP_Text tutorialText;
    public Component component;
    public Button closeButton;

    public InputAction closeAction;
    private bool _listenersAdded = false;

    private HashSet<string> _displayedIds;

    private void Awake()
    {
        _displayedIds = new();
        closeAction.Enable();
        closeAction.performed += ctx => {
            component.gameObject.SetActive(false);
        };
    }

    public void SetText(string id, string text)
    {
        if (_displayedIds.Contains(id))
        {
            return; // Already displayed this tutorial text
        }
        _displayedIds.Add(id);
        if (tutorialText != null)
        {
            tutorialText.text = text;
        }
        component.gameObject.SetActive(true);
        if (!_listenersAdded)
        {
            AddListeners();
            _listenersAdded = true;
        }
    }

    private void AddListeners()
    {
        closeButton.onClick.AddListener(() => {
            component.gameObject.SetActive(false);
        });

    }
}
