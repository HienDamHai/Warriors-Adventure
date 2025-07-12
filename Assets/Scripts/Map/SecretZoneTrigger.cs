using UnityEngine;

public class SecretZoneTrigger : MonoBehaviour
{
    public GameObject targetToHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSecretKey inventory = collision.GetComponent<PlayerSecretKey>();
            if (inventory.hasKey)
            {
                targetToHide.SetActive(false);
            }
        }
    }
}
