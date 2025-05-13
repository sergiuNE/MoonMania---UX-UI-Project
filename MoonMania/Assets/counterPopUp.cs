using System.Collections;
using UnityEngine;

public class counterPopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(count());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator count()
    {
        yield return new WaitForSeconds(.4f);
        Destroy(this.gameObject);
    }
}
