using UnityEngine;

public class SettingsBtn : MonoBehaviour
{
    public GameObject settingsPanel;

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
