using UnityEngine;

public class SecretZoneTrigger : MonoBehaviour
{
    public GameObject targetToHide;
    private InvetoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindFirstObjectByType<InvetoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (inventoryManager != null)
            {
                if (inventoryManager.HasItem("Key"))
                {
                    targetToHide.SetActive(false);
                    Debug.Log("Secret zone opened because you have the Key!");
                }
                else
                {
                    Debug.Log("You need a Key to open this secret zone.");
                }
            }
        } else
        {
            Debug.Log("inventory null");
        }
    }
}
