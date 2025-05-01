using UnityEngine;

public class setLevel : MonoBehaviour
{
    public int level;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLevel()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= level - 1)
        {
            GameManager.Level = level;
        }
    }
}
