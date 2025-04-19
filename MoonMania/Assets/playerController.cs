using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject magneticField;
    public bool isAttracting = false;

    // 🔊 Add this to assign the audio in Inspector
    public AudioClip magnetSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magnetSound = AudioManager.Instance.jumpClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
         {
             isAttracting = true;
             this.gameObject.GetComponent<Animator>().SetBool("canMove", false);
             this.gameObject.GetComponent<Animator>().speed = 0;
             magneticField.GetComponent<Image>().enabled = true;

             //Play sound
             if (AudioManager.Instance != null && magnetSound != null)
             {
                 AudioManager.Instance.PlaySFX(magnetSound);
             }

             StartCoroutine(UseMagnet());
         }

    }

    public IEnumerator UseMagnet()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<Animator>().speed = 1;
        this.gameObject.GetComponent<Animator>().SetBool("canMove", true);
        magneticField.GetComponent<Image>().enabled = false;
        isAttracting = false;
    }
}
