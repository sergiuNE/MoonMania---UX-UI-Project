using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    // Drag the instructions panel (UI) into this from the Inspector
    public GameObject instructionsPanel;

    // This function shows the instructions panel
    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    // This function hides the instructions panel
    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
