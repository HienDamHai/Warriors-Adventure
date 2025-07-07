using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;
        SetupResolution();
    }

    public void SetupResolution()
    {
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        string currentResolution = Screen.currentResolution.ToString();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " (" + resolutions[i].refreshRateRatio + "Hz)";
            resolutionDropdown.options.Add(new(option));
            if (resolutions[i].ToString() == currentResolution)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length)
        {
            Debug.LogError("Invalid resolution index: " + resolutionIndex);
            return;
        }
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume(float volume)
    {
        //TODO: Add audio 
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
