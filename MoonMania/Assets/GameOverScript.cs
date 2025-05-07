using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RetryLVL()
    {
        SceneManager.LoadScene("Game");
    }

    public void RetryLVL2()
    {
        SceneManager.LoadScene("Game 1");
    }

    public void RetryLVL3()
    {
        SceneManager.LoadScene("Game 2");
    }

    public void RetryLVL4()
    {
        SceneManager.LoadScene("Game 3");
    }

    public void RetryLVL5()
    {
        SceneManager.LoadScene("Game 4");
    }
}