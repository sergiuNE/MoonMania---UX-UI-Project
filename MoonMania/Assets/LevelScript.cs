using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScript : MonoBehaviour
{
    public GameObject levelsPanel;
    public Button[] levelButtons;
    public TextMeshProUGUI[] levelTexts;

    void Start()
    {
        UpdateLevelUI();
    }

    public void ShowLevels()
    {
        levelsPanel.SetActive(true);
        UpdateLevelUI();
    }

    public void HideLevels()
    {
        levelsPanel.SetActive(false);
    }

    public void UpdateLevelUI()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Default: only level 1 open

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                bool completed = PlayerPrefs.GetInt("Level" + (i + 1) + "_Completed", 0) == 1;
                levelButtons[i].interactable = true;
                levelTexts[i].text = completed ? "<color=green>✓</color>" : "<color=green>Open</color>";
            }
            else
            {
                levelButtons[i].interactable = false;
                levelTexts[i].text = "<color=red>Locked</color>";
            }
        }
    }

    public static void CompleteLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("Level" + levelIndex + "_Completed", 1);
        int currentUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (levelIndex >= currentUnlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndex + 1);
        }
    }

    // methode om alle levels te resetten
    public void ResetAllLevels()
    {
        // Reset de UnlockedLevel naar 1 (alleen level 1 open)
        PlayerPrefs.SetInt("UnlockedLevel", 1);

        // Reset de completed status van alle levels
        for (int i = 1; i <= levelButtons.Length; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "_Completed", 0);
        }

        // Forceer het opslaan van de PlayerPrefs naar de schijf
        PlayerPrefs.Save();

        // Debug log om te verifiëren dat de reset wordt uitgevoerd
        Debug.Log("Alle levels gereset. Alleen level 1 is nu open. UnlockedLevel = " + PlayerPrefs.GetInt("UnlockedLevel", 1));

        // Update de level UI om de wijzigingen weer te geven
        UpdateLevelUI();
    }
}
