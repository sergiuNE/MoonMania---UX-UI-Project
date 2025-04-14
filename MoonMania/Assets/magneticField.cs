using System.Linq.Expressions;
using UnityEngine;

public class magneticField : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "item")
        {
            collision.gameObject.GetComponent<MoveToPlayer>().enabled = true;
        }
    }
}
