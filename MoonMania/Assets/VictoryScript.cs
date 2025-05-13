using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    public GameObject victoryPanelUI;

    public void OnNextLevelClicked()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Mark this level as complete
        LevelScript.CompleteLevel(currentIndex);

        // Hide the victory panel
        if (victoryPanelUI != null)
        {
            victoryPanelUI.SetActive(false);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameManager.Level = 2;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameManager.Level = 3;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameManager.Level = 4;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameManager.Level = 5;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameManager.Level = 6;
        }

        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
