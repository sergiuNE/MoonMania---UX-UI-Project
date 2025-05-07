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

        // Check if the next scene exists
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            GameManager.Level++;
            SceneManager.LoadScene(GameManager.Level);
        }
        else
        {
            Debug.Log("🚧 Next level not created yet.");
            // Optional: Show "Coming Soon" UI here
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
