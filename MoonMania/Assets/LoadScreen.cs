using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitLoading());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Level == 2)
        {
            GameObject.Find("GoalTxt").GetComponent<TextMeshProUGUI>().text = "Goal: $550";
        }
        if (GameManager.Level == 3)
        {

            GameObject.Find("GoalTxt").GetComponent<TextMeshProUGUI>().text = "Goal: $600";
        }
        if (GameManager.Level == 4)
        {

            GameObject.Find("GoalTxt").GetComponent<TextMeshProUGUI>().text = "Goal: $650";
        }
        if (GameManager.Level == 5)
        {

            GameObject.Find("GoalTxt").GetComponent<TextMeshProUGUI>().text = "Goal: $700";
        }
        if (GameManager.Level == 6)
        {

            GameObject.Find("GoalTxt").GetComponent<TextMeshProUGUI>().text = "Goal: $750";
        }
    }

    public IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(GameManager.Level);
    }
}
