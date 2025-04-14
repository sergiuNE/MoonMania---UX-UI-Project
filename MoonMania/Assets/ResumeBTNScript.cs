using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeBTNScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Update()
    {
        // Toggle pause when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Reset time in case it's still paused
        SceneManager.sceneLoaded += OnMenuSceneLoaded; // Attach event before loading
        SceneManager.LoadScene("Menu"); // Make sure your menu scene is named "Menu"
    }

    private void OnMenuSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find and refresh canvas in Menu scene
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvas.enabled = false;
            canvas.enabled = true;
        }

        // Remove the event listener after it's done
        SceneManager.sceneLoaded -= OnMenuSceneLoaded;
    }

    public void OpenSettings()
    {
        // You can implement your settings menu logic here later
        Debug.Log("Settings menu opened (not implemented yet).");
    }
}
