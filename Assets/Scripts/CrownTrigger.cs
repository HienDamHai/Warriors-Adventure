using UnityEngine;

public class CrownTrigger : MonoBehaviour
{
    public bool isBossDead = false;
    public GameEndUIManager gameEndUIManager;

    void Start()
    {
        gameEndUIManager = FindFirstObjectByType<GameEndUIManager>();
    }


    public void SetBossDead()
    {
        isBossDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameEndUIManager != null)
            {
                gameEndUIManager.GameWin();
            }
            else
            {
                Debug.LogError("GameEndUIManager not found!");
            }
        }
    }
}
