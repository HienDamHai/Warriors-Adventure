using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUIManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGameWin = false;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject playerPrefab;
    public Transform firstSpawnPoint;
    public TMP_Text scoreSummaryText;
    public TMP_Text goldSummaryText;
    public TMP_Text finalScoreText;

    public static GameEndUIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void GameWin()
    {
        isGameWin = true;
        gameWinUI.SetActive(true);
        ShowSummary();
    }
    private void ShowSummary()
    {
        int score = ScoreManager.Instance.currentScore;
        int gold = FindFirstObjectByType<InvetoryManager>().gold;

        int finalScore = score + (gold * 5);

        if (scoreSummaryText != null)
            scoreSummaryText.text = "Score: " + score;

        if (goldSummaryText != null)
            goldSummaryText.text = "Gold: " + gold + " x 5";

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + finalScore;
    }

    public void PlayAgain()
    {
        isGameOver = false;
        isGameWin = false;
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        // Reset Player
        var player = FindFirstObjectByType<PlayerHealth>();
        if (player != null)
        {
            player.ResetAll();
        }

        // Reset EXP
        if (ExpManager.Instance != null)
            ExpManager.Instance.ResetExp();

        // Reset Stats
        if (StatsManager.Instance != null)
            StatsManager.Instance.ResetStats();

        // Reset SkillTree
        if (SkillTreeManager.Instance != null)
            SkillTreeManager.Instance.ResetSkillTree();

        // Reset Score
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore();

        // Reset Timer
        var timer = FindFirstObjectByType<TimerUI>();
        if (timer != null)
            timer.ResetTimer();

        var inventory = FindFirstObjectByType<InvetoryManager>();
        if (inventory != null)
        {
            inventory.ResetInventory();
        }
        Debug.Log("Game fully reset.");

        var checkPoint = CheckpointManager.Instance;
        if (checkPoint != null)
        {
            checkPoint.ResetCheckpoint();
        }

        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }
    public void ResetAll()
    {
        isGameOver = false;
        isGameWin = false;
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        // Reset Player
        var player = FindFirstObjectByType<PlayerHealth>();
        if (player != null)
        {
            player.ResetAll();
        }

        // Reset EXP
        if (ExpManager.Instance != null)
            ExpManager.Instance.ResetExp();

        // Reset Stats
        if (StatsManager.Instance != null)
            StatsManager.Instance.ResetStats();

        // Reset SkillTree
        if (SkillTreeManager.Instance != null)
            SkillTreeManager.Instance.ResetSkillTree();

        // Reset Score
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore();

        // Reset Timer
        var timer = FindFirstObjectByType<TimerUI>();
        if (timer != null)
            timer.ResetTimer();

        var inventory = FindFirstObjectByType<InvetoryManager>();
        if (inventory != null)
        {
            inventory.ResetInventory();
        }
        Debug.Log("Game fully reset.");

        var checkPoint = CheckpointManager.Instance;
        if (checkPoint != null)
        {
            checkPoint.ResetCheckpoint();
        }
    }
}
