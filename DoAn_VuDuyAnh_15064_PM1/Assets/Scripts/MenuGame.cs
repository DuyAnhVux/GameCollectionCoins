using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void gotoOptionMenu()
    {
        SceneManager.LoadScene("HelpMenu");
    }
    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
