using TMPro;
using UnityEngine;

public class setGoal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Goal: $" + GameObject.Find("GameManager").GetComponent<GameManager>().goal;


    }
}
