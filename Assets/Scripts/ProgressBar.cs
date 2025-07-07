using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    public Image bar, barBackground;
    private float barValue;
    public float BarValue
    {
        get { return barValue; }

        set
        {
            value = Mathf.Clamp(value, 0, 100);
            barValue = value;
            UpdateValue(barValue);

        }
    }
        
    private void Start()
    {
        UpdateValue(barValue);
    }

    void UpdateValue(float val)
    {
        bar.type = Image.Type.Filled;
        bar.fillAmount = val / 100;    
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {           
            UpdateValue(50);
        }
    }

}
