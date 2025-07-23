using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
