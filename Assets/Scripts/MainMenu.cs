using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Home()
    {
        GameEndUIManager.Instance.isGameOver = false;
        GameEndUIManager.Instance.isGameWin = false;
        GameEndUIManager.Instance.gameOverUI.SetActive(false);
        GameEndUIManager.Instance.gameWinUI.SetActive(false);
        GameEndUIManager.Instance.ResetAll();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 0;
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
