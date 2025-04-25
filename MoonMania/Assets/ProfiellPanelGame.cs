using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    public Image imageCountry;
    public TextMeshProUGUI usernameTXT;

    // Optioneel: vlaggenreferenties direct toewijzen
    public Sprite belgiumFlag;
    public Sprite franceFlag;
    public Sprite indiaFlag;
    public Sprite netherlandsFlag;
    public Sprite spainFlag;
    public Sprite ukFlag;
    public Sprite usaFlag;

    void Start()
    {
        LoadProfileData();
    }

    public void LoadProfileData()
    {
        // Laad gebruikersnaam
        string username = PlayerPrefs.GetString("Username", "Player");
        if (usernameTXT != null)
        {
            usernameTXT.text = username;
        }

        // Laad landvlag
        string countryFlagName = PlayerPrefs.GetString("CountryFlag", "");
        Debug.Log("Probeer vlag te laden met naam: " + countryFlagName);

        if (!string.IsNullOrEmpty(countryFlagName) && imageCountry != null)
        {
            AssignFlagByName(countryFlagName);
        }
    }

    // Methode om de juiste vlag toe te wijzen op basis van opgeslagen naam
    private void AssignFlagByName(string flagName)
    {
        Sprite selectedFlag = null;

        // Verwijder het _0, _1, etc. suffix dat Unity toevoegt aan sprite namen
        string baseName = flagName;
        if (flagName.Contains("_"))
        {
            baseName = flagName.Substring(0, flagName.LastIndexOf('_'));
        }

        Debug.Log("Zoeken naar vlag met basis naam: " + baseName);

        // Koppel de opgeslagen naam aan de juiste sprite
        switch (baseName.ToLower())
        {
            case "bel":
                selectedFlag = belgiumFlag;
                break;
            case "france":
                selectedFlag = franceFlag;
                break;
            case "india":
                selectedFlag = indiaFlag;
                break;
            case "ned":
                selectedFlag = netherlandsFlag;
                break;
            case "spain":
                selectedFlag = spainFlag;
                break;
            case "uk":
                selectedFlag = ukFlag;
                break;
            case "usa":
                selectedFlag = usaFlag;
                break;
            default:
                // Probeer te kijken of het naam bevat
                if (flagName.ToLower().Contains("bel")) selectedFlag = belgiumFlag;
                else if (flagName.ToLower().Contains("france")) selectedFlag = franceFlag;
                else if (flagName.ToLower().Contains("india")) selectedFlag = indiaFlag;
                else if (flagName.ToLower().Contains("ned")) selectedFlag = netherlandsFlag;
                else if (flagName.ToLower().Contains("spain")) selectedFlag = spainFlag;
                else if (flagName.ToLower().Contains("uk")) selectedFlag = ukFlag;
                else if (flagName.ToLower().Contains("usa")) selectedFlag = usaFlag;
                else Debug.LogWarning("Onbekende vlag naam: " + flagName);
                break;
        }

        if (selectedFlag != null)
        {
            imageCountry.sprite = selectedFlag;
            imageCountry.enabled = true;
            Debug.Log("Vlag toegewezen: " + baseName);
        }
    }
}