using UnityEngine;
using UnityEngine.UI;

public class SettingsToggle : MonoBehaviour
{
    public Toggle toggle;
    public Image knobImage;
    public RectTransform knobTransform;

    public Color onColor = new Color(0f, 1f, 0f);   // Green
    public Color offColor = new Color(1f, 0f, 0f);  // Red

    public Vector2 onPosition = new Vector2(25f, 0f);
    public Vector2 offPosition = new Vector2(-25f, 0f);

    private string toggleKey; // Key used to store in PlayerPrefs

    private void Start()
    {
        // Generate a unique key based on the GameObject's name
        toggleKey = gameObject.name + "_ToggleState";

        // Load saved state, default to 1 (on)
        int savedValue = PlayerPrefs.GetInt(toggleKey, 1);
        bool isOn = savedValue == 1;
        toggle.isOn = isOn;

        UpdateVisuals(isOn);

        // Subscribe to value change
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        UpdateVisuals(isOn);

        string toggleName = gameObject.name;

        switch (toggleName)
        {
            case "MusicToggle":
                AudioManager.Instance.ToggleMusic(isOn);
                break;
            case "SFXToggle":
                AudioManager.Instance.ToggleSFX(isOn);
                break;
            case "MenuToggle":
                AudioManager.Instance.ToggleMenu(isOn);
                break;
        }

        // Save the new state
        PlayerPrefs.SetInt(toggleKey, isOn ? 1 : 0);
        PlayerPrefs.Save(); // Optional but good practice

        Debug.Log($"{gameObject.name} toggled to {(isOn ? "ON" : "OFF")}");
    }

    void UpdateVisuals(bool isOn)
    {
        knobImage.color = isOn ? onColor : offColor;
        knobTransform.anchoredPosition = isOn ? onPosition : offPosition;
    }
}
