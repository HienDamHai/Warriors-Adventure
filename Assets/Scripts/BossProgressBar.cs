using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


[ExecuteInEditMode]

public class BossProgressBar : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public Image bar, barBackground;
    private float barValue;
    private float maxHealth = 100f; // Default max health, can be set externally
    public float BarValue
    {
        get { return barValue; }

        set
        {
            value = Mathf.Clamp(value, 0, MaxHealth);
            barValue = value;
            UpdateValue(barValue);

        }
    }
    

    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value;
            UpdateValue(value);
        }
    }

    public void SetActive(bool active)
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        if (active)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        UpdateValue(barValue);
    }

    void UpdateValue(float val)
    {
        bar.type = Image.Type.Filled;
        bar.fillAmount = val / maxHealth;
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {           
            UpdateValue(50);
        }
    }
}
