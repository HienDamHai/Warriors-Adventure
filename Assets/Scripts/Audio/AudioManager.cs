using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        volume = volume <= 0 ? -80 : Mathf.Log10(volume) * 20f;
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        volume = volume <= 0 ? -80 : Mathf.Log10(volume) * 20f;
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        volume = volume <= 0 ? -80 : Mathf.Log10(volume) * 20f;
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
