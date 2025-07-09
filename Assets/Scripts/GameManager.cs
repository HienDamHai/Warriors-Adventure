using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("PersistentData")]
    public GameObject[] persistentOjects;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this instance persistent across scenes
            SetPersistentData(persistentOjects); // Set persistent data for game objects
        }
        else
        {
            CleanUp(persistentOjects); // Clean up if another instance exists
            Destroy(gameObject); // Destroy the GameManager instance
        }
    }

    private void SetPersistentData(GameObject[] components)
    {
        foreach (var obj in components)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj); // Make each game object persistent
            }
        }
    }

    private void CleanUp(GameObject[] components)
    {
        foreach (var obj in components)
        {
            if (obj != null)
            {
                Destroy(obj); // Destroy each game object that is not persistent
            }
        }
    }
}
