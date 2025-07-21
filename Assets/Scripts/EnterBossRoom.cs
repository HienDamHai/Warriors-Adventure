using UnityEngine;

public class EnterBossRoom : MonoBehaviour
{

    private BossProgressBar bossProgressBar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered boss room: " + gameObject.name);
            bossProgressBar = FindFirstObjectByType<BossProgressBar>();
            if (bossProgressBar != null)
            {
                bossProgressBar.SetActive(true);
            }
            else
            {
                Debug.LogWarning("BossProgressBar not found in the scene.");
            }
        }
    }
}
