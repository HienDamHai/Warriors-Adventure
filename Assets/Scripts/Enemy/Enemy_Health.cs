using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 3;
    private int scoreReward = 1;
    public delegate void MonsterDefeated(int exp, int score);
    public static event MonsterDefeated OnMonsterDefeated;
    public int currentHealth;
    public int maxHealth;

    public NPCDialog bossDeathDialog;

    private BossProgressBar bossProgressBar;
    private TimerUI timerUI;

    private void Start()
    {
        currentHealth = maxHealth;
        SetScoreReward();
        timerUI = FindFirstObjectByType<TimerUI>();
        if (gameObject.CompareTag("Boss"))
        {
            bossProgressBar = FindFirstObjectByType<BossProgressBar>();
            bossProgressBar.MaxHealth = maxHealth;
            bossProgressBar.BarValue = currentHealth;
        }

    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (gameObject.CompareTag("Boss"))
        {
            bossProgressBar.BarValue = currentHealth;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(expReward, scoreReward);
            if (gameObject.CompareTag("Boss"))
            {
                timerUI?.PauseTimer();
                DialogManager.Instance.StartDialog(bossDeathDialog);
                // bossProgressBar.SetActive(false);
            }
            Destroy(gameObject);
        }
    }

    //Setup score 
    public void SetScoreReward()
    {
        var enemyScores = EnemyScore.EnemyScores;
        // Neu gameObject name co trong danh sach EnemyScores gan dung
        foreach (var enemyScore in enemyScores)
        {
            if (gameObject.name.Contains(enemyScore.Key))
            {
                scoreReward = enemyScore.Value;
                return;
            }
        }
    }
}
