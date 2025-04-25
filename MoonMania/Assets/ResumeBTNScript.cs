using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeBTNScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsPanelUI;
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
        settingsPanelUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsPanelUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Reset time in case it's still paused
        SceneManager.sceneLoaded += OnMenuSceneLoaded; // Attach event before loading
        SceneManager.LoadScene("Menu"); 
        //SceneHelper.Instance.LoadMenuSceneWithCanvasRefresh();
    }

    private void OnMenuSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnMenuSceneLoaded;
        // Start coroutine to wait for next frame
        StartCoroutine(RefreshCanvasNextFrame());
    }

    private System.Collections.IEnumerator RefreshCanvasNextFrame()
    {
        yield return null; // Wait one frame

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvas.enabled = false;
            yield return null; // Wait one more frame just in case
            canvas.enabled = true;
        }
    }


    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);            // Hide pause panel
        settingsPanelUI.SetActive(true);         // Show settings panel
    }

    public void CloseSettings()
    {
        settingsPanelUI.SetActive(false);        // Hide settings
        pauseMenuUI.SetActive(true);             // Show pause menu again
    }
}
