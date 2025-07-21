using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [SerializeField] private AudioSource sfxObject;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this; 
        }
    }

    public void PlaySFX(AudioClip audioClip, Transform transform, float volume)
    {
        var audioSource = Instantiate(sfxObject, transform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
