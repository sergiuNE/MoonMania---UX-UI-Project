using TMPro;
using UnityEngine;

public class unlockLevelsUI : MonoBehaviour
{
    public GameObject level1Text;
    public GameObject level2Text;
    public GameObject level3Text;
    public GameObject level4Text;
    public GameObject level5Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 2)
        {
            level2Text.GetComponent<TextMeshProUGUI>().text = "Open";
            level2Text.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 3)
        {
            level3Text.GetComponent<TextMeshProUGUI>().text = "Open";
            level3Text.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 4)
        {
            level4Text.GetComponent<TextMeshProUGUI>().text = "Open";
            level4Text.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 5)
        {
            level5Text.GetComponent<TextMeshProUGUI>().text = "Open";
            level5Text.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
    }
}
