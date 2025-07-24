using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    public Image bar, barBackground;
    private float barValue;
    private float maxValue;
    public float BarValue
    {
        get { return barValue; }

        set
        {
            value = Mathf.Clamp(value, 0, maxValue);
            barValue = value;
            UpdateValue();
        }
    }

    public float MaxBarValue
    {
        get { return maxValue; }

        set
        {
            maxValue = value;
            UpdateValue();
        }
    }

    private void Start()
    {
        UpdateValue();
    }

    void UpdateValue()
    {
        UpdateValue(barValue);
    }

    void UpdateValue(float val)
    {
        bar.type = Image.Type.Filled;
        bar.fillAmount = val / maxValue;    
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {           
            UpdateValue(50);
        }
    }

}
