using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    // Drag your actual panel GameObject here in the Inspector
    public GameObject victoryPanelUI;

    public void OnNextLevelClicked()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Mark this level as complete
        FindObjectOfType<LevelScript>().CompleteLevel(currentIndex);

        // Hide the victory panel
        if (victoryPanelUI != null)
        {
            victoryPanelUI.SetActive(false);
        }

        // Check if the next scene exists
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
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
