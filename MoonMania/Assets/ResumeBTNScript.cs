using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeBTNScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsPanelUI;
    public bool isPaused = false;

    void Update()
    {
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
        SceneManager.LoadScene("Menu");
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
