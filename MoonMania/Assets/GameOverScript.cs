using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Drag your actual panel GameObject here in the Inspector
    public GameObject gameOverPanel;

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}