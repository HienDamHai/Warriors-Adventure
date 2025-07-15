using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger by: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Checkpoint HIT!");
            CheckpointManager.Instance.LastPosition = transform.position;
            Debug.Log("Checkpoint position set to: " + CheckpointManager.Instance.LastPosition);
         }
    }
}
