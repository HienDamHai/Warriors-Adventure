using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector2 LastPosition { get; set; }
    public Vector2 FirstPosition { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FirstPosition = new Vector2(-45, -38f);
        LastPosition = FirstPosition;
    }
    public void ResetCheckpoint()
    {
        LastPosition = FirstPosition;
    }
}
