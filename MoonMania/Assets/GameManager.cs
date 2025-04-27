using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int goal;
    public GameObject scoreText;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;
    private bool hasWon = false;
    private bool hasLost = false;
    public static int Level = 2;

    public string SetLevel()
    {
        Level = 1;
        return "test";
    }

    void Awake()
    {
        LevelScript.CompleteLevel(2);
        // Zoek objecten als ze niet zijn toegewezen
        if (victoryPanel == null)
            victoryPanel = GameObject.Find("VictoryPanel");

        if (gameOverPanel == null)
            gameOverPanel = GameObject.Find("GameOverPanel");

        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText");
    }

    void Start()
    {
            score = 300;
        if (Level == 2)
        {
            goal = 550;
        }
        if (Level == 3)
        {
            goal = 600;
        }
        if (Level == 4)
        {
            goal = 650;
        }
        if (Level == 5)
        {
            goal = 700;
        }
        if (Level == 6)
        {
            goal = 750;
        }
        hasWon = false;
        hasLost = false;

        // Verberg beide panels bij het starten
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Update de score tekst meteen
        UpdateScoreText();
    }

    // Aparte functie voor score tekst update
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            TextMeshProUGUI textComponent = scoreText.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "Score: $" + score.ToString();
            }
        }
    }

    void Update()
    {
        // Update score tekst
        UpdateScoreText();

        // Controleer op overwinning
        if (!hasWon && !hasLost && score >= goal)
        {
            hasWon = true;
            if (victoryPanel != null)
                victoryPanel.SetActive(true);
        }

        // Controleer op verlies
        if (!hasLost && !hasWon && score <= 0)
        {
            hasLost = true;
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }

        // Debug toets om score te verhogen (voor testen)
        if (Input.GetKeyDown(KeyCode.PageUp))
            score += 50;

        // Debug toets om score te verlagen (voor testen)
        if (Input.GetKeyDown(KeyCode.PageDown))
            score -= 50;
    }
}
