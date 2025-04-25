using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    // Panels
    public GameObject profilePanel;
    public GameObject countryPanel;

    // Profiel UI elementen
    public TMP_InputField usernameInput;
    public Image countryImage;
    public Image selectedCountryPreview;
    public TextMeshProUGUI usernameTXT; // Referentie naar text in de game die de gebruikersnaam toont
    public Image imageCountry; // Referentie naar image in de game die de landvlag toont

    // Land selectie
    public Button[] countryButtons;
    private Sprite selectedCountrySprite;

    void Start()
    {
        // Laad opgeslagen gegevens indien aanwezig
        LoadProfile();
    }

    public void ShowProfile()
    {
        profilePanel.SetActive(true);
    }

    public void HideProfile()
    {
        profilePanel.SetActive(false);
    }

    public void SaveProfile()
    {
        // Sla de gebruikersnaam op
        string username = usernameInput.text;

        // Sla de gegevens op in PlayerPrefs
        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.Save();

        // Update de UI in de game
        if (usernameTXT != null)
        {
            usernameTXT.text = username;
        }

        // Verberg het profiel panel
        HideProfile();
    }

    public void SelectCountry()
    {
        profilePanel.SetActive(false);
        countryPanel.SetActive(true);
    }

    public void SaveCountry()
    {
        if (selectedCountrySprite != null)
        {
            // Update de landvlag in het profiel panel
            if (countryImage != null)
            {
                countryImage.sprite = selectedCountrySprite;
                countryImage.enabled = true;
            }

            // Update de landvlag in de game
            if (imageCountry != null)
            {
                imageCountry.sprite = selectedCountrySprite;
                imageCountry.enabled = true;
            }

            // Sla de geselecteerde landvlag op
            PlayerPrefs.SetString("CountryFlag", selectedCountrySprite.name);
            PlayerPrefs.Save();
        }

        countryPanel.SetActive(false);
        profilePanel.SetActive(true);
    }

    public void CloseCountry()
    {
        countryPanel.SetActive(false);
        profilePanel.SetActive(true);
    }

    // Methode om een land te selecteren (wordt aangeroepen door klikken op landvlag)
    public void SelectCountryFlag(Image flagImage)
    {
        selectedCountrySprite = flagImage.sprite;

        // Toon de geselecteerde vlag in de preview (indien beschikbaar)
        if (selectedCountryPreview != null)
        {
            selectedCountryPreview.sprite = selectedCountrySprite;
            selectedCountryPreview.enabled = true;
        }
    }

    // Methode om gegevens te laden bij het starten
    private void LoadProfile()
    {
        // Laad gebruikersnaam
        string savedUsername = PlayerPrefs.GetString("Username", "");
        if (!string.IsNullOrEmpty(savedUsername))
        {
            usernameInput.text = savedUsername;
            if (usernameTXT != null)
            {
                usernameTXT.text = savedUsername;
            }
        }

        // Laad landvlag
        string savedCountryFlag = PlayerPrefs.GetString("CountryFlag", "");
        if (!string.IsNullOrEmpty(savedCountryFlag))
        {
            // Zoek de juiste sprite op basis van de opgeslagen naam
            foreach (Button countryBtn in countryButtons)
            {
                Image flagImage = countryBtn.GetComponent<Image>();
                if (flagImage != null && flagImage.sprite != null && flagImage.sprite.name == savedCountryFlag)
                {
                    selectedCountrySprite = flagImage.sprite;

                    // Update de landvlag in het profiel panel
                    if (countryImage != null)
                    {
                        countryImage.sprite = selectedCountrySprite;
                        countryImage.enabled = true;
                    }

                    // Update de landvlag in de game
                    if (imageCountry != null)
                    {
                        imageCountry.sprite = selectedCountrySprite;
                        imageCountry.enabled = true;
                    }

                    break;
                }
            }
        }
    }
}