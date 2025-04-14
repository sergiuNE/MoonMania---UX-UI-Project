using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject magneticField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.GetComponent<Animator>().SetBool("canMove", false);
            this.gameObject.GetComponent<Animator>().speed = 0;
            magneticField.SetActive(true);
            StartCoroutine(UseMagnet());
        }
    }

    public IEnumerator UseMagnet()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.GetComponent<Animator>().speed = 1;
        this.gameObject.GetComponent<Animator>().SetBool("canMove", true);
        magneticField.SetActive(false);
    }
}
