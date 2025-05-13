using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    GameObject gm;

    public GameObject player;
    public GameObject magnet;

    public GameObject counterPopUp;
    public GameObject counterSpawn;

    public bool canMove = false;

    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterSpawn = GameObject.Find("counterSpawn");
        gm = GameObject.Find("GameManager");

        counterPopUp = Resources.Load<GameObject>("CounterPopUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (magnet.GetComponent<playerController>().isAttracting && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, 200 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "magneticField")
        {
            canMove = true;
        }

        if (other.gameObject.name == "player")
        {
            gm.GetComponent<GameManager>().score += score;
            GameObject popup = Instantiate(counterPopUp, counterSpawn.transform);
            if (score > 0)
            {
                popup.GetComponent<TextMeshProUGUI>().text = "+" + score;
                popup.GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else
            {
                popup.GetComponent<TextMeshProUGUI>().text = "" + score;
                popup.GetComponent<TextMeshProUGUI>().color = Color.red;
            }

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "magneticField")
        {
            canMove = false;
        }
    }
}
